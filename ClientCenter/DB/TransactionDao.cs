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
            List<TransactionParameter> parameterList = new List<TransactionParameter>();
            TransactionParameter para1= mySqlclient.GenerateUpdateSql(staffworkVo);
            TransactionParameter para2=mySqlclient.GenerateInsertSql(orderVo);
            parameterList.Add(para1);
            parameterList.Add(para2);
            return mySqlclient.ExecuteTransaction(parameterList);
        }

        public static bool SendTempOrder(List<TempOrderVo> tempOrderList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            List<TransactionParameter> parameterList = new List<TransactionParameter>();
            foreach(TempOrderVo vo in tempOrderList)
            {
                TransactionParameter para= mySqlclient.GenerateInsertSql(vo);
                parameterList.Add(para);
            }
            return mySqlclient.ExecuteTransaction(parameterList);
        }
    }
}
