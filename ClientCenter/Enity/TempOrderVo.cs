﻿using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCenter.GridViews;

namespace ClientCenter.Enity
{
    [DataAttr("TempOrder")]
    public class TempOrderVo
    {
        private int id;
        [ColumnAttr("编号", false)]
        [DataAttr(false, true)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int roomID;
        [ColumnAttr("房间编号", true)]
        [DataAttr(true)]
        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        private int skillId;
        [ColumnAttr("项目ID", false)]
        [DataAttr(true)]
        public int SkillId
        {
            get { return skillId; }
            set { skillId = value; }
        }
        private string skillName;
        [ColumnAttr("项目名字", true)]
        [DataAttr(true)]
        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
        private string staffID;
        [ColumnAttr("员工工号", false)]
        [DataAttr(true)]
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        private string staffName;
        [ColumnAttr("技师", true)]
        [DataAttr(true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        /// <summary>
        /// 0 轮 点 加
        /// </summary>
        [ColumnAttr("做工类型", false)]
        [DataAttr(true)]
        public int WorkType { get; set; }

        private DateTime startTime;
        [ColumnAttr("开始时间", true)]
        [DataAttr(true)]
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime endTime;
        [ColumnAttr("结束时间", true)]
        [DataAttr(true)]
        public DateTime  EndTime 
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private double priceA;
        [ColumnAttr("轮钟", true)]
        [DataAttr(true)]
        public double PriceA
        {
            get { return priceA; }
            set { priceA = value; }
        }
        private double priceB;
        [ColumnAttr("点钟", true)]
        [DataAttr(true)]
        public double PriceB
        {
            get { return priceB; }
            set { priceB = value; }
        }
        private double priceC;
        [ColumnAttr("加钟", true)]
        [DataAttr(true)]
        public double PriceC
        {
            get { return priceC; }
            set { priceC = value; }
        }
        [DataAttr(true)]
        public int CompanyId { get; set; }
    }
}
