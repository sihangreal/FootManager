using ClientCenter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCenter.Enity
{
      [DataAttr("StaffInfo")]
      public class StaffInfoVo
      {
          private string staffId;
          [ColumnAttr("员工编号", false)]
          [DataAttr(true, true)]
          public string StaffId
          {
              get { return staffId; }
              set { staffId = value; }
          }
          private string staffName;
          [ColumnAttr("员工姓名", true)]
          [DataAttr(true)]
          public string StaffName
          {
              get { return staffName; }
              set { staffName = value; }
          }
          private string staffLevel;
          [ColumnAttr("员工职称", true)]
          [DataAttr(true)]
          public string StaffLevel
          {
              get { return staffLevel; }
              set { staffLevel = value; }
          }
          private string staffSex; //0 女，1男
          [ColumnAttr("员工性别", true)]
          [DataAttr(true)]
          public string StaffSex
          {
              get { return staffSex; }
              set { staffSex = value; }
          }
          private string staffPlace;
          [ColumnAttr("籍贯", true)]
          [DataAttr(true)]
          public string StaffPlace
          {
              get { return staffPlace; }
              set { staffPlace = value; }
          }
          private string department;
          [ColumnAttr("所属部门", true)]
          [DataAttr(true)]
          public string Department
          {
              get { return department; }
              set { department = value; }
          }
          private string idNumber;
          [ColumnAttr("护照", true)]
          [DataAttr(true)]
          public string IdNumber
          {
              get { return idNumber; }
              set { idNumber = value; }
          }
          private double basicSalary;
          [ColumnAttr("底薪", true)]
          [DataAttr(true)]
          public double BasicSalary
          {
              get { return basicSalary; }
              set { basicSalary = value; }
          }
          private string commssion;
          [ColumnAttr("是否参加提成", true)]
          [DataAttr(true)]
          public string Commision
          {
              get { return commssion; }
              set { commssion = value; }
          }
      }
}
