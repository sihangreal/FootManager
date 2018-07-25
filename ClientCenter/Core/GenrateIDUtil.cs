using ClientCenter.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientCenter.Core
{
   public  class GenrateIDUtil
    {
        private static MySqlClient mySqlclient;
        private static Mutex mutex = new Mutex();
        private static object _lock = new object();
        public static Int64  _count = 0;


        public static string GenerateOrderID()
        {
            mutex.WaitOne();
            string orderId=default(string);
            Random ran = new Random();
            orderId = "P" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(1000, 9999).ToString();
            string sql = "SELECT Count(OrderID) FROM OrderInfo Where OrderID='" + orderId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count >0)
                GenerateOrderID();
            mutex.ReleaseMutex();
            return orderId;
        }

        public static string GenerateMemberID()
        {
            mutex.WaitOne();
            string memberId = default(string);
            Random ran = new Random();
            memberId = "M" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(100, 999).ToString();
            string sql = "SELECT Count(MId) FROM member Where MId='" + memberId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count >0)
                GenerateMemberID();
            mutex.ReleaseMutex();
            return memberId;
        }

        public static string GenerateDetailOrderID()
        {
            mutex.WaitOne();
            string detailId = default(string);
            _count++;
            string sql = "SELECT Max(DetailID) FROM DetailedOrder";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            detailId = mySqlclient.ExecuteScalar(sql,null) as string;
            string temp = detailId.Substring(2, 8);
            string comp = DateTime.Today.Date.ToString("yyyyMMdd");
            if(temp.Equals(comp))
            {
                string tmp= detailId.Substring(2);
                detailId = "DP"+(Convert.ToInt64(tmp) + _count);
            }
           else
            {
                detailId = "DP" + DateTime.Now.ToString("yyyyMMdd") + _count.ToString("00000");
            }
            mutex.ReleaseMutex();
            return detailId;
        }

        public static string GenerateStaffID()
        {
            mutex.WaitOne();
            string staffId = default(string);
            Random ran = new Random();
            staffId = "S" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(100, 999).ToString();
            string sql = "SELECT Count(StaffId) FROM StaffInfo Where StaffId='" + staffId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 0)
                GenerateStaffID();
            mutex.ReleaseMutex();
            return staffId;
        }

        public static string GenerateConsumeID()
        {
            mutex.WaitOne();
            string consumeId = default(string);
            Random ran = new Random();
            consumeId = "C" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(100, 999).ToString();
            string sql = "SELECT Count(ID) FROM MemberConsume Where ID='" + consumeId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 0)
                GenerateConsumeID();
            mutex.ReleaseMutex();
            return consumeId;
        }

        public static string GenerateWorkRecordID()
        {
            mutex.WaitOne();
            string recordId = default(string);
            Random ran = new Random();
            recordId = "R" + DateTime.Now.ToString("yyyyMMdd") + ran.Next(100, 999).ToString();
            string sql = "SELECT Count(ID) FROM StaffWorkRecord Where ID='" + recordId + "'";
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            int count = Convert.ToInt32(mySqlclient.ExecuteScalar(sql, null));
            if (count > 0)
                GenerateWorkRecordID();
            mutex.ReleaseMutex();
            return recordId;
        }
    }
}
