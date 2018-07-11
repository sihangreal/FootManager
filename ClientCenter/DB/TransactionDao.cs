using ClientCenter.Enity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.DB
{
    public class TransactionDao
    {
        private static MySqlClient mySqlclient;

        public static bool SendStartOrder(StaffWorkInfoVo staffworkVo, OrderInfoVo orderVo)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Dictionary<string, List<MySqlParameter>> transactionDic = new Dictionary<string, List<MySqlParameter>>();
            mySqlclient.GenerateInsertSql(staffworkVo,ref transactionDic);
            mySqlclient.GenerateInsertSql(orderVo, ref transactionDic);
            return mySqlclient.ExecuteTransaction(transactionDic);
        }

        public static bool SendTempOrder(List<TempOrderVo> tempOrderList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            Dictionary<string, List<MySqlParameter>> transactionDic = new Dictionary<string, List<MySqlParameter>>();
            foreach(TempOrderVo vo in tempOrderList)
            {
                mySqlclient.GenerateInsertSql(vo, ref transactionDic);
            }
            return mySqlclient.ExecuteTransaction(transactionDic);
        }
    }
}
