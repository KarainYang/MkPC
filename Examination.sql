IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[Exam_Principle]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
drop table Exam_Principle;
IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[Exam_Vision_Subject]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
drop table Exam_Vision_Subject;
IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[Exam_Vision_Result]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
drop table Exam_Vision_Result;

--检查-原理
create table Exam_Principle
(
ID int identity(1,1) primary key,--编号
Name varchar(50),--名称
Module varchar(50),--模块 1视力检查 2听力检测 3血压测量 4心率测量 5肺活量测量 6呼吸频率测量 7血氧测量 8心理检测
PicUrl varchar(256),--图片
[Description] varchar(max),--说明
Creater varchar(50),--创建人
CreatedOn datetime  default getDate(),--创建日期
Modifier varchar(50),--修改人
ModifyOn datetime  default getDate()--修改日期
)

--检查-视力-题目
create table Exam_Vision_Subject
(
ID int identity(1,1) primary key,--编号
[Type] varchar(50),--类型：1视力检查 2色盲检查 3颜色敏感度 4视力表 5散光测试 
Name varchar(50),--名称
PicUrl varchar(256),--图片
Result varchar(50),--结果
OrderBy int default 0,--排序
[Description] varchar(max),--说明
Creater varchar(50),--创建人
CreatedOn datetime  default getDate(),--创建日期
Modifier varchar(50),--修改人
ModifyOn datetime  default getDate()--修改日期
)

--检查-视力-结果
create table Exam_Vision_Result
(
ID int identity(1,1) primary key,--编号
UserId int,--用户ID
Module varchar(50),--模块 1视力检查 2听力检测 3血压测量 4心率测量 5肺活量测量 6呼吸频率测量 7血氧测量 8心理检测
[Type] varchar(50),
--类型：1视力检查（1视力检查 2色盲检查 3颜色敏感度 4视力表 5散光测试）
--类型：2听力检测（1默认）
--类型：3血压测量（1手机测量 2血压计测量 3手动输入）
--类型：4心率测量（1手机测量 2心率仪测量 3手动输入）
--类型：5肺活量测量（1手机测量 2手动输入）
--类型：6呼吸频率测量（1光电测量 2话筒测量 3手动输入）
--类型：7血氧测量（1手机测量 2血氧仪测量 3手动输入）
--类型：8心理检测（1情绪 2抑郁症 3自闭症）
Result varchar(50),--结果
Creater varchar(50),--创建人
CreatedOn datetime  default getDate(),--创建日期
Modifier varchar(50),--修改人
ModifyOn datetime  default getDate()--修改日期
)

