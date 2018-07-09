﻿using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
    [DataAttr("StaffWork")]
    public class StaffWorkInfoVo
    {
        private string staffID;
        [ColumnAttr("员工工号", true)]
        [DataAttr(true,true)]
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        private string staffName;
        [ColumnAttr("技师姓名", true)]
        [DataAttr(true)]
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        private string staffSex;
        [ColumnAttr("技师性别", true)]
        [DataAttr(true)]
        public string StaffSex
        {
            get { return staffSex; }
            set { staffSex = value; }
        }
        private string staffStatus; //0 空闲，1上钟，2 请假
        [ColumnAttr("技师状态", true)]
        [DataAttr(true)]
        public string StaffStatus
        {
            get { return staffStatus; }
            set { staffStatus = value; }
        }
        private string skill;
        [ColumnAttr("服务项目",true)]
        [DataAttr(true)]
        public string Skill
        {
            get { return skill; }
            set { skill = value; }
        }
        private string startTime;
        [ColumnAttr("最近一次上钟时间", true)]
        [DataAttr(true)]
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private string endTime;
        [ColumnAttr("最近一次下钟时间", true)]
        [DataAttr(true)]
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        private int ?roomId;
        [ColumnAttr("钟房编号", false)]
        [DataAttr(true)]
        public int ?RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }
        private string roomName;
        [ColumnAttr("房间名", true)]
        [DataAttr(true)]
        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
    }
}