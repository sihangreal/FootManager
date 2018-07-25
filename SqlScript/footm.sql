/*
Navicat MySQL Data Transfer

Source Server         : Foot
Source Server Version : 50717
Source Host           : localhost:3306
Source Database       : footm

Target Server Type    : MYSQL
Target Server Version : 50717
File Encoding         : 65001

Date: 2018-07-25 23:02:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `card`
-- ----------------------------
DROP TABLE IF EXISTS `card`;
CREATE TABLE `card` (
  `CardId` int(11) NOT NULL AUTO_INCREMENT COMMENT '会员卡ID',
  `CardName` varchar(50) NOT NULL COMMENT '卡名',
  `DisCount` double DEFAULT NULL COMMENT '折扣价格',
  PRIMARY KEY (`CardId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='会员卡';

-- ----------------------------
-- Records of card
-- ----------------------------
INSERT INTO `card` VALUES ('1', 'VIP500', '0');
INSERT INTO `card` VALUES ('3', '折扣卡', '40');

-- ----------------------------
-- Table structure for `company`
-- ----------------------------
DROP TABLE IF EXISTS `company`;
CREATE TABLE `company` (
  `CompanyId` int(11) NOT NULL AUTO_INCREMENT COMMENT '公司ID',
  `Name` varchar(50) NOT NULL COMMENT '公司名称',
  `Manager` varchar(50) DEFAULT NULL COMMENT '经理',
  `Address` varchar(100) DEFAULT NULL COMMENT '公司地址',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`CompanyId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of company
-- ----------------------------
INSERT INTO `company` VALUES ('1', 'KAKI-KAKI REFLEXOLOGY  蔡师傅足浴', 'xxx', 'xx', null);

-- ----------------------------
-- Table structure for `customserver`
-- ----------------------------
DROP TABLE IF EXISTS `customserver`;
CREATE TABLE `customserver` (
  `ServerName` varchar(50) NOT NULL COMMENT '服务名',
  `SkillId` int(11) DEFAULT NULL COMMENT '服务ID',
  `SkillName` varchar(50) NOT NULL COMMENT '项目名字'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='服务表';

-- ----------------------------
-- Records of customserver
-- ----------------------------
INSERT INTO `customserver` VALUES ('一条龙', '1', '洗脚');
INSERT INTO `customserver` VALUES ('一条龙', '2', '按摩');

-- ----------------------------
-- Table structure for `department`
-- ----------------------------
DROP TABLE IF EXISTS `department`;
CREATE TABLE `department` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `DepName` varchar(50) NOT NULL COMMENT '部门名',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='部门表';

-- ----------------------------
-- Records of department
-- ----------------------------
INSERT INTO `department` VALUES ('1', '服务部', '321');
INSERT INTO `department` VALUES ('2', '后勤部', '22');

-- ----------------------------
-- Table structure for `detailedorder`
-- ----------------------------
DROP TABLE IF EXISTS `detailedorder`;
CREATE TABLE `detailedorder` (
  `DetailID` varchar(20) NOT NULL COMMENT '详细单号',
  `OrderID` varchar(20) NOT NULL COMMENT '订单编号',
  `SkillId` int(11) NOT NULL COMMENT '项目ID',
  `Price` double DEFAULT NULL COMMENT '价格',
  `Tax` double DEFAULT NULL COMMENT '税',
  `TotalPrice` double DEFAULT NULL COMMENT '总价格',
  PRIMARY KEY (`DetailID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of detailedorder
-- ----------------------------
INSERT INTO `detailedorder` VALUES ('DP2018071500002', 'P201807151579', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP2018071500003', 'P201807151579', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP2018071500004', 'P201807151579', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP2018071516311', 'P201807154293', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP2018071536416', 'P201807154293', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP2018071547548', 'P201807154293', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP2018071548525', 'P201807151579', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP2018071568836', 'P201807154293', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP2018071579397', 'P201807154293', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP2018071579962', 'P201807154293', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP2018071581481', 'P201807154293', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP2018072400002', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807244127', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP2018072500002', 'P201807252455', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP2018072500003', 'P201807252455', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP2018072500004', 'P201807252455', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP2018072500009', 'P201807257599', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP2018072500010', 'P201807257599', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP2018072500011', 'P201807257599', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP2018072500012', 'P201807257599', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807254137', 'P201807254582', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP201807254421', 'P201807254582', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807255892', 'P201807254582', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257245', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257246', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257247', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257248', 'P201807242031', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP201807257249', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257250', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257251', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257252', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257253', 'P201807242031', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP201807257254', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257255', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257256', 'P201807242031', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP201807257257', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257258', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257259', 'P201807242031', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP201807257260', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257261', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257262', 'P201807242031', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP201807257263', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257264', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257265', 'P201807242031', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP201807257266', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257267', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257268', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257269', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257270', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257271', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257272', 'P201807242031', '3', '100', '5.66', '105.66');
INSERT INTO `detailedorder` VALUES ('DP201807257273', 'P201807242031', '1', '30', '1.7', '31.7');
INSERT INTO `detailedorder` VALUES ('DP201807257274', 'P201807242031', '2', '50', '2.83', '52.83');
INSERT INTO `detailedorder` VALUES ('DP201807257275', 'P201807242031', '3', '100', '5.66', '105.66');

-- ----------------------------
-- Table structure for `goods`
-- ----------------------------
DROP TABLE IF EXISTS `goods`;
CREATE TABLE `goods` (
  `GoodsID` int(11) NOT NULL AUTO_INCREMENT COMMENT '货物ID',
  `GoddsName` varchar(30) NOT NULL COMMENT '货物名称',
  `UerID` int(11) NOT NULL COMMENT '操作人ID',
  `Name` varchar(30) NOT NULL COMMENT '操作人名',
  `Volumn` int(11) NOT NULL COMMENT '数量',
  `Date` datetime NOT NULL COMMENT '进货时间',
  PRIMARY KEY (`GoodsID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of goods
-- ----------------------------

-- ----------------------------
-- Table structure for `level`
-- ----------------------------
DROP TABLE IF EXISTS `level`;
CREATE TABLE `level` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `StaffLevel` varchar(50) NOT NULL COMMENT '级别名字',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='员工级别表';

-- ----------------------------
-- Records of level
-- ----------------------------
INSERT INTO `level` VALUES ('2', '低级', 'xxx国人');
INSERT INTO `level` VALUES ('3', '中级', 'ccc');

-- ----------------------------
-- Table structure for `member`
-- ----------------------------
DROP TABLE IF EXISTS `member`;
CREATE TABLE `member` (
  `MId` varchar(30) NOT NULL COMMENT '会员ID',
  `MName` varchar(50) NOT NULL COMMENT '会员姓名',
  `CardName` varchar(50) NOT NULL COMMENT '会员卡名称',
  `MPhone` varchar(50) DEFAULT NULL COMMENT '会员电话',
  `MCreateTime` datetime NOT NULL COMMENT '开卡时间',
  `MStatus` varchar(10) NOT NULL COMMENT '状态',
  `MBalance` double NOT NULL COMMENT '余额',
  `CompanyId` int(11) NOT NULL COMMENT '公司ID',
  PRIMARY KEY (`MId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='会员管理';

-- ----------------------------
-- Records of member
-- ----------------------------
INSERT INTO `member` VALUES ('M20180715540', '王生', 'VIP500', null, '2018-07-15 23:25:02', '正常', '5000', '1');
INSERT INTO `member` VALUES ('M20180715609', '陈生', 'VIP500', null, '2018-07-15 23:25:02', '正常', '10000', '1');
INSERT INTO `member` VALUES ('M20180716668', '张三', 'VIP500', '', '2018-07-16 21:14:53', '正常', '5000', '1');
INSERT INTO `member` VALUES ('M20180725441', '大哥', '折扣卡', '', '2018-07-25 20:22:43', '正常', '30000', '1');

-- ----------------------------
-- Table structure for `memberconsume`
-- ----------------------------
DROP TABLE IF EXISTS `memberconsume`;
CREATE TABLE `memberconsume` (
  `ID` varchar(30) NOT NULL COMMENT 'ID',
  `MId` varchar(30) NOT NULL COMMENT '会员ID',
  `MName` varchar(50) NOT NULL COMMENT '会员姓名',
  `Amount` double NOT NULL COMMENT '金额',
  `ConsumeTime` datetime NOT NULL COMMENT '消费时间',
  `CompanyId` int(11) NOT NULL COMMENT '公司ID',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='会员消费记录';

-- ----------------------------
-- Records of memberconsume
-- ----------------------------
INSERT INTO `memberconsume` VALUES ('C20180725148', 'M20180725441', '大哥', '190.19', '2018-07-25 22:57:11', '1');
INSERT INTO `memberconsume` VALUES ('C20180725400', 'M20180725441', '大哥', '190.19', '2018-07-25 22:00:32', '1');
INSERT INTO `memberconsume` VALUES ('C20180725406', 'M20180725441', '大哥', '190.19', '2018-07-25 20:37:04', '1');
INSERT INTO `memberconsume` VALUES ('C20180725408', 'M20180725441', '大哥', '190.19', '2018-07-25 21:57:59', '1');
INSERT INTO `memberconsume` VALUES ('C20180725426', 'M20180725441', '大哥', '31.7', '2018-07-25 22:34:43', '1');
INSERT INTO `memberconsume` VALUES ('C20180725520', 'M20180725441', '大哥', '190.19', '2018-07-25 20:27:15', '1');
INSERT INTO `memberconsume` VALUES ('C20180725638', 'M20180725441', '大哥', '190.19', '2018-07-25 22:59:30', '1');
INSERT INTO `memberconsume` VALUES ('C20180725641', 'M20180725441', '大哥', '31.7', '2018-07-25 22:38:40', '1');
INSERT INTO `memberconsume` VALUES ('C20180725651', 'M20180725441', '大哥', '190.19', '2018-07-25 22:15:29', '1');
INSERT INTO `memberconsume` VALUES ('C20180725657', 'M20180725441', '大哥', '190.19', '2018-07-25 21:54:17', '1');
INSERT INTO `memberconsume` VALUES ('C20180725681', 'M20180725441', '大哥', '190.19', '2018-07-25 20:31:22', '1');
INSERT INTO `memberconsume` VALUES ('C20180725753', 'M20180725441', '大哥', '190.19', '2018-07-25 22:18:55', '1');
INSERT INTO `memberconsume` VALUES ('C20180725796', 'M20180725441', '大哥', '31.7', '2018-07-25 20:23:15', '1');
INSERT INTO `memberconsume` VALUES ('C20180725812', 'M20180725441', '大哥', '84.53', '2018-07-25 22:31:10', '1');
INSERT INTO `memberconsume` VALUES ('C20180725871', 'M20180725441', '大哥', '84.53', '2018-07-25 21:55:24', '1');
INSERT INTO `memberconsume` VALUES ('C20180725972', 'M20180725441', '大哥', '190.19', '2018-07-25 22:08:05', '1');

-- ----------------------------
-- Table structure for `memberrecharge`
-- ----------------------------
DROP TABLE IF EXISTS `memberrecharge`;
CREATE TABLE `memberrecharge` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `MId` varchar(30) NOT NULL COMMENT '会员ID',
  `MName` varchar(50) NOT NULL COMMENT '会员姓名',
  `Amount` double NOT NULL COMMENT '金额',
  `UpdateTime` datetime NOT NULL COMMENT '充值时间',
  `CompanyId` int(11) NOT NULL COMMENT '公司ID',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COMMENT='会员充值';

-- ----------------------------
-- Records of memberrecharge
-- ----------------------------
INSERT INTO `memberrecharge` VALUES ('10', 'M20180715609', '陈生', '10000', '2018-07-15 23:25:02', '1');
INSERT INTO `memberrecharge` VALUES ('11', 'M20180715540', '王生', '5000', '2018-07-15 23:25:02', '1');
INSERT INTO `memberrecharge` VALUES ('12', 'M20180716668', '张三', '5000', '2018-07-16 21:14:53', '1');
INSERT INTO `memberrecharge` VALUES ('13', 'M20180725441', '大哥', '30000', '2018-07-25 20:22:43', '1');

-- ----------------------------
-- Table structure for `orderinfo`
-- ----------------------------
DROP TABLE IF EXISTS `orderinfo`;
CREATE TABLE `orderinfo` (
  `OrderID` varchar(20) NOT NULL COMMENT '订单编号',
  `RoomID` int(11) NOT NULL COMMENT '房间编号',
  `StaffName` varchar(30) NOT NULL COMMENT '员工姓名',
  `StartTime` datetime DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `PriceType` varchar(30) DEFAULT NULL COMMENT '收费类型',
  `Price` double DEFAULT NULL COMMENT '价格',
  `Tax` double DEFAULT NULL COMMENT '税',
  `TotalPrice` double DEFAULT NULL COMMENT '总价格',
  `Status` varchar(30) DEFAULT NULL COMMENT '状态',
  PRIMARY KEY (`OrderID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of orderinfo
-- ----------------------------
INSERT INTO `orderinfo` VALUES ('P201807242031', '1', '小红', '2018-07-24 22:22:54', '2018-07-25 22:59:30', '现金', '180', '190.19', '190.19', '完成');
INSERT INTO `orderinfo` VALUES ('P201807243094', '1', '小红', '2018-07-24 23:38:05', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807249898', '1', '小红', '2018-07-24 23:33:54', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807252057', '1', '小红', '2018-07-25 22:34:35', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807252436', '1', '小红', '2018-07-25 22:38:35', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807252442', '1', '小红', '2018-07-25 22:05:41', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807252455', '3', '小红', '2018-07-25 20:30:59', '2018-07-25 20:31:08', '现金', '180', '190.19', '190.19', '完成');
INSERT INTO `orderinfo` VALUES ('P201807252585', '1', '小红', '2018-07-25 20:39:10', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807252658', '1', '小红', '2018-07-25 21:57:53', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807253903', '1', '小红', '2018-07-25 22:18:50', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807254447', '1', '小红', '2018-07-25 22:30:45', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807254582', '2', '小红', '2018-07-25 20:24:19', '2018-07-25 20:25:37', '现金', '180', '190.19', '190.19', '完成');
INSERT INTO `orderinfo` VALUES ('P201807255016', '1', '小红', '2018-07-25 21:55:13', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807255313', '1', '小红', '2018-07-25 22:57:05', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807256074', '1', '小红', '2018-07-25 22:59:24', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807257599', '4', '小红', '2018-07-25 20:36:23', '2018-07-25 20:36:41', '现金', '180', '190.19', '190.19', '完成');
INSERT INTO `orderinfo` VALUES ('P201807258264', '1', '小红', '2018-07-25 22:00:26', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807258894', '1', '小红', '2018-07-25 20:20:40', null, null, '0', '0', '0', '未完成');
INSERT INTO `orderinfo` VALUES ('P201807259050', '1', '小红', '2018-07-25 22:15:22', null, null, '0', '0', '0', '未完成');

-- ----------------------------
-- Table structure for `permission`
-- ----------------------------
DROP TABLE IF EXISTS `permission`;
CREATE TABLE `permission` (
  `Name` varchar(30) NOT NULL COMMENT '权限名',
  `ModeName` varchar(30) NOT NULL COMMENT '包含模块'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='权限表';

-- ----------------------------
-- Records of permission
-- ----------------------------
INSERT INTO `permission` VALUES ('系统管理员', '添加会员卡');
INSERT INTO `permission` VALUES ('系统管理员', '删除会员卡');
INSERT INTO `permission` VALUES ('系统管理员', '修改会员卡');
INSERT INTO `permission` VALUES ('系统管理员', '添加权限组');
INSERT INTO `permission` VALUES ('系统管理员', '删除权限组');
INSERT INTO `permission` VALUES ('系统管理员', '修改权限组');
INSERT INTO `permission` VALUES ('系统管理员', '添加用户');
INSERT INTO `permission` VALUES ('系统管理员', '删除用户');
INSERT INTO `permission` VALUES ('系统管理员', '修改用户');
INSERT INTO `permission` VALUES ('系统管理员', '添加项目');
INSERT INTO `permission` VALUES ('系统管理员', '删除项目');
INSERT INTO `permission` VALUES ('系统管理员', '修改项目');
INSERT INTO `permission` VALUES ('系统管理员', '添加服务');
INSERT INTO `permission` VALUES ('系统管理员', '删除服务');
INSERT INTO `permission` VALUES ('系统管理员', '修改服务');
INSERT INTO `permission` VALUES ('系统管理员', '添加员工');
INSERT INTO `permission` VALUES ('系统管理员', '删除员工');
INSERT INTO `permission` VALUES ('系统管理员', '修改员工');
INSERT INTO `permission` VALUES ('系统管理员', '添加员工级别');
INSERT INTO `permission` VALUES ('系统管理员', '删除员工级别');
INSERT INTO `permission` VALUES ('系统管理员', '修改员工级别');
INSERT INTO `permission` VALUES ('系统管理员', '添加部门');
INSERT INTO `permission` VALUES ('系统管理员', '删除部门');
INSERT INTO `permission` VALUES ('系统管理员', '修改部门');
INSERT INTO `permission` VALUES ('系统管理员', '添加班次');
INSERT INTO `permission` VALUES ('系统管理员', '删除班次');
INSERT INTO `permission` VALUES ('系统管理员', '修改班次');

-- ----------------------------
-- Table structure for `room`
-- ----------------------------
DROP TABLE IF EXISTS `room`;
CREATE TABLE `room` (
  `RoomId` int(11) NOT NULL COMMENT '钟房编号',
  `RoomName` varchar(30) NOT NULL COMMENT '钟房名字',
  `RoomStatus` varchar(30) NOT NULL COMMENT '钟房状态',
  PRIMARY KEY (`RoomId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of room
-- ----------------------------
INSERT INTO `room` VALUES ('1', '101房', '空闲');
INSERT INTO `room` VALUES ('2', '102房', '空闲');
INSERT INTO `room` VALUES ('3', '103房', '空闲');
INSERT INTO `room` VALUES ('4', '104房', '空闲');
INSERT INTO `room` VALUES ('5', '105房', '空闲');
INSERT INTO `room` VALUES ('6', '106房', '空闲');

-- ----------------------------
-- Table structure for `skill`
-- ----------------------------
DROP TABLE IF EXISTS `skill`;
CREATE TABLE `skill` (
  `SkillId` int(11) NOT NULL AUTO_INCREMENT COMMENT '服务ID',
  `SkillName` varchar(50) NOT NULL COMMENT '项目名字',
  `SecondName` varchar(50) DEFAULT NULL COMMENT '别名',
  `ServerTime` varchar(10) NOT NULL COMMENT '项目时长',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`SkillId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='服务表';

-- ----------------------------
-- Records of skill
-- ----------------------------
INSERT INTO `skill` VALUES ('1', '洗脚', 'xx', '30分钟', '');
INSERT INTO `skill` VALUES ('2', '按摩', 'bb', '30分钟', '');
INSERT INTO `skill` VALUES ('3', '推油', 'cc', '30分钟', 'xxx');

-- ----------------------------
-- Table structure for `skillcommision`
-- ----------------------------
DROP TABLE IF EXISTS `skillcommision`;
CREATE TABLE `skillcommision` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `SkillName` varchar(50) NOT NULL COMMENT '服务名字',
  `StaffLevel` varchar(50) NOT NULL COMMENT '级别名字',
  `PriceA` double NOT NULL COMMENT '轮种价格',
  `PriceB` double NOT NULL COMMENT '点种价格',
  `PriceC` double NOT NULL COMMENT '加种价格',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of skillcommision
-- ----------------------------
INSERT INTO `skillcommision` VALUES ('1', '推油', '低级', '10', '10', '10', '');
INSERT INTO `skillcommision` VALUES ('2', '推油', '中级', '10', '10', '10', '');
INSERT INTO `skillcommision` VALUES ('3', '按摩', '中级', '10', '10', '10', '');
INSERT INTO `skillcommision` VALUES ('4', '按摩', '低级', '10', '10', '10', '');
INSERT INTO `skillcommision` VALUES ('5', '洗脚', '低级', '10', '10', '10', '');
INSERT INTO `skillcommision` VALUES ('6', '洗脚', '中级', '10', '10', '10', '');

-- ----------------------------
-- Table structure for `skillprice`
-- ----------------------------
DROP TABLE IF EXISTS `skillprice`;
CREATE TABLE `skillprice` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `SkillName` varchar(50) NOT NULL COMMENT '服务名字',
  `PriceType` varchar(30) NOT NULL COMMENT '售价类别',
  `PriceA` double NOT NULL COMMENT '轮种价格',
  `PriceB` double NOT NULL COMMENT '点种价格',
  `PriceC` double NOT NULL COMMENT '加种价格',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COMMENT='服务售价表';

-- ----------------------------
-- Records of skillprice
-- ----------------------------
INSERT INTO `skillprice` VALUES ('1', '洗脚', '现金', '30', '30', '30', '');
INSERT INTO `skillprice` VALUES ('2', '洗脚', 'Visa卡', '30', '30', '30', '');
INSERT INTO `skillprice` VALUES ('3', '洗脚', '折扣卡', '30', '30', '30', '');
INSERT INTO `skillprice` VALUES ('4', '按摩', '折扣卡', '50', '50', '50', '');
INSERT INTO `skillprice` VALUES ('5', '按摩', '现金', '50', '50', '50', '');
INSERT INTO `skillprice` VALUES ('6', '按摩', 'Visa卡', '50', '50', '50', '');
INSERT INTO `skillprice` VALUES ('7', '推油', 'Visa卡', '100', '100', '100', '');
INSERT INTO `skillprice` VALUES ('8', '推油', '现金', '100', '100', '100', '');
INSERT INTO `skillprice` VALUES ('9', '推油', '折扣卡', '100', '100', '100', '');

-- ----------------------------
-- Table structure for `staffclass`
-- ----------------------------
DROP TABLE IF EXISTS `staffclass`;
CREATE TABLE `staffclass` (
  `StaffClassID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID',
  `StaffClassName` varchar(50) NOT NULL COMMENT '班次名字',
  `StartTime` int(11) NOT NULL COMMENT '开始时间',
  `EndTime` int(11) NOT NULL COMMENT '结束时间',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`StaffClassID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='员工班次表';

-- ----------------------------
-- Records of staffclass
-- ----------------------------
INSERT INTO `staffclass` VALUES ('1', '全班', '1', '24', '13');
INSERT INTO `staffclass` VALUES ('2', '晚班', '20', '2', null);

-- ----------------------------
-- Table structure for `staffinfo`
-- ----------------------------
DROP TABLE IF EXISTS `staffinfo`;
CREATE TABLE `staffinfo` (
  `StaffId` varchar(30) NOT NULL COMMENT '员工ID',
  `StaffName` varchar(50) NOT NULL COMMENT '员工名',
  `StaffLevel` varchar(30) NOT NULL COMMENT '员工级别',
  `StaffSex` varchar(30) NOT NULL COMMENT '性别',
  `StaffPlace` varchar(50) DEFAULT NULL COMMENT '籍贯',
  `Department` varchar(50) NOT NULL COMMENT '所属部门',
  `IdNumber` varchar(50) DEFAULT NULL COMMENT '护照号',
  `BasicSalary` double NOT NULL COMMENT '底薪',
  `Commision` tinyint(1) NOT NULL COMMENT '是否提成',
  PRIMARY KEY (`StaffId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='员工基本信息表';

-- ----------------------------
-- Records of staffinfo
-- ----------------------------
INSERT INTO `staffinfo` VALUES ('S20180715890', '小红', '中级', '男', null, '服务部', null, '3000', '1');

-- ----------------------------
-- Table structure for `staffprebook`
-- ----------------------------
DROP TABLE IF EXISTS `staffprebook`;
CREATE TABLE `staffprebook` (
  `StaffID` varchar(30) NOT NULL COMMENT '员工工号',
  `StaffName` varchar(30) NOT NULL COMMENT '员工姓名',
  `StaffSex` varchar(30) NOT NULL COMMENT '员工性别',
  `PreTime` datetime NOT NULL COMMENT '预订时间',
  `ComTime` datetime NOT NULL COMMENT '到店时间',
  `Remind` varchar(30) NOT NULL COMMENT '是否提醒',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of staffprebook
-- ----------------------------

-- ----------------------------
-- Table structure for `staffqueue`
-- ----------------------------
DROP TABLE IF EXISTS `staffqueue`;
CREATE TABLE `staffqueue` (
  `QueueId` int(11) NOT NULL COMMENT '顺序',
  `StaffID` varchar(30) NOT NULL COMMENT '员工工号',
  `StaffName` varchar(30) NOT NULL COMMENT '员工姓名',
  `StaffSex` varchar(30) NOT NULL COMMENT '员工性别'
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of staffqueue
-- ----------------------------
INSERT INTO `staffqueue` VALUES ('1', 'S20180715890', '小红', '男');

-- ----------------------------
-- Table structure for `staffwork`
-- ----------------------------
DROP TABLE IF EXISTS `staffwork`;
CREATE TABLE `staffwork` (
  `StaffID` varchar(30) NOT NULL COMMENT '员工工号',
  `StaffName` varchar(30) NOT NULL COMMENT '员工姓名',
  `StaffSex` varchar(30) NOT NULL COMMENT '员工性别',
  `StaffStatus` varchar(30) NOT NULL COMMENT '员工状态',
  `RoomId` int(11) DEFAULT NULL COMMENT '钟房编号',
  `RoomName` varchar(30) DEFAULT NULL COMMENT '房间',
  `OrderID` varchar(20) DEFAULT NULL COMMENT '订单编号',
  PRIMARY KEY (`StaffID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of staffwork
-- ----------------------------
INSERT INTO `staffwork` VALUES ('S20180715890', '小红', '男', '空闲', null, '', '');

-- ----------------------------
-- Table structure for `staffworkrecord`
-- ----------------------------
DROP TABLE IF EXISTS `staffworkrecord`;
CREATE TABLE `staffworkrecord` (
  `ID` varchar(30) NOT NULL COMMENT '做工记录ID',
  `StaffId` varchar(30) NOT NULL COMMENT '员工ID',
  `StaffName` varchar(50) NOT NULL COMMENT '员工名',
  `OrderID` varchar(30) NOT NULL COMMENT '订单ID',
  `Amount` double NOT NULL COMMENT '金额',
  `WorkTime` datetime NOT NULL COMMENT '做工完成时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of staffworkrecord
-- ----------------------------
INSERT INTO `staffworkrecord` VALUES ('R20180715226', 'S20180714170', 'cc', 'P201807142784', '31.7', '2018-07-15 12:17:58');
INSERT INTO `staffworkrecord` VALUES ('R20180715293', 'S20180714170', 'cc', 'P201807142784', '52.83', '2018-07-15 12:40:54');
INSERT INTO `staffworkrecord` VALUES ('R20180715354', 'S20180714170', 'cc', 'P201807142784', '31.7', '2018-07-15 12:31:18');
INSERT INTO `staffworkrecord` VALUES ('R20180715447', 'S20180714170', 'cc', 'P201807142784', '31.7', '2018-07-15 12:31:57');
INSERT INTO `staffworkrecord` VALUES ('R20180715467', 'S20180715890', '小红', 'P201807154293', '84.53', '2018-07-15 18:00:18');
INSERT INTO `staffworkrecord` VALUES ('R20180715540', 'S20180715890', '小红', 'P201807154293', '190.19', '2018-07-15 18:49:50');
INSERT INTO `staffworkrecord` VALUES ('R20180715558', 'S20180714170', 'cc', 'P201807142784', '190.19', '2018-07-15 13:04:05');
INSERT INTO `staffworkrecord` VALUES ('R20180715754', 'S20180715890', '小红', 'P201807151579', '190.19', '2018-07-15 19:00:38');
INSERT INTO `staffworkrecord` VALUES ('R20180715797', 'S20180714589', 'xxx', 'P201807142784', '31.7', '2018-07-15 12:26:28');
INSERT INTO `staffworkrecord` VALUES ('R20180715812', 'S20180715890', '小红', 'P201807151579', '190.19', '2018-07-15 18:58:42');
INSERT INTO `staffworkrecord` VALUES ('R20180715880', 'S20180715890', '小红', 'P201807154293', '190.19', '2018-07-15 18:12:50');
INSERT INTO `staffworkrecord` VALUES ('R20180725106', 'S20180715890', '小红', 'P201807257599', '190.19', '2018-07-25 20:37:04');
INSERT INTO `staffworkrecord` VALUES ('R20180725172', 'S20180715890', '小红', 'P201807242031', '31.7', '2018-07-25 20:23:15');
INSERT INTO `staffworkrecord` VALUES ('R20180725236', 'S20180715890', '小红', 'P201807242031', '84.53', '2018-07-25 22:31:10');
INSERT INTO `staffworkrecord` VALUES ('R20180725260', 'S20180715890', '小红', 'P201807242031', '190.19', '2018-07-25 21:57:59');
INSERT INTO `staffworkrecord` VALUES ('R20180725295', 'S20180715890', '小红', 'P201807242031', '84.53', '2018-07-25 21:55:24');
INSERT INTO `staffworkrecord` VALUES ('R20180725471', 'S20180715890', '小红', 'P201807242031', '190.19', '2018-07-25 22:57:11');
INSERT INTO `staffworkrecord` VALUES ('R20180725572', 'S20180715890', '小红', 'P201807252455', '190.19', '2018-07-25 20:31:22');
INSERT INTO `staffworkrecord` VALUES ('R20180725576', 'S20180715890', '小红', 'P201807242031', '190.19', '2018-07-25 22:00:32');
INSERT INTO `staffworkrecord` VALUES ('R20180725601', 'S20180715890', '小红', 'P201807242031', '190.19', '2018-07-25 21:54:17');
INSERT INTO `staffworkrecord` VALUES ('R20180725606', 'S20180715890', '小红', 'P201807242031', '190.19', '2018-07-25 22:18:55');
INSERT INTO `staffworkrecord` VALUES ('R20180725638', 'S20180715890', '小红', 'P201807242031', '190.19', '2018-07-25 22:59:30');
INSERT INTO `staffworkrecord` VALUES ('R20180725734', 'S20180715890', '小红', 'P201807254582', '190.19', '2018-07-25 20:27:15');
INSERT INTO `staffworkrecord` VALUES ('R20180725748', 'S20180715890', '小红', 'P201807242031', '31.7', '2018-07-25 22:34:43');
INSERT INTO `staffworkrecord` VALUES ('R20180725825', 'S20180715890', '小红', 'P201807242031', '190.19', '2018-07-25 22:08:05');
INSERT INTO `staffworkrecord` VALUES ('R20180725827', 'S20180715890', '小红', 'P201807242031', '190.19', '2018-07-25 22:15:29');
INSERT INTO `staffworkrecord` VALUES ('R20180725963', 'S20180715890', '小红', 'P201807242031', '31.7', '2018-07-25 22:38:40');

-- ----------------------------
-- Table structure for `temporder`
-- ----------------------------
DROP TABLE IF EXISTS `temporder`;
CREATE TABLE `temporder` (
  `Id` int(11) NOT NULL AUTO_INCREMENT COMMENT '详细单号',
  `OrderID` varchar(20) NOT NULL COMMENT '订单编号',
  `RoomID` int(11) NOT NULL COMMENT '房间编号',
  `SkillId` int(11) NOT NULL COMMENT '项目ID',
  `SkillName` varchar(50) NOT NULL COMMENT '项目名字',
  `StaffID` varchar(30) NOT NULL COMMENT '员工ID',
  `StaffName` varchar(30) NOT NULL COMMENT '员工姓名',
  `StartTime` datetime DEFAULT NULL COMMENT '开始时间',
  `EndTime` datetime DEFAULT NULL COMMENT '结束时间',
  `PriceA` double NOT NULL COMMENT '轮种价格',
  `PriceB` double NOT NULL COMMENT '点种价格',
  `PriceC` double NOT NULL COMMENT '加种价格',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of temporder
-- ----------------------------

-- ----------------------------
-- Table structure for `userrole`
-- ----------------------------
DROP TABLE IF EXISTS `userrole`;
CREATE TABLE `userrole` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(30) NOT NULL COMMENT '用户姓名',
  `Role` varchar(30) NOT NULL COMMENT '所属权限组',
  `Psword` varchar(30) NOT NULL COMMENT '用户密码',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of userrole
-- ----------------------------
INSERT INTO `userrole` VALUES ('2', 'sys', '系统管理员', '654321');

-- ----------------------------
-- Procedure structure for `addStaffSkill`
-- ----------------------------
DROP PROCEDURE IF EXISTS `addStaffSkill`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `addStaffSkill`(
in v_staffId varchar(30),
in v_skillName VARCHAR(50)
)
BEGIN
DECLARE v_skillId int;#原始金额
SELECT skillId into v_skillId FROM skill WHERE skillName=v_skillName;
INSERT INTO staffSkill(StaffId,skillId) VALUES(v_staffId,v_skillId);
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `memberConsumePro`
-- ----------------------------
DROP PROCEDURE IF EXISTS `memberConsumePro`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `memberConsumePro`(
in v_mid int,#会员ID
in v_cardid int,#会员卡ID
in v_total double,#消费金额
out v_pay double
)
BEGIN
DECLARE v_discount double;#折扣
select DisCount into v_discount from card where CardId=v_cardid;
set v_pay=v_total*v_discount;
insert into memberconsume (MId,Amount,ProjectId,ConsumeTime,CompanyId)
values(1,v_pay,1,SYSDATE(),1);
update member set MBalance = MBalance-v_pay;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `memberRechargePro`
-- ----------------------------
DROP PROCEDURE IF EXISTS `memberRechargePro`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `memberRechargePro`(
in v_mid varchar(30),#会员ID
in v_mname varchar(50),
in v_companyId int,
in v_amount double#充值金额
)
BEGIN
DECLARE v_old double;#原始金额
insert into memberrecharge(MId,MName,Amount,UpdateTime,CompanyId)values(v_mid,v_mname,v_amount,SYSDATE(),v_companyId);
select MBalance into v_old from member where MId=v_mid;
update member set MBalance = v_old+v_amount;
END
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `memberRegister`
-- ----------------------------
DROP PROCEDURE IF EXISTS `memberRegister`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `memberRegister`(
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
;;
DELIMITER ;

-- ----------------------------
-- Procedure structure for `staffRegister`
-- ----------------------------
DROP PROCEDURE IF EXISTS `staffRegister`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `staffRegister`(IN v_staffId VARCHAR(30), 
 IN v_staffName VARCHAR(50), 
 IN v_staffSex VARCHAR(30),
 IN v_staffPlace VARCHAR(50),
 IN v_staffLevel VARCHAR(30),
 IN v_department VARCHAR(50),
 IN v_idNumber VARCHAR(50),
 IN v_basicSalary DOUBLE, 
 IN v_commision tinyint(1))
BEGIN
INSERT INTO StaffInfo(StaffId,StaffName,StaffSex,StaffPlace,StaffLevel,Department,IdNumber,BasicSalary,Commision)
VALUES(v_staffId,v_staffName,v_staffSex,v_staffPlace,v_staffLevel,v_department,v_idNumber,v_basicSalary,v_commision);

INSERT INTO StaffWork(StaffID,StaffName,StaffSex,StaffStatus)
VALUES(v_staffId,v_staffName,v_staffSex,'空闲');
END
;;
DELIMITER ;
