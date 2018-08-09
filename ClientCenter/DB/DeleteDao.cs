using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using ClientCenter.Core;
using System.Reflection;

namespace ClientCenter.DB
{
    public class DeleteDao
    {
        private static MySqlClient mySqlclient;
        private static string ANDCOMPANYID = " AND CompanyId = " + SystemConst.companyId;
        private static string WHERECOMPANYID = " WHERE CompanyId = " + SystemConst.companyId;

        public static int DelSkillByID(int id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  Skill ");
            //筛选条件
            sb.Append("WHERE SkillId  = @SkillId ");
            sb.Append(ANDCOMPANYID);
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillId", MySqlDbType.Int32)
                                 };
            parameters[0].Value = id;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int DelRoomByID(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  Room ");
            //筛选条件
            sb.Append("WHERE RoomId  = @RoomId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@RoomId", MySqlDbType.Int32)
                                 };
            sb.Append(ANDCOMPANYID);
            parameters[0].Value = roomId;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int DelStaffInfoByID(string staffId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  StaffInfo ");
            //筛选条件
            sb.Append("WHERE StaffId  = @StaffId ");
            sb.Append(ANDCOMPANYID);
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@StaffId", MySqlDbType.String)
                                 };
            parameters[0].Value = staffId;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }
        public static int DeleteByID(object id,Type type)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            StringBuilder sb = new StringBuilder();
            string key = "";
            Type keyType = null;
            sb.Append("DELETE FROM ");
            sb.Append(dataAttr.TableName);
            sb.Append(" WHERE ");
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                if (infoAttr.Key)
                {
                    key = info.Name;
                    keyType = info.PropertyType;
                    sb.Append(key + " =@"+ key);
                    break;
                }
            }
            sb.Append(ANDCOMPANYID);
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            MySqlParameter parameter = new MySqlParameter("@"+key, mySqlclient.ConvertDBType(keyType));
            parameter.Value = id;
            parameters.Add(parameter);
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }
        /// <summary>
        ///根据名字删除权限
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int DelPermissionByName(string name)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = "DELETE  FROM  Permission WHERE Name  = @Name" + ANDCOMPANYID;
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            return mySqlclient.ExecuteNonQuery(sql, parameters, CommandType.Text);
        }
        public static int DeleteStaffQueue()
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql="DELETE  FROM  StaffQueue"+ WHERECOMPANYID;
            return mySqlclient.ExecuteNonQuery(sql, CommandType.Text);
        }
        /// <summary>
        /// 结账的时候根据房间号删除临时订单
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public static int DeleteTempOrderByRoomId(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = @"DELETE  FROM  temporder where RoomId=" + roomId+ ANDCOMPANYID;
            return mySqlclient.ExecuteNonQuery(sql, CommandType.Text);
        }

    }
}
