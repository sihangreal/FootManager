using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.Core;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace ClientCenter.DB
{
    public class MySqlClient
    {
        private string connectionString;
        // 用于缓存参数的HASH表
        private  Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        private static MySqlClient instance;
 
        private MySqlClient()
        {
            string appPath = System.AppDomain.CurrentDomain.BaseDirectory + "FootConfig.xml";
            string server = XmlUtil.ReadDataInfo(appPath, "Server");
            string dataBase= XmlUtil.ReadDataInfo(appPath, "DataBase");
            string user= XmlUtil.ReadDataInfo(appPath, "DataUser");
            string password = XmlUtil.ReadDataInfo(appPath, "DataPassword");
            //string providerName = XmlUtil.ReadDataInfo(appPath, "ProviderName");
            connectionString = "Data Source=" + server + "; Database=" + dataBase + "; User ID=" + user + ";Password=" + password + " ;CharSet=utf8;";
        }

        public static MySqlClient GetMySqlClient()
        {
            if(instance==null)
            {
                instance = new MySqlClient();
            }
            return instance;
        }

        // 准备执行一个命令
        public void PrepareCommand(ref MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, List<MySqlParameter> cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public int ExecuteNonQuery(string cmdText, CommandType cmdType = CommandType.Text)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = cmdType;
                try
                {
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return -1;
                }
            }
        }
        // 给定连接的数据库用假设参数执行一个sql命令（不返回数据集）
        public  int ExecuteNonQuery(string cmdText, List<MySqlParameter> commandParameters, CommandType cmdType = CommandType.Text)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(ref cmd, conn, null, cmdType, cmdText, commandParameters);
                try
                {
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
               catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return -1;
                }
            }
        }

        //用执行的数据库连接执行一个返回数据集的sql命令
        public MySqlDataReader ExecuteReader(string cmdText,List<MySqlParameter> commandParameters, CommandType cmdType = CommandType.Text)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(ref cmd, conn, null, cmdType, cmdText,commandParameters);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //清除参数
                cmd.Parameters.Clear();
                return reader;
            }
            catch
            {
                //关闭连接，抛出异常
                conn.Close();
                throw;
            }
        }

        public MySqlDataReader ExecuteReader(string cmdText, CommandType cmdType = CommandType.Text)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                PrepareCommand(ref cmd, conn, null, cmdType, cmdText, null);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch
            {
                //关闭连接，抛出异常
                conn.Close();
                throw;
            }
        }

        // 返回DataSet
        public DataSet GetDataSet(string cmdText,List<MySqlParameter> commandParameters, CommandType cmdType = CommandType.Text)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                //调用 PrepareCommand 方法，对 MySqlCommand 对象设置参数
                PrepareCommand(ref cmd, conn, null, cmdType, cmdText, commandParameters);
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                //清除参数
                cmd.Parameters.Clear();
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                //关闭连接，抛出异常
                conn.Close();
                throw e;
            }
        }

        public DataSet GetDataSet(string cmdText, CommandType cmdType = CommandType.Text)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                //调用 MySqlCommand  的 ExecuteReader 方法
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                //清除参数
                cmd.Parameters.Clear();
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                //关闭连接，抛出异常
                conn.Close();
                throw e;
            }
        }

        // 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
        public object ExecuteScalar(string cmdText,  List<MySqlParameter> commandParameters, CommandType cmdType = CommandType.Text)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                PrepareCommand(ref cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public bool ExecuteTransaction(Dictionary<string, List<MySqlParameter>> tranactionDic)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlTransaction transaction = connection.BeginTransaction();
                foreach (string strsql in tranactionDic.Keys)
                {
                    PrepareCommand(ref cmd, connection, transaction, CommandType.Text, strsql, tranactionDic[strsql]);
                    int val = cmd.ExecuteNonQuery();
                    if (val < 0)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                transaction.Commit();
                return true;
             }
        }

        public void GenerateInsertSql<T>(T data,ref Dictionary<string, List<MySqlParameter>> transactionDic)
        {
            Type type = typeof(T);
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ");
            sb.Append(dataAttr.TableName + "(");
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                if (infoAttr.Bquery)
                {
                    sb.Append(info.Name + ",");
                }
            }
            sb.Remove(sb.Length - 1, 1);//移除 多余的 ","
            sb.Append(")");
            sb.Append("VALUES(");
            foreach (PropertyInfo info in propertyInfos)
            {
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                if (infoAttr.Bquery)
                {
                    sb.Append("@" + info.Name + ",");
                }
            }
            sb.Remove(sb.Length - 1, 1);//移除 多余的 ","
            sb.Append(")");

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            for (int i = 0; i < propertyInfos.Length; ++i)
            {
                PropertyInfo info = propertyInfos[i];
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                if (infoAttr.Bquery)
                {
                    string strPara = "@" + info.Name;
                    MySqlParameter parameter = new MySqlParameter(strPara, ConvertDBType(info.PropertyType));
                    parameter.Value = info.GetValue(data);
                    parameters.Add(parameter);
                }
            }
            Dictionary<string, List<MySqlParameter>> dic = new Dictionary<string, List<MySqlParameter>>();
            transactionDic.Add(sb.ToString(), parameters);
        }
        // 将参数集合添加到缓存
        public void CacheParameters(string cacheKey, params MySqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        // 找回缓存参数集合
        public MySqlParameter[] GetCachedParameters(string cacheKey)
        {
            MySqlParameter[] cachedParms = (MySqlParameter[])parmCache[cacheKey];
            if (cachedParms == null)
                return null;
            MySqlParameter[] clonedParms = new MySqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (MySqlParameter)((ICloneable)cachedParms[i]).Clone();
            return clonedParms;
        }

        public MySqlConnection GetConnect()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
        public  MySqlDbType ConvertDBType(Type type)
        {
            MySqlDbType dbType = 0;
            switch (type.Name)
            {
                case "String":
                    dbType = MySqlDbType.String;
                    break;
                case "Int32":
                    dbType = MySqlDbType.Int32;
                    break;
                case "DateTime":
                    dbType = MySqlDbType.DateTime;
                    break;
                case "Double":
                    dbType = MySqlDbType.Double;
                    break;
                case "Int64":
                    dbType = MySqlDbType.Int64;
                    break;
            }
            return dbType;
        }
    }
}
