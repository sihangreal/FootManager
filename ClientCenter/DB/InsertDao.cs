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
    public class InsertDao
    {
        private static MySqlClient mySqlclient;

        private static MySqlDbType ConvertDBType(Type type)
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
            }
            return dbType;
        }

        public static int InsertData(object data, Type type)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
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
                if(infoAttr.Bquery)
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
                if(infoAttr.Bquery)
                {
                    sb.Append("@" + info.Name + ",");
                }
            }
            sb.Remove(sb.Length - 1, 1);//移除 多余的 ","
            sb.Append(")");

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            for (int i=0;i< propertyInfos.Length;++i)
            {
                PropertyInfo info = propertyInfos[i];
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                if (infoAttr.Bquery)
                {
                    string strPara = "@" + info.Name;
                    MySqlParameter parameter= new MySqlParameter(strPara, ConvertDBType(info.PropertyType));
                    parameter.Value = info.GetValue(data);
                    parameters.Add(parameter);
                }
            }
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static object InsertDataRetrunID(object data)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Type type = data.GetType();
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
            sb.Append(") ; select @@identity");
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

            object id = mySqlclient.ExecuteScalar(sb.ToString(), parameters.ToList(), CommandType.Text);
            return id;
        }
        public static int SendOrder(OrderInfoVo orderVo,List<DetailedOrderVo> detailedVoList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO OrderInfo(OrderID, RoomID,StaffName,StartTime,EndTime,Price) ");
            sb.Append(" VALUES(@OrderID,@RoomID,@StaffName,@StartTime,@EndTime,@Price); select @@identity");
            MySqlParameter[] parameters = new MySqlParameter[6];
            parameters[0] = new MySqlParameter("@OrderID", orderVo.OrderID);
            parameters[1] = new MySqlParameter("@RoomID", orderVo.RoomID);
            parameters[2] = new MySqlParameter("@StaffName", orderVo.StaffName);
            parameters[3] = new MySqlParameter("@StartTime", orderVo.StartTime);
            parameters[4] = new MySqlParameter("@EndTime", orderVo.EndTime);
            parameters[5] = new MySqlParameter("@Price", orderVo.Price);

            object orderID = mySqlclient.ExecuteScalar(sb.ToString(), parameters.ToList(), CommandType.Text);
            foreach (DetailedOrderVo detailedVo in detailedVoList)
            {
                detailedVo.OrderID = Convert.ToInt32(orderID);
                if (InsertData(detailedVo, typeof(DetailedOrderVo)) <= 0)
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
