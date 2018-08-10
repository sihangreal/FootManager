using ClientCenter.Core;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.DB
{
    public class ProcedureDao
    {
        private static MySqlClient mySqlclient;

        //会员注册
        public static int MemberRegister(List<object> infoList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("memberRegister ");//存储过程名称
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@v_mid", MySqlDbType.String),
                                     new MySqlParameter("@v_mname",MySqlDbType.String),
                                     new MySqlParameter("@v_cardName",MySqlDbType.String),
                                     new MySqlParameter("@v_phone",MySqlDbType.String),
                                     new MySqlParameter("@v_status",MySqlDbType.String),
                                     new MySqlParameter("@v_balance", MySqlDbType.Double),
                                     new MySqlParameter("@v_companyId",MySqlDbType.Int32)
                                 };
            parameters[0].Value = infoList[0];
            parameters[1].Value = infoList[1];
            parameters[2].Value = infoList[2];
            parameters[3].Value = infoList[3];
            parameters[4].Value = infoList[4];
            parameters[5].Value = infoList[5];
            parameters[6].Value = infoList[6];

            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters,CommandType.StoredProcedure);
        }

        //会员充值
        public static int MemberRechargeByID(string id, string name, int companyId, double amount)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("memberRechargePro ");//存储过程名称
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@v_mid", MySqlDbType.String),
                                     new MySqlParameter("@v_mname",MySqlDbType.String),
                                     new MySqlParameter("@v_companyId",MySqlDbType.Int32),
                                     new MySqlParameter("@v_amount", MySqlDbType.Double)
                                 };
            parameters[0].Value = id;
            parameters[1].Value = name;
            parameters[2].Value = companyId;
            parameters[3].Value = amount;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters,CommandType.StoredProcedure);
        }

        public static int StaffRegister(object[] infoArry)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            StringBuilder sb = new StringBuilder();
            sb.Append("staffRegister ");//存储过程名称
            List<MySqlParameter> parameters = new List<MySqlParameter>(){
                                     new MySqlParameter("@v_staffId", MySqlDbType.String),
                                     new MySqlParameter("@v_staffName",MySqlDbType.String),
                                     new MySqlParameter("@v_staffSex",MySqlDbType.String),
                                     new MySqlParameter("@v_staffPlace",MySqlDbType.String),
                                     new MySqlParameter("@v_staffLevel",MySqlDbType.String),
                                     new MySqlParameter("@v_department",MySqlDbType.String),
                                     new MySqlParameter("@v_idNumber",MySqlDbType.String),
                                     new MySqlParameter("@v_basicSalary",MySqlDbType.String),
                                     new MySqlParameter("@v_commision",MySqlDbType.Byte),
                                     new MySqlParameter("@v_companyId",MySqlDbType.Int32)
                                 };
            parameters[0].Value = infoArry[0];
            parameters[1].Value = infoArry[1];
            parameters[2].Value = infoArry[2];
            parameters[3].Value = infoArry[3];
            parameters[4].Value = infoArry[4];
            parameters[5].Value = infoArry[5];
            parameters[6].Value = infoArry[6];
            parameters[7].Value = infoArry[7];
            parameters[8].Value = infoArry[8];
            parameters[9].Value = SystemConst.companyId;
            return mySqlclient.ExecuteNonQuery(sb.ToString(), parameters, CommandType.StoredProcedure);
        }
    }
}
