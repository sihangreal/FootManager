CREATE TABLE StaffWorkRecord(
  ID VARCHAR(30) NOT NULL PRIMARY KEY COMMENT '做工记录ID',
  StaffId VARCHAR(30) NOT NULL COMMENT '员工ID',
  StaffName VARCHAR(50) NOT NULL COMMENT '员工名',
  OrderID VARCHAR(30) NOT NULL COMMENT '订单ID',
  Amount DOUBLE NOT NULL COMMENT '金额',
  WorkTime datetime NOT NULL COMMENT '做工完成时间'
)

CREATE TABLE Company(
  CompanyId INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT '公司ID',
  Name varchar(50) NOT NULL COMMENT '公司名称',
  Manager varchar(50) COMMENT '经理',
  Address varchar(100) COMMENT '公司地址',
  Remark VARCHAR(100) COMMENT '备注'
)

CREATE TABLE member (
  MId varchar(30) NOT NULL PRIMARY KEY COMMENT '会员ID',
  MName varchar(50) NOT NULL COMMENT '会员姓名',
  CardName varchar(50) NOT NULL COMMENT '会员卡名称',
  MPhone varchar(50) COMMENT '会员电话',
  MCreateTime datetime NOT NULL COMMENT '开卡时间',
  MStatus varchar(10) NOT NULL COMMENT '状态',
  MBalance double NOT NULL COMMENT '余额',
  CompanyId int(11) NOT NULL COMMENT '公司ID'
) COMMENT='会员管理';

Select * from memberRecharge
CREATE TABLE memberRecharge (
	ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'ID',
	MId varchar(30) NOT NULL COMMENT '会员ID',
  MName varchar(50) NOT NULL COMMENT '会员姓名',
	Amount DOUBLE NOT NULL COMMENT '金额',
	UpdateTime DATETIME NOT NULL COMMENT '充值时间',
	CompanyId INT NOT NULL COMMENT '公司ID'
) COMMENT '会员充值';

CREATE TABLE MemberConsume (
	ID varchar(30) NOT NULL PRIMARY KEY COMMENT 'ID',
	MId varchar(30) NOT NULL COMMENT '会员ID',
  MName varchar(50) NOT NULL COMMENT '会员姓名',
	Amount DOUBLE NOT NULL COMMENT '金额',
	ConsumeTime DATETIME NOT NULL COMMENT '消费时间',
	CompanyId INT NOT NULL COMMENT '公司ID'
) COMMENT '会员消费记录';

CREATE TABLE Card (
	CardId INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT '会员卡ID',
	CardName VARCHAR (50) NOT NULL COMMENT '卡名',
  DisCount DOUBLE COMMENT '折扣价格'
) COMMENT '会员卡'

CREATE TABLE CardSkillShip(
  ShipId INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'ID',
  CardId INT NOT NULL, 
  SkillId INT NOT NULL, 
  CONSTRAINT ShipSkill_Id FOREIGN KEY (SkillId) REFERENCES Skill (SkillId),
  CONSTRAINT ShipServer_Id FOREIGN KEY (CardId) REFERENCES Card (CardId) 
)

CREATE TABLE StaffInfo(
  StaffId VARCHAR(30) NOT NULL PRIMARY KEY COMMENT '员工ID',
  StaffName VARCHAR(50) NOT NULL COMMENT '员工名',
  StaffLevel VARCHAR(30) NOT NULL COMMENT '员工级别',
  StaffSex VARCHAR(30) NOT NULL COMMENT '性别',
  StaffPlace VARCHAR(50) COMMENT '籍贯',
  Department VARCHAR(50) NOT NULL COMMENT '所属部门',
  IdNumber VARCHAR(50) COMMENT '护照号',
  BasicSalary DOUBLE NOT NULL COMMENT '底薪',
  Commision TINYINT(1) NOT NULL COMMENT '是否提成'
)COMMENT '员工基本信息表'

CREATE TABLE staffSkill(
  Id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'ID',
  StaffId VARCHAR(30) NOT NULL COMMENT '员工ID',
  SkillId INT NOT NULL COMMENT '技能ID'
)COMMENT '员工技能表'

CREATE TABLE Department
(
  id int PRIMARY KEY AUTO_INCREMENT COMMENT 'ID',
  DepName VARCHAR (50) NOT NULL COMMENT '部门名',
  Remark VARCHAR(100) COMMENT '备注'
)COMMENT '部门表'

CREATE TABLE Skill(
  SkillId INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT '服务ID',
  SkillName VARCHAR(50) NOT NULL COMMENT '项目名字',
  SecondName VARCHAR(50) COMMENT '别名',
  ServerTime VARCHAR(10) NOT NULL COMMENT '项目时长',
  Remark VARCHAR(100) COMMENT '备注'
)COMMENT '服务表'

