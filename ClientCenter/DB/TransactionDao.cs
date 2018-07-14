using ClientCenter.Core;
using ClientCenter.Enity;
using System.Collections.Generic;

namespace ClientCenter.DB
{
    public class TransactionDao
    {
        private static MySqlClient mySqlclient;

        /// <summary>
        /// 发送订单
        /// </summary>
        /// <param name="staffworkVo"></param>
        /// <param name="orderVo"></param>
        /// <returns></returns>
        public static bool SendOrder(StaffWorkInfoVo staffworkVo, OrderInfoVo orderVo)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            List<string> strList = new List<string>();
            string para1 = mySqlclient.GenerateUpdateSql(staffworkVo);
            string para2 = mySqlclient.GenerateInsertSql(orderVo);
            strList.AddRange(new string[] { para1 , para2});
            return mySqlclient.ExecuteTransaction(strList);
        }

        public static bool SendTempOrder(List<TempOrderVo> tempOrderList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            List<string> parameterList = new List<string>();
            foreach(TempOrderVo vo in tempOrderList)
            {
                string sql= mySqlclient.GenerateInsertSql(vo);
                parameterList.Add(sql);
            }
            return mySqlclient.ExecuteTransaction(parameterList);
        }

        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="orderVo"></param>
        /// <param name="staffworkVo"></param>
        /// <param name="delOrderList"></param>
        /// <returns></returns>
        public static bool DealOrder(OrderInfoVo orderVo, StaffWorkInfoVo staffworkVo, List<DetailedOrderVo> delOrderList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            List<string> sqlList = new List<string>();
            string para1 = mySqlclient.GenerateUpdateSql(orderVo);
            string para2 = mySqlclient.GenerateUpdateSql(staffworkVo);
            string para3 = @"delete from TempOrder where RoomID= "+orderVo.RoomID;
            string para4 = @"update Room set roomStatus='空闲' where RoomId=" + orderVo.RoomID;
            
            sqlList.AddRange(new string[]{ para1, para2, para3, para4 });
            
            foreach (DetailedOrderVo vo in delOrderList)
            {
                string sql = mySqlclient.GenerateInsertSql(vo);
                sqlList.Add(sql);
            }
            //员工做工

            return mySqlclient.ExecuteTransaction(sqlList);
        }
    }
}
