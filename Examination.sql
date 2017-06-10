IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[Exam_Principle]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
drop table Exam_Principle;
IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[Exam_Vision_Subject]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
drop table Exam_Vision_Subject;
IF EXISTS  (SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'[Exam_Vision_Result]') AND OBJECTPROPERTY(ID, 'IsTable') = 1) 
drop table Exam_Vision_Result;

--���-ԭ��
create table Exam_Principle
(
ID int identity(1,1) primary key,--���
Name varchar(50),--����
Module varchar(50),--ģ�� 1������� 2������� 3Ѫѹ���� 4���ʲ��� 5�λ������� 6����Ƶ�ʲ��� 7Ѫ������ 8������
PicUrl varchar(256),--ͼƬ
[Description] varchar(max),--˵��
Creater varchar(50),--������
CreatedOn datetime  default getDate(),--��������
Modifier varchar(50),--�޸���
ModifyOn datetime  default getDate()--�޸�����
)

--���-����-��Ŀ
create table Exam_Vision_Subject
(
ID int identity(1,1) primary key,--���
[Type] varchar(50),--���ͣ�1������� 2ɫä��� 3��ɫ���ж� 4������ 5ɢ����� 
Name varchar(50),--����
PicUrl varchar(256),--ͼƬ
Result varchar(50),--���
OrderBy int default 0,--����
[Description] varchar(max),--˵��
Creater varchar(50),--������
CreatedOn datetime  default getDate(),--��������
Modifier varchar(50),--�޸���
ModifyOn datetime  default getDate()--�޸�����
)

--���-����-���
create table Exam_Vision_Result
(
ID int identity(1,1) primary key,--���
UserId int,--�û�ID
Module varchar(50),--ģ�� 1������� 2������� 3Ѫѹ���� 4���ʲ��� 5�λ������� 6����Ƶ�ʲ��� 7Ѫ������ 8������
[Type] varchar(50),
--���ͣ�1������飨1������� 2ɫä��� 3��ɫ���ж� 4������ 5ɢ����ԣ�
--���ͣ�2������⣨1Ĭ�ϣ�
--���ͣ�3Ѫѹ������1�ֻ����� 2Ѫѹ�Ʋ��� 3�ֶ����룩
--���ͣ�4���ʲ�����1�ֻ����� 2�����ǲ��� 3�ֶ����룩
--���ͣ�5�λ���������1�ֻ����� 2�ֶ����룩
--���ͣ�6����Ƶ�ʲ�����1������ 2��Ͳ���� 3�ֶ����룩
--���ͣ�7Ѫ��������1�ֻ����� 2Ѫ���ǲ��� 3�ֶ����룩
--���ͣ�8�����⣨1���� 2����֢ 3�Ա�֢��
Result varchar(50),--���
Creater varchar(50),--������
CreatedOn datetime  default getDate(),--��������
Modifier varchar(50),--�޸���
ModifyOn datetime  default getDate()--�޸�����
)

