using ClientCenter.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Core
{
   public  class GenrateIDUtil
    {
        private static MySqlClient mySqlclient;

        public static string GenerateOrderID()
        {
            string orderId=default(string);
            Random ran = new Random();
            orderId = "P" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(1000, 9999).ToString();
            string sql = "SELECT Count(OrderID) FROM OrderInfo Where OrderID='" + orderId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 1)
                GenerateOrderID();
            return orderId;
        }

        public static string GenerateMemberID()
        {
            string memberId = default(string);
            Random ran = new Random();
            memberId = "M" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(100, 999).ToString();
            string sql = "SELECT Count(MId) FROM member Where MId='" + memberId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 1)
                GenerateMemberID();
            return memberId;
        }

        public static string GenerateDetailOrderID()
        {
            string detailId = default(string);
            Random ran = new Random();
            detailId = "DP" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(10000, 99999).ToString();
            string sql = "SELECT Count(DetailID) FROM DetailedOrder Where DetailID='" + detailId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 1)
                GenerateDetailOrderID();
            return detailId;
        }

        public static string GenerateStaffID()
        {
            string staffId = default(string);
            Random ran = new Random();
            staffId = "S" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(100, 999).ToString();
            string sql = "SELECT Count(StaffId) FROM StaffInfo Where StaffId='" + staffId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 1)
                GenerateStaffID();
            return staffId;
        }

        public static string GenerateConsumeID()
        {
            string consumeId = default(string);
            Random ran = new Random();
            consumeId = "C" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(100, 999).ToString();
            string sql = "SELECT Count(ID) FROM MemberConsume Where ID='" + consumeId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 1)
                GenerateConsumeID();
            return consumeId;
        }

        public static string GenerateWorkRecordID()
        {
            string recordId = default(string);
            Random ran = new Random();
            recordId = "R" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(100, 999).ToString();
            string sql = "SELECT Count(ID) FROM StaffWorkRecord Where ID='" + recordId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 1)
                GenerateWorkRecordID();
            return recordId;
        }
    }
}