CREATE TABLE SkillPrice(
  Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'ID',
  SkillName VARCHAR(50) NOT NULL COMMENT '服务名字',
  PriceType VARCHAR(30) NOT NULL COMMENT '售价类别',
  PriceA DOUBLE NOT NULL COMMENT '轮种价格',
  PriceB DOUBLE NOT NULL COMMENT '点种价格',
  PriceC DOUBLE NOT NULL COMMENT '加种价格',
  Remark VARCHAR(100) COMMENT '备注'
)COMMENT '服务售价表'

CREATE TABLE SkillCommision(
  Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'ID',
  SkillName VARCHAR(50) NOT NULL COMMENT '服务名字',
  StaffLevel VARCHAR(50) NOT NULL COMMENT '级别名字',
  PriceA DOUBLE NOT NULL COMMENT '轮种价格',
  PriceB DOUBLE NOT NULL COMMENT '点种价格',
  PriceC DOUBLE NOT NULL COMMENT '加种价格',
  Remark VARCHAR(100) COMMENT '备注'
)

CREATE TABLE CustomServer(
  ServerName VARCHAR(50) NOT NULL COMMENT '服务名',
  SkillId INT COMMENT '服务ID',
  SkillName VARCHAR(50) NOT NULL COMMENT '项目名字'
)COMMENT '服务表'

CREATE TABLE ServerSkillShip(
  ShipId INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'ID',
  ServerId INT NOT NULL, 
  SkillId INT NOT NULL, 
  CONSTRAINT ShipSkill_Id FOREIGN KEY (SkillId) REFERENCES Skill (SkillId),
  CONSTRAINT ShipServer_Id FOREIGN KEY (ServerId) REFERENCES CustomServer (ServerId) 
)COMMENT '技能服务关系表'

CREATE TABLE Level(
  Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'ID',
  StaffLevel VARCHAR(50) NOT NULL COMMENT '级别名字',
  Remark VARCHAR(100) COMMENT '备注'
)COMMENT '员工级别表'

CREATE TABLE StaffClass(
  StaffClassID INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'ID',
  StaffClassName VARCHAR(50) NOT NULL COMMENT '班次名字',
  StartTime INT NOT NULL COMMENT '开始时间',
  EndTime INT NOT NULL COMMENT '结束时间',
  Remark VARCHAR(100) COMMENT '备注'
)COMMENT '员工班次表'

CREATE TABLE Permission(
  Name VARCHAR(30) NOT NULL COMMENT '权限名',
  ModeName VARCHAR(30) NOT NULL COMMENT '包含模块'
)COMMENT '权限表'


CREATE TABLE UserRole(
  Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  Name VARCHAR(30) NOT NULL COMMENT '用户姓名',
  Role VARCHAR(30) NOT NULL COMMENT '所属权限组',
  Psword VARCHAR(30) NOT NULL COMMENT '用户密码'
)

CREATE TABLE Room(
  RoomId INT NOT NULL PRIMARY KEY COMMENT '钟房编号',
  RoomName VARCHAR(30) NOT NULL COMMENT '钟房名字',
  RoomStatus VARCHAR(30) NOT NULL COMMENT '钟房状态'
)

CREATE TABLE StaffWork(
  StaffID   VARCHAR(30) NOT NULL PRIMARY KEY COMMENT '员工工号',
  StaffName VARCHAR(30) NOT NULL COMMENT '员工姓名',
  StaffSex  VARCHAR(30) NOT NULL COMMENT '员工性别', 
  StaffStatus VARCHAR(30) NOT NULL COMMENT '员工状态',
  RoomId INT COMMENT '钟房编号',
  RoomName VARCHAR(30) COMMENT '房间',
  OrderID VARCHAR(20) COMMENT '订单编号'
)

CREATE TABLE StaffPreBook(
  StaffID   VARCHAR(30) NOT NULL COMMENT '员工工号',
  StaffName VARCHAR(30) NOT NULL COMMENT '员工姓名',
  StaffSex  VARCHAR(30) NOT NULL COMMENT '员工性别',
  PreTime DATETIME NOT NULL COMMENT '预订时间',
  ComTime DATETIME NOT NULL COMMENT '到店时间',
  Remind VARCHAR(30) NOT NULL COMMENT '是否提醒',
  Remark VARCHAR(100) COMMENT '备注'
)

CREATE TABLE StaffQueue(
  QueueId INT NOT NULL COMMENT '顺序',
  StaffID VARCHAR(30) NOT NULL COMMENT '员工工号',
  StaffName VARCHAR(30) NOT NULL COMMENT '员工姓名',
  StaffSex  VARCHAR(30) NOT NULL COMMENT '员工性别'
)

CREATE TABLE OrderInfo(
  OrderID VARCHAR(20) NOT NULL PRIMARY KEY COMMENT '订单编号',
  RoomID INT NOT NULL COMMENT '房间编号',
  StaffName VARCHAR(30) NOT NULL COMMENT '员工姓名',
  StartTime DATETIME COMMENT '开始时间',
  EndTime DATETIME COMMENT '结束时间',
  PriceType VARCHAR(30) COMMENT '收费类型',
  Price DOUBLE COMMENT '价格',
  Tax DOUBLE COMMENT '税',   
  TotalPrice DOUBLE COMMENT '总价格',
  Status VARCHAR(30) COMMENT '状态'
)

