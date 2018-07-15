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

        public static int DelMemberByID(string id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  member ");
            //筛选条件
            sb.Append("WHERE MId  = @MId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@MId", MySqlDbType.String)
                                 };
            parameters[0].Value = id;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int DelSkillByID(int id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  Skill ");
            //筛选条件
            sb.Append("WHERE SkillId  = @SkillId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillId", MySqlDbType.Int32)
                                 };
            parameters[0].Value = id;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int DelSeverByName(string serverName,string skillName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  CustomServer ");
            //筛选条件
            sb.Append("WHERE ServerName  = @ServerName AND SkillName=@SkillName");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@ServerName", MySqlDbType.String),
                                     new MySqlParameter("@SkillName", MySqlDbType.String)
                                 };
            parameters[0].Value = serverName;
            parameters[1].Value = skillName;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int DelDepartmentByID(int id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  Department ");
            //筛选条件
            sb.Append("WHERE id  = @id ");
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@id", MySqlDbType.Int32)
                                 };
            parameters[0].Value = id;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int DelCardByID(int cardId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  Card ");
            //筛选条件
            sb.Append("WHERE cardId  = @cardId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@cardId", MySqlDbType.Int32)
                                 };
            parameters[0].Value = cardId;
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
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@StaffId", MySqlDbType.String)
                                 };
            parameters[0].Value = staffId;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int DelStaffLevelByID(int id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  Level ");
            //筛选条件
            sb.Append("WHERE Id  = @Id ");
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@Id", MySqlDbType.Int32)
                                 };
            parameters[0].Value = id;
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
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  Permission WHERE Name  = @Name");
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int DeleteStaffQueue()
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE  FROM  StaffQueue");
            return mySqlclient.ExecuteNonQuery(sb.ToString(),CommandType.Text);
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
            string sql = @"DELETE  FROM  temporder where RoomId=" + roomId;
            return mySqlclient.ExecuteNonQuery(sql, CommandType.Text);
        }
    }
}
