using ClientCenter.Core;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace ClientCenter.DB
{
    public class UpdateDao
    {
        private static MySqlClient mySqlclient;

        //会员挂失
        public static int MemberLossByID(string id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE  member  SET  MStatus= @MStatus ");
            //筛选条件
            sb.Append("WHERE MId  = @MId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@MStatus",MySqlDbType.String),
                                     new MySqlParameter("@MId", MySqlDbType.String)
                                 };
            parameters[0].Value = "挂失";
            parameters[1].Value = id;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters,CommandType.Text);
        }

        public static int MemberActiveByID(string id)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE  member  SET  MStatus= @MStatus ");
            //筛选条件
            sb.Append("WHERE MId  = @MId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@MStatus",MySqlDbType.String),
                                     new MySqlParameter("@MId", MySqlDbType.String)
                                 };
            parameters[0].Value = "正常";
            parameters[1].Value = id;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters,CommandType.Text);
        }

        public static int UpdateCardByID(int cardId, string cardName, double discount)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE  Card  SET  CardName= @CardName, DisCount=@DisCount ");
            //筛选条件
            sb.Append("WHERE CardId  = @CardId ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@CardName",MySqlDbType.String),
                                     new MySqlParameter("@DisCount", MySqlDbType.Double),
                                     new MySqlParameter("@CardId",MySqlDbType.Int32)
                                 };
            parameters[0].Value = cardName;
            parameters[1].Value = discount;
            parameters[2].Value = cardId;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int UpdateByID(object data)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Type type = data.GetType();
            DataAttr dataAttr = (DataAttr)type.GetCustomAttribute(typeof(DataAttr), false);
            StringBuilder sb = new StringBuilder();
            string key="";
            object keyValue=null;
            Type keyType=null;
            sb.Append("UPDATE  ");
            sb.Append(dataAttr.TableName);
            sb.Append(" Set ");
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo info in propertyInfos)
            {
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                if (infoAttr.Key)
                {
                    key = info.Name;
                    keyValue = info.GetValue(data);
                    keyType = info.PropertyType;
                }
                else
                {
                    sb.Append(info.Name + " =@"+info.Name+" ,");
                }
            }
            sb.Remove(sb.Length - 1, 1);//移除 多余的 ","
            sb.Append("Where "+key+" =@"+key);

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            for (int i = 0; i < propertyInfos.Length; ++i)
            {
                PropertyInfo info = propertyInfos[i];
                DataAttr infoAttr = (DataAttr)info.GetCustomAttribute(typeof(DataAttr), false);
                if (infoAttr == null)
                    continue;
                if (!infoAttr.Key)
                {
                    string strPara = "@" + info.Name;
                    MySqlParameter parameter = new MySqlParameter(strPara, mySqlclient.ConvertDBType(info.PropertyType));
                    parameter.Value = info.GetValue(data);
                    parameters.Add(parameter);
                }
            }
            MySqlParameter keyParameter = new MySqlParameter("@" + key, mySqlclient.ConvertDBType(keyType));
            keyParameter.Value = keyValue;
            parameters.Add(keyParameter);
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int StaffPaiZhong(int staffId)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE  StaffWork  SET  StaffStatus= @StaffStatus, DisCount=@DisCount ");
            //筛选条件
            sb.Append("WHERE StaffID  = @StaffID ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffID",MySqlDbType.String),
                                     new MySqlParameter("@StaffStatus", MySqlDbType.String),
                                     new MySqlParameter("@CardId",MySqlDbType.Int32)
                                 };
            parameters[0].Value = staffId;
            //parameters[1].Value = discount;
            //parameters[2].Value = cardId;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }

        public static int StaffWorkOrRest(string staffId,string status)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE  StaffWork  SET  StaffStatus= @StaffStatus");
            //筛选条件
            sb.Append("WHERE StaffID  = @StaffID ");
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@StaffID",MySqlDbType.String),
                                     new MySqlParameter("@StaffStatus", MySqlDbType.String)
                                 };
            parameters[0].Value = staffId;
            parameters[1].Value = status;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.Text);
        }
    }
}
