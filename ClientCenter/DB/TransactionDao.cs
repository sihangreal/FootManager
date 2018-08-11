using ClientCenter.Core;
using ClientCenter.Enity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ClientCenter.DB
{
    public class TransactionDao
    {
        private static MySqlClient mySqlclient;
        private static string ANDCOMPANYID = " AND CompanyId = " + SystemConst.companyId;
        private static string WHERECOMPANYID = " WHERE CompanyId = " + SystemConst.companyId;

        /// <summary>
        /// 发送临时订单
        /// </summary>
        /// <param name="tempOrderList"></param>
        /// <returns></returns>
        public static bool SendTempOrder(List<TempOrderVo> tempOrderList)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            List<string> parameterList = new List<string>();
            foreach(TempOrderVo vo in tempOrderList)
            {
                string sql= mySqlclient.GenerateInsertSql(vo);
                parameterList.Add(sql);
                sql = "update room set RoomStatus='占用' where RoomId=" + vo.RoomID+ ANDCOMPANYID;
                parameterList.Add(sql);
                sql = "update staffwork set StaffStatus='工作中' , RoomId="+vo.RoomID+" where StaffID='" + vo.StaffID + "'"+ ANDCOMPANYID;
                parameterList.Add(sql);

            }
            return mySqlclient.ExecuteTransaction(parameterList);
        }


        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="orderVo"></param>
        /// <param name="tempOrderList"></param>
        /// <param name="priceType"></param>
        /// <returns></returns>
        public static bool DealOrder(OrderInfoVo orderVo,List<TempOrderVo> tempOrderList,string priceType)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = mySqlclient.GetConnect();

            connection.Open();
            MySqlTransaction transaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = transaction;
            //订单
            string sql = mySqlclient.GenerateInsertSql(orderVo);
            try
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                return false;
            }
            //详细订单
            foreach(TempOrderVo tempVo in tempOrderList)
            {
                DetailedOrderVo detVo = new DetailedOrderVo();
                detVo.DetailID = GenrateIDUtil.GenerateDetailOrderID();
                detVo.OrderID = orderVo.OrderID;
                detVo.SkillId = tempVo.SkillId;
                detVo.Price = SelectDao.GetSkillPriceDetail(tempVo.SkillName, tempVo.WorkType, priceType);
                double gstPrice = (detVo.Price * 6) / 106;
                detVo.Tax = Math.Round(gstPrice, 2, MidpointRounding.AwayFromZero);
                detVo.TotalPrice = detVo.Price + detVo.Tax;
                detVo.CompanyId = SystemConst.companyId;
                sql = mySqlclient.GenerateInsertSql(detVo);
                try
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            //员工工作状态
            foreach (TempOrderVo tempVo in tempOrderList)
            {
                sql = @"update StaffWork set StaffStatus='空闲',RoomId=null,RoomName='' where StaffID='"+ tempVo.StaffID+"'"+ANDCOMPANYID;
                try
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            //员工做工记录
            foreach(TempOrderVo tempVo in tempOrderList)
            {
                StaffWorkRecordVo recordVo = new StaffWorkRecordVo();
                recordVo.ID = GenrateIDUtil.GenerateWorkRecordID();
                recordVo.StaffId = tempVo.StaffID;
                recordVo.StaffName = SelectDao.SelectStaffNameByID(tempVo.StaffID);
                recordVo.OrderID = orderVo.OrderID;
                recordVo.Amount = orderVo.TotalPrice;
                recordVo.WorkTime = DateTime.Now;
                recordVo.CompanyId=SystemConst.companyId; 
                sql = mySqlclient.GenerateInsertSql(recordVo);
                try
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            //房间状态
            foreach (TempOrderVo tempVo in tempOrderList)
            {
                sql = @"update Room set roomStatus='空闲' where RoomId=" + tempVo.RoomID + ANDCOMPANYID;
                try
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
                transaction.Commit();
            connection.Close();
            return true;
        }
    }
}
