using ClientCenter.Core;
using ClientCenter.Enity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.DB
{
    public class SelectDao
    {
        private static MySqlClient mySqlclient;

        private static string ANDCOMPANYID= " AND CompanyId = "+SystemConst.companyId;
        private static string WHERECOMPANYID = " WHERE CompanyId = " + SystemConst.companyId;

        private static object ConvertDBNull(Type type)
        {
            object value = null;
            switch (type.Name)
            {
                case "String":
                    value = "";
                    break;
                case "Int32":
                    value = 0;
                    break;
                case "DateTime":
                    value = new DateTime();
                    break;
                case "Double":
                    value = 0;
                    break;
            }
            return value;
        }
        /// <summary>
        /// 将DataRow 转成T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <param name="colcount"></param>
        /// <returns></returns>
        private static T ConvertDataRowToT<T>(DataRow dr, int colcount)
        {
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();
            T t = (T)Activator.CreateInstance(type);
            object objPacked = t;
            for (int j = 0; j < colcount && j < propertyInfos.Length; ++j)
            {
                PropertyInfo info = propertyInfos[j];
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                if (dr[j] == null)
                {
                    info.SetValue(t, "");
                }
                else if (dr[j] == System.DBNull.Value)
                {
                    info.SetValue(t, null);
                }
                else
                    info.SetValue(t, dr[j]);
            }
            t = (T)objPacked;
            return t;
        }
        /// <summary>
        /// 根据Type获取DataTable
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static DataTable SelectData(Type type)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                sb.Append(info.Name + ",");
            }
            sb.Remove(sb.Length - 1, 1);//移除 多余的 ","
            sb.Append(" FROM " + dataAttr.TableName+ " WHERE CompanyId= ");
            sb.Append(SystemConst.companyId);
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), CommandType.Text);
            return ds.Tables[0];
        }
        /// <summary>
        /// 根据T获取List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public static List<T> SelectData<T>()
        {
            List<T> tList = new List<T>();
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Type type = typeof(T);
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                sb.Append(info.Name + ",");
            }
            sb.Remove(sb.Length - 1, 1);//移除 多余的 ","
            sb.Append(" FROM " + dataAttr.TableName + " WHERE CompanyId= ");
            sb.Append(SystemConst.companyId);
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                T t = (T)Activator.CreateInstance(type);
                object objPacked = t;
                for (int j = 0; j < ds.Tables[0].Columns.Count && j < propertyInfos.Length; ++j)
                {
                    PropertyInfo info = propertyInfos[j];
                    DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                    if (infoAttr == null)
                        continue;
                    if (dt.Rows[i][j] == null)
                    {
                        info.SetValue(t, "");
                    }
                    else if (dt.Rows[i][j] == System.DBNull.Value)
                    {
                        info.SetValue(t, null);
                    }
                    else
                        info.SetValue(t, dt.Rows[i][j]);
                }
                t = (T)objPacked;
                tList.Add(t);
            }
            return tList;
        }
        //查会员名
        public static string GetMemberNameByID(string id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MName FROM  member ");
            //筛选条件
            sb.Append("WHERE MId  = @MId AND CompanyId=@CompanyId");
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@MId", MySqlDbType.String),
                                     new MySqlParameter("@CompanyId", MySqlDbType.Int32)
                                 };
            parameters[0].Value = id;
            parameters[1].Value = SystemConst.companyId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0].Rows[0][0].ToString();
        }
        public static string GetMemberIDByName(string name)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT MId FROM  member WHERE MName  = @MName"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@MName", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return ds.Tables[0].Rows[0][0].ToString();
        }
        public static double GetMemberBalance(string mId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql= "SELECT MBalance FROM  member WHERE MId  = @MId" + ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@MId", MySqlDbType.String)
                                 };
            parameters[0].Value = mId;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return Convert.ToDouble(ds.Tables[0].Rows[0][0]);
        }
        public static DataTable GetMemberRechargeByName(string name)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
           string sql="SELECT Id,MId,MName,Amount,UpdateTime,CompanyId FROM memberRecharge WHERE MName=@MName"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@MName", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取会员卡级别
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCardName()
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT cardName from card "+ANDCOMPANYID;
            DataSet ds = mySqlclient.GetDataSet(sql, CommandType.Text);
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取根据卡的类别获取会员
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static DataTable GetMemberGroupByLevel(string level)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT * FROM member WHERE CardName=@CardName "+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@CardName", MySqlDbType.String)
                                 };
            parameters[0].Value = level;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return ds.Tables[0];
        }
        public static DataTable GetPermission()
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT DISTINCT Name FROM Permission"+ANDCOMPANYID;
            DataSet ds = mySqlclient.GetDataSet(sql, CommandType.Text);
            return ds.Tables[0];
        }
        public static bool UserLogion(string userName, string psword)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT count(*) FROM UserRole WHERE Name=@Name and Psword=@Psword"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String),
                                     new MySqlParameter("@Psword", MySqlDbType.String)
                                 };
            parameters[0].Value = userName;
            parameters[1].Value = psword;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }
        public static bool IsUserExist(string userName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT count(*) FROM UserRole WHERE Name=@Name "+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = userName;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }
        public static DataTable GetPermission(string userName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT Role FROM UserRole WHERE Name=@Name"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = userName;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            string role = ds.Tables[0].Rows[0][0].ToString();


            ds.Clear();
            parameters.Clear();
            sql="SELECT ModeName FROM Permission WHERE Name=@Name"+ANDCOMPANYID;
            parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = role;
            ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return ds.Tables[0];
        }
        public static bool IsServerNameExist(string skillName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT count(*) FROM Skill WHERE SkillName=@SkillName "+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@skillName", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }
        public static bool CheckRoomExist(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT count(*) FROM Room WHERE RoomId=@RoomId "+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@RoomId", MySqlDbType.String)
                                 };
            parameters[0].Value = roomId;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }
         /// <summary>
         /// 根据性别找出员工
         /// </summary>
         /// <param name="sex"></param>
         /// <returns></returns>
        public static DataTable SelectStaffByGender(string sex)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT * FROM StaffInfo WHERE StaffSex=@StaffSex "+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffSex", MySqlDbType.String)
                                 };
            parameters[0].Value = sex;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return ds.Tables[0];
        }
        /// <summary>
        /// 根据ID找出员工名字
        /// </summary>
        /// <returns></returns>
        public static string SelectStaffNameByID(string staffId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
             string sql=@"SELECT StaffName FROM StaffInfo WHERE StaffId=@StaffId "+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffId", MySqlDbType.String)
                                 };
            parameters[0].Value = staffId;
           return mySqlclient.ExecuteScalar(sql,parameters) as string;
        }
        /// <summary>
        /// 根据名字找去员工ID
        /// </summary>
        /// <param name="staffName"></param>
        /// <returns></returns>
        public static string SelectSatffIDByName(string staffName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = @"SELECT StaffId FROM StaffInfo WHERE StaffName=@StaffName "+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffName", MySqlDbType.String)
                                 };
            parameters[0].Value = staffName;
            return mySqlclient.ExecuteScalar(sql, parameters) as string;
        }
        public static void GetSkillPriceByName<T>(string skillName, ref List<T> tList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Type type = typeof(T);
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            string sql=@"SELECT Id,SkillName,PriceType,PriceA,PriceB,PriceC,Remark
                              FROM  SkillPrice WHERE SkillName = @SkillName"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;

            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            PropertyInfo[] propertyInfos = type.GetProperties();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                T t = (T)Activator.CreateInstance(type);
                object objPacked = t;
                for (int j = 0; j < ds.Tables[0].Columns.Count && j < propertyInfos.Length; ++j)
                {
                    PropertyInfo info = propertyInfos[j];
                    DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                    if (infoAttr == null)
                        continue;
                    if (dt.Rows[i][j] != null)
                        info.SetValue(t, dt.Rows[i][j]);
                    else
                        info.SetValue(t, "");
                }
                t = (T)objPacked;
                tList.Add(t);
            }
        }
        //服务的具体价格
        public static double GetSkillPriceDetail(string skillName, int type, string priceType)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string priceT = "PriceA";
            switch (type)
            {
                case 0:
                    priceT = "PriceA"; break;
                case 1:
                    priceT = "PriceB"; break;
                case 2:
                    priceT = "PriceC"; break;
                default:
                    priceT = "PriceA"; break;
            }
            string sql="SELECT " + priceT + " FROM SkillPrice WHERE SkillName= @SkillName And PriceType=@PriceType"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String),
                                     new MySqlParameter("@PriceType", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            parameters[1].Value = priceType;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count <= 0)
                return 0;
            return Convert.ToDouble(ds.Tables[0].Rows[0][0]);
        }
        public static void GetSkillCommisionByName<T>(string skillName, ref List<T> tList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Type type = typeof(T);
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            string sql=@"SELECT Id,SkillName,StaffLevel,PriceA,PriceB,PriceC,Remark
                                FROM  SkillCommision WHERE SkillName = @SkillName"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;

            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            PropertyInfo[] propertyInfos = type.GetProperties();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                T t = (T)Activator.CreateInstance(type);
                object objPacked = t;
                for (int j = 0; j < ds.Tables[0].Columns.Count && j < propertyInfos.Length; ++j)
                {
                    PropertyInfo info = propertyInfos[j];
                    DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                    if (infoAttr == null)
                        continue;
                    if (dt.Rows[i][j] != null)
                        info.SetValue(t, dt.Rows[i][j]);
                    else
                        info.SetValue(t, "");
                }
                t = (T)objPacked;
                tList.Add(t);
            }
        }
        public static string GetSkillTime(int skillId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT ServerTime FROM Skill WHERE SkillId=@SkillId"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillId", MySqlDbType.Int32)
            };
            parameters[0].Value = skillId;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return ds.Tables[0].Rows[0][0].ToString();
        }
        public static bool IsExistSkillPrice(string skillName, string strType)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql=@"SELECT COUNT(Id) FROM SkillPrice WHERE SkillName=@SkillName and PriceType=@PriceType"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String),
                                     new MySqlParameter("@PriceType", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            parameters[1].Value = strType;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }
        public static double[] GetSkillPrice(string skillName, string strType)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="SELECT PriceA,PriceB,PriceC FROM SkillPrice WHERE SkillName=@SkillName and PriceType=@PriceType"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String),
                                     new MySqlParameter("@PriceType", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            parameters[1].Value = strType;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            double[] result = new double[3];
            if (dt.Rows.Count > 0)
            {
                result[0] = Convert.ToDouble(dt.Rows[0][0]);
                result[1] = Convert.ToDouble(dt.Rows[0][1]);
                result[2] = Convert.ToDouble(dt.Rows[0][2]);
            }
            return result;
        }
        public static List<T> GetTempOrderByRoomID<T>(int roomID)
        {
            List<T> tList = new List<T>();
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Type type = typeof(T);
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            StringBuilder sb = new StringBuilder();
            string sql = @"SELECT *  FROM  TempOrder WHERE RoomID = @RoomID"+ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@RoomID", MySqlDbType.Int32)
                                 };
            parameters[0].Value = roomID;

            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            PropertyInfo[] propertyInfos = type.GetProperties();
            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                T t = (T)Activator.CreateInstance(type);
                //object objPacked = t;
                for (int j = 0; j < ds.Tables[0].Columns.Count && j < propertyInfos.Length; ++j)
                {
                    PropertyInfo info = propertyInfos[j];
                    DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                    object value = dt.Rows[i][j];
                    if (infoAttr == null)
                        continue;
                    if (info.PropertyType.Name.Equals("String") && value == DBNull.Value)
                    {
                        info.SetValue(t, "");
                    }
                    else
                    {
                        if(value==DBNull.Value)
                            info.SetValue(t, null);
                        else
                            info.SetValue(t, value);
                    }
                      
                }
                //t = (T)objPacked;
                tList.Add(t);
            }
            return tList;
        }
        public static string GetStaffSexByID(string staffId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            string sql = @"SELECT StaffSex FROM StaffInfo WHERE StaffId=@StaffId " + ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffId", MySqlDbType.String)
                                 };
            parameters[0].Value = staffId;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count < 0)
                return "";
            else
                return dt.Rows[0][0].ToString();
        }
        public static DataTable GetPermissionByName(string name)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = @"SELECT ModeName FROM Permission WHERE Name=@Name " + ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            DataSet ds = mySqlclient.GetDataSet(sql, parameters, CommandType.Text);
            return ds.Tables[0];
        }
        public static List<T> SelectDataByID<T>(object id)
        {
            List<T> tList = new List<T>();
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Type type = typeof(T);
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            StringBuilder sb = new StringBuilder();
            PropertyInfo[] propertyInfos = type.GetProperties();
            string strkey = "";
            Type keyType = null;
            foreach (PropertyInfo info in propertyInfos)
            {
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr.Key)
                {
                    strkey = info.Name;
                    keyType = info.PropertyType;
                    break;
                }
            }
            sb.Append(" SELECT * FROM " + dataAttr.TableName + " WHERE " + strkey + "=@" + strkey);
            sb.Append(ANDCOMPANYID);
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@" + strkey, mySqlclient.ConvertDBType(keyType));
            parameter.Value = id;
            parameters.Add(parameter);

            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                T t = (T)Activator.CreateInstance(type);
                object objPacked = t;
                for (int j = 0; j < ds.Tables[0].Columns.Count && j < propertyInfos.Length; ++j)
                {
                    PropertyInfo info = propertyInfos[j];
                    DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                    if (infoAttr == null)
                        continue;
                    if (dt.Rows[i][j] == null)
                    {
                        info.SetValue(t, "");
                    }
                    else if (dt.Rows[i][j] == System.DBNull.Value)
                    {
                        info.SetValue(t, null);
                    }
                    else
                        info.SetValue(t, dt.Rows[i][j]);
                }
                t = (T)objPacked;
                tList.Add(t);
            }
            return tList;
        }
        public static T GetWorkStaffInfoByRoomId<T>(int roomId)
        {
            Type type = typeof(T);
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string strsql = "SELECT * FROM StaffWork WHERE RoomId =@RoomId "+ ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@RoomId", MySqlDbType.Int32)
                                 };
            parameters[0].Value = roomId;

            DataSet ds = mySqlclient.GetDataSet(strsql, parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            if (dt == null || dt.Rows.Count == 0)
                return default(T);
            return ConvertDataRowToT<T>(dt.Rows[0], dt.Columns.Count);
        }
        /// <summary>
        /// 根据房间号取房间
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public static T GetRoomByRoomId<T>(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = "select * from room where roomid=" + roomId+ANDCOMPANYID;
            DataSet ds = mySqlclient.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            if (dt == null || dt.Rows.Count == 0)
                return default(T);
            return ConvertDataRowToT<T>(dt.Rows[0], dt.Columns.Count);
        }
        public static string GetStaffIdByRoomId(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = "select staffId from staffwork where roomid=" + roomId+ ANDCOMPANYID;
            return mySqlclient.ExecuteScalar(sql, null) as string;
        }
        public static string GetStaffNameByRoomId(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = "select staffName from staffwork where roomid=" + roomId+ ANDCOMPANYID;
            return mySqlclient.ExecuteScalar(sql, null) as string;
        }
        /// <summary>
        /// 检查是否有重复的员工ID
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        public static bool IsRepeatedStaffId(string staffId)
        {
            string sql = "SELECT Count(StaffId) FROM StaffInfo Where StaffId='" + staffId + "'"+ ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count >0)
                return true;
            else
                return false;
        }
        public static bool IsRepeatedDepartmentId(int id)
        {
            string sql = "SELECT Count(id) FROM Department Where id='" + id + "'"+ ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 0)
                return true;
            else
                return false;
        }
        public static bool IsRepeatedLevelId(int id)
        {
            string sql = "SELECT Count(id) FROM Level Where id='" + id + "'"+ ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 0)
                return true;
            else
                return false;
        }
        public static bool IsRepeatedClassId(int id)
        {
            string sql = "SELECT Count(StaffClassID) FROM StaffClass Where StaffClassID='" + id + "'"+ ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 0)
                return true;
            else
                return false;
        }
        public static bool IsRepeatedMemberId(string id)
        {
            string sql = "SELECT Count(MId) FROM member Where MId='" + id + "'"+ ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 是否有重复的会员卡ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsRepeatedCardId(int id)
        {
            string sql = "SELECT Count(CardId) FROM Card Where CardId='" + id + "'"+ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 0)
                return true;
            else
                return false;
        }
        public static List<T> SelectStaffWorkRecordByName<T>(string name)
        {
            List<T> tList = new List<T>();
            string sql = "SELECT * FROM StaffWorkRecord WHERE StaffName =" + name+ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            DataSet ds = mySqlclient.GetDataSet(sql);
            if (ds.Tables[0] == null)
                return null;
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                T t= ConvertDataRowToT<T>(dr,ds.Tables[0].Columns.Count);
                tList.Add(t);
            }
            return tList;
        }
        /// <summary>
        /// 根据会员名称找会员消费记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mName"></param>
        /// <returns></returns>
        public static List<T> SelectMemberConsumeByName<T>(string mName)
        {
            List<T> tList = new List<T>();
            string sql = "SELECT * FROM MemberConsume WHERE MName =" + mName+ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            DataSet ds = mySqlclient.GetDataSet(sql);
            if (ds.Tables[0] == null)
                return null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                T t = ConvertDataRowToT<T>(dr, ds.Tables[0].Columns.Count);
                tList.Add(t);
            }
            return tList;
        }
        /// <summary>
        /// 根据会员ID找会员消费记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mId"></param>
        /// <returns></returns>
        public static List<T> SelectMemberConsumeByID<T>(string mId)
        {
            List<T> tList = new List<T>();
            string sql = "SELECT * FROM MemberConsume WHERE MId =" + mId+ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            DataSet ds = mySqlclient.GetDataSet(sql);
            if (ds.Tables[0] == null)
                return null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                T t = ConvertDataRowToT<T>(dr, ds.Tables[0].Columns.Count);
                tList.Add(t);
            }
            return tList;
        }
        /// <summary>
        /// 根据会员名称找会员充值记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mName"></param>
        /// <returns></returns>
        public static List<T> SelectMemberRechargeByName<T>(string mName)
        {
            List<T> tList = new List<T>();
            string sql = "SELECT * FROM memberRecharge WHERE MName =" + mName+ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            DataSet ds = mySqlclient.GetDataSet(sql);
            if (ds.Tables[0] == null)
                return null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                T t = ConvertDataRowToT<T>(dr, ds.Tables[0].Columns.Count);
                tList.Add(t);
            }
            return tList;
        }
        /// <summary>
        /// 根据会员ID找会员充值记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mId"></param>
        /// <returns></returns>
        public static List<T> SelectMemberRechargeByID<T>(string mId)
        {
            List<T> tList = new List<T>();
            string sql = "SELECT * FROM memberRecharge WHERE MId =" + mId+ANDCOMPANYID;
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            DataSet ds = mySqlclient.GetDataSet(sql);
            if (ds.Tables[0] == null)
                return null;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                T t = ConvertDataRowToT<T>(dr, ds.Tables[0].Columns.Count);
                tList.Add(t);
            }
            return tList;
        }
        /// <summary>
        /// 获取临时订单的该结束的时间
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public static DateTime GetTempOrderEndTime(int skillId,DateTime startTime)
        {
            DateTime endTime = new DateTime();
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = "select ServerTime from skill where SkillId="+skillId+ANDCOMPANYID; 
            string strTime = mySqlclient.ExecuteScalar(sql, null) as string;
            //"30分钟", "60分钟", "90分钟", "120分钟", "150分钟", "180分钟"
            endTime=TimeUtil.AddMinute(startTime,strTime);
            return endTime;
        }
    }
}
