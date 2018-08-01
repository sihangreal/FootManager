﻿using ClientCenter.Core;
using ClientCenter.Enity;
using MySql.Data.MySqlClient;
using System;
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
                sql = "update room set RoomStatus='空闲' where RoomId=" + vo.RoomID;
                parameterList.Add(sql);
                sql = "update staffwork set StaffStatus='工作中' where StaffID='" + vo.StaffID + "'";
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

        public static bool DealOrder(OrderInfoVo orderVo,List<TempOrderVo> tempOrderList,string priceType)
        {
            if (mySqlclient == null)
                mySqlclient = MySqlClient.GetMySqlClient();
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connection = mySqlclient.GetConnect();
            MySqlTransaction transaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = transaction;
            connection.Open();

            string sql = mySqlclient.GenerateInsertSql(orderVo);
            try
            {
                command.CommandText = sql;
                mySqlclient.ExecuteNonQuery(command);
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                return false;
            }

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
                sql = mySqlclient.GenerateInsertSql(detVo);
                try
                {
                    command.CommandText = sql;
                    mySqlclient.ExecuteNonQuery(command);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }

            foreach (TempOrderVo tempVo in tempOrderList)
            {
                sql = @"update StaffWork set StaffStatus='空闲',RoomId=null,RoomName='' where StaffID='"+ tempVo.StaffID+"'";
                try
                {
                    command.CommandText = sql;
                    mySqlclient.ExecuteNonQuery(command);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }

            foreach(TempOrderVo tempVo in tempOrderList)
            {
                StaffWorkRecordVo recordVo = new StaffWorkRecordVo();
                recordVo.ID = GenrateIDUtil.GenerateWorkRecordID();
                recordVo.StaffId = tempVo.StaffID;
                recordVo.StaffName = SelectDao.SelectStaffNameByID(tempVo.StaffID);
                recordVo.OrderID = orderVo.OrderID;
                recordVo.Amount = orderVo.TotalPrice;
                recordVo.WorkTime = DateTime.Now;
                sql = mySqlclient.GenerateInsertSql(recordVo);
                try
                {
                    command.CommandText = sql;
                    mySqlclient.ExecuteNonQuery(command);
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