CREATE TABLE DetailedOrder(
  DetailID VARCHAR(20) NOT NULL PRIMARY KEY COMMENT '详细单号',
  OrderID VARCHAR(20) NOT NULL COMMENT '订单编号',
  SkillId INT NOT NULL COMMENT '项目ID',
  Price DOUBLE COMMENT '价格',
  Tax DOUBLE COMMENT '税',
  TotalPrice DOUBLE COMMENT '总价格'
)

CREATE TABLE TempOrder(
  Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT '详细单号',
  OrderID VARCHAR(20) NOT NULL COMMENT '订单编号',
  RoomID INT NOT NULL COMMENT '房间编号',
  SkillId INT NOT NULL COMMENT '项目ID',
  SkillName VARCHAR(50) NOT NULL COMMENT '项目名字',
  StaffID VARCHAR(30) NOT NULL COMMENT '员工ID',
  StaffName VARCHAR(30) NOT NULL COMMENT '员工姓名',
  StartTime DateTime COMMENT '开始时间',
  EndTime DateTime COMMENT '结束时间',
  PriceA DOUBLE NOT NULL COMMENT '轮种价格',
  PriceB DOUBLE NOT NULL COMMENT '点种价格',
  PriceC DOUBLE NOT NULL COMMENT '加种价格'
)

#--存储过程
#员工注册
DROP PROCEDURE staffRegister
CREATE PROCEDURE staffRegister(
 IN v_staffId VARCHAR(30), 
 IN v_staffName VARCHAR(50), 
 IN v_staffSex VARCHAR(30),
 IN v_staffPlace VARCHAR(50),
 IN v_staffLevel VARCHAR(30),
 IN v_department VARCHAR(50),
 IN v_idNumber VARCHAR(50),
 IN v_basicSalary DOUBLE, 
 IN v_commision VARCHAR(30) 
)
BEGIN
INSERT INTO StaffInfo(StaffId,StaffName,StaffSex,StaffPlace,StaffLevel,Department,IdNumber,BasicSalary,Commision)
VALUES(v_staffId,v_staffName,v_staffSex,v_staffPlace,v_staffLevel,v_department,v_idNumber,v_basicSalary,v_commision);

INSERT INTO StaffWork(StaffID,StaffName,StaffSex,StaffStatus)
VALUES(v_staffId,v_staffName,v_staffSex,'空闲');
END


#会员注册
DROP PROCEDURE memberRegister
CREATE PROCEDURE memberRegister(
in v_mid varchar(30),#会员ID
in v_mname varchar(50),
in v_cardName varchar(50),
in v_phone varchar(50),
in v_status varchar(10),
in v_balance double,
in v_companyId int
)
BEGIN
insert into member (MId,MName,CardName,MPhone,MCreateTime,MStatus,MBalance,CompanyId)
values(v_mid,v_mname,v_cardName,v_phone,SYSDATE(),v_status,v_balance,v_companyId);

insert into memberrecharge(MId,MName,Amount,UpdateTime,CompanyId)
values(v_mid,v_mname,v_balance,SYSDATE(),v_companyId);
END

#会员消费
CREATE PROCEDURE memberConsumePro(
in v_id varchar(30),#id
in v_mid varchar(30),#会员ID
in v_cardid int,#会员卡ID
in v_total double,#消费金额
in v_companyId int,#公司ID
out v_pay double
)
BEGIN
DECLARE v_mName varchar(50);#会员名字
select DisCount into v_discount from card where CardId=v_cardid;
set v_pay=v_total*v_discount;
insert into memberconsume (ID,MId,Amount,ProjectId,ConsumeTime,CompanyId)
values(v_id,v_mid,v_pay,1,current_timestamp(),v_companyId);
update member set MBalance = MBalance-v_pay;
END

#会员注册
CREATE PROCEDURE memberRechargePro(
in v_mid varchar(30),#会员ID
in v_mname varchar(50),
in v_companyId int,
in v_amount double
)
BEGIN
DECLARE v_old double;#原始金额
insert into memberrecharge(MId,MName,Amount,UpdateTime,CompanyId)values(v_mid,v_mname,v_amount,SYSDATE(),v_companyId);
select MBalance into v_old from member where MId=v_mid;
update member set MBalance = v_old+v_amount;
END

Drop PROCEDURE addStaffSkill
CREATE PROCEDURE addStaffSkill(
in v_staffId varchar(30),
in v_skillName VARCHAR(50)
)
BEGIN
DECLARE v_skillId int;#原始金额
SELECT skillId into v_skillId FROM skill WHERE skillName=v_skillName;
INSERT INTO staffSkill(StaffId,skillId) VALUES(v_staffId,v_skillId);
END
