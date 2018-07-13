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
            sb.Append(" FROM " + dataAttr.TableName);
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), CommandType.Text);
            return ds.Tables[0];
        }
        public static void SelectData<T>(ref List<T> tList)
        {
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
            sb.Append(" FROM " + dataAttr.TableName);
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
        }

        //查会员名
        public static string GetMemberNameByID(string id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MName FROM  member ");
            //筛选条件
            sb.Append("WHERE MId  = @MId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>() {
                                     new MySqlParameter("@MId", MySqlDbType.String)
                                 };
            parameters[0].Value = id;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public static string GetMemberIDByName(string name)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MId FROM  member ");
            //筛选条件
            sb.Append("WHERE MName  = @MName ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@MName", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public static double GetMemberBalance(string mId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT MBalance FROM  member ");
            //筛选条件
            sb.Append("WHERE MId  = @MId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@MId", MySqlDbType.String)
                                 };
            parameters[0].Value = mId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return Convert.ToDouble(ds.Tables[0].Rows[0][0]);
        }

        public static DataTable GetMemberRechargeByName(string name)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id,MId,MName,Amount,UpdateTime,CompanyId FROM memberRecharge WHERE MName=@MName");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@MName", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static void SelectData<T>()
        {
            throw new NotImplementedException();
        }

        public static DataTable GetCardLevel()
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT cardName from card ");
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), CommandType.Text);
            return ds.Tables[0];
        }

        public static DataTable GetMemberGroupByLevel(string level)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM member WHERE CardName=@CardName ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@CardName", MySqlDbType.String)
                                 };
            parameters[0].Value = level;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static List<string> GetSkillByStaffID(string staffId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT skillName FROM skill WHERE skillId in (SELECT skillId from staffSkill where staffId=@staffId)");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@staffId", MySqlDbType.String)
                                 };
            parameters[0].Value = staffId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            List<string> skillNameList = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string name = dr[0].ToString();
                skillNameList.Add(name);
            }
            return skillNameList;
        }

        public static DataTable GetServerShipByID(int serverId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT skillId,skillName FROM skill WHERE skillId in (SELECT skillId from ServerSkillShip where ServerId=@serverId)");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@serverId", MySqlDbType.String)
                                 };
            parameters[0].Value = serverId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }
        //根据服务名
        public static DataTable GetServerByName(string serverName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ServerId, ServerName,Price,ServerTime FROM CustomServer WHERE ServerName=@ServerName");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@ServerName", MySqlDbType.String)
                                 };
            parameters[0].Value = serverName;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static object GetSkillIdByName(string skillName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT SkillId FROM Skill WHERE SkillName=@SkillName");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0].Rows[0][0];
        }

        public static DataTable GetPermission()
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT DISTINCT Name FROM Permission");
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), CommandType.Text);
            return ds.Tables[0];
        }

        public static bool UserLogion(string userName, string psword)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) FROM UserRole WHERE Name=@Name and Psword=@Psword");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String),
                                     new MySqlParameter("@Psword", MySqlDbType.String)
                                 };
            parameters[0].Value = userName;
            parameters[1].Value = psword;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }

        public static bool IsUserExist(string userName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) FROM UserRole WHERE Name=@Name ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = userName;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }

        public static bool IsMemberExist(string mId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) FROM member WHERE mId=@mId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@mId", MySqlDbType.String)
                                 };
            parameters[0].Value = mId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }
        public static DataTable GetPermission(string userName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Role FROM UserRole WHERE Name=@Name");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = userName;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            string role = ds.Tables[0].Rows[0][0].ToString();

            sb.Clear();
            ds.Clear();
            parameters.Clear();
            sb.Append("SELECT ModeName FROM Permission WHERE Name=@Name");
            parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = role;
            ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static bool IsServerNameExist(string skillName)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) FROM Skill WHERE SkillName=@SkillName ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@skillName", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }

        public static bool CheckRoomExist(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT count(*) FROM Room WHERE RoomId=@RoomId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@RoomId", MySqlDbType.String)
                                 };
            parameters[0].Value = roomId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }

        public static DataTable SelectCardByID(int cardId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM Card WHERE CardId=@CardId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@CardId", MySqlDbType.Int32)
                                 };
            parameters[0].Value = cardId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static DataTable SelectStaffByName(string name)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM StaffInfo WHERE StaffName=@StaffName ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffName", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static DataTable SelectStaffByGender(string sex)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM StaffInfo WHERE StaffSex=@StaffSex ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffSex", MySqlDbType.String)
                                 };
            parameters[0].Value = sex;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static DataTable SelectStaffWorkByName(string name)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM StaffWork WHERE StaffName=@StaffName ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffName", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static DataTable SelectStaffWorkByStatus(string status)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM StaffWork WHERE StaffStatus=@StaffStatus ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffStatus", MySqlDbType.String)
                                 };
            parameters[0].Value = status;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }

        public static DataTable SelectStaffWorkByLevel(string level)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM StaffWork WHERE StaffLevel=@StaffLevel ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffLevel", MySqlDbType.String)
                                 };
            parameters[0].Value = level;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0];
        }
        public static void GetSkillPriceByName<T>(string skillName, ref List<T> tList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Type type = typeof(T);
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id,SkillName,PriceType,PriceA,PriceB,PriceC,Remark");
            sb.Append(" FROM  SkillPrice WHERE SkillName = @SkillName");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;

            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
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
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT " + priceT + " FROM SkillPrice WHERE SkillName= @SkillName And PriceType=@PriceType");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String),
                                     new MySqlParameter("@PriceType", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            parameters[1].Value = priceType;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
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
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Id,SkillName,StaffLevel,PriceA,PriceB,PriceC,Remark");
            sb.Append(" FROM  SkillCommision WHERE SkillName = @SkillName");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;

            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
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
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ServerTime FROM Skill WHERE SkillId=@SkillId");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillId", MySqlDbType.Int32)
            };
            parameters[0].Value = skillId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return ds.Tables[0].Rows[0][0].ToString();
        }

        public static bool IsExistSkillPrice(string skillName, string strType)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(Id) FROM SkillPrice WHERE SkillName=@SkillName and PriceType=@PriceType");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String),
                                     new MySqlParameter("@PriceType", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            parameters[1].Value = strType;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }

        public static double[] GetSkillPrice(string skillName, string strType)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT PriceA,PriceB,PriceC FROM SkillPrice WHERE SkillName=@SkillName and PriceType=@PriceType");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@SkillName", MySqlDbType.String),
                                     new MySqlParameter("@PriceType", MySqlDbType.String)
                                 };
            parameters[0].Value = skillName;
            parameters[1].Value = strType;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
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
            sb.Append("SELECT *");
            sb.Append(" FROM  TempOrder WHERE RoomID = @RoomID");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@RoomID", MySqlDbType.Int32)
                                 };
            parameters[0].Value = roomID;

            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
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
                    if (info.PropertyType.Name.Equals("String")&& dt.Rows[i][j] == DBNull.Value)
                    {
                        info.SetValue(t, "");
                    }
                    else
                        info.SetValue(t, dt.Rows[i][j]);
                }
                t = (T)objPacked;
                tList.Add(t);
            }
            return tList;
        }

        public static string GetStaffSexByID(string staffId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT StaffSex FROM StaffInfo WHERE StaffId=@StaffId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffId", MySqlDbType.String)
                                 };
            parameters[0].Value = staffId;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
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
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ModeName FROM Permission WHERE Name=@Name ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@Name", MySqlDbType.String)
                                 };
            parameters[0].Value = name;
            DataSet ds = mySqlclient.GetDataSet(sb.ToString(), parameters, CommandType.Text);
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
            sb.Append(" SELECT * FROM " + dataAttr.TableName + " WHERE " + strkey + "@" + strkey);

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
            string strsql = "SELECT * FROM StaffWork WHERE RoomId =@RoomId ";
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@RoomId", MySqlDbType.Int32)
                                 };
            parameters[0].Value = roomId;

            DataSet ds = mySqlclient.GetDataSet(strsql, parameters, CommandType.Text);
            DataTable dt = ds.Tables[0];
            if (dt == null||dt.Rows.Count==0)
                return default(T);
            DataRow dr = dt.Rows[0];
            PropertyInfo[] propertyInfos = type.GetProperties();
            T t = (T)Activator.CreateInstance(type);
            object objPacked = t;
            for (int j = 0; j < ds.Tables[0].Columns.Count && j < propertyInfos.Length; ++j)
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

        public static string CreateOrderHandle()
        {
            string orderId = string.Empty;
            Random ran = new Random();
            orderId= "P" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(1000, 9999).ToString();
            string sql = "SELECT Count(OrderID) FROM OrderInfo Where OrderID='" + orderId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count =Convert.ToInt32( mySqlclient.ExecuteScalar(sql,null) );
            if (count > 1)
                CreateOrderHandle();
            return orderId;
        }

        public static string GetOrderByRoomId(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = "select OrderId from staffwork where roomid=" + roomId;
           return mySqlclient.ExecuteScalar(sql, null) as string;
        }

        public static string GetStaffIdByRoomId(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = "select staffId from staffwork where roomid=" + roomId;
            return mySqlclient.ExecuteScalar(sql, null) as string;
        }

        public static string GetStaffNameByRoomId(int roomId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            string sql = "select staffName from staffwork where roomid=" + roomId;
            return mySqlclient.ExecuteScalar(sql, null) as string;
        }
    }
}
