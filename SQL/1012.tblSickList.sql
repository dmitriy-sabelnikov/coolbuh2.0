/****** Object:  Table [dbo].[SickList]    Script Date: 19.03.2018 8:58:01 ******/
--����������
IF OBJECT_ID(N'[SickList]','U') IS NULL
begin
CREATE TABLE [dbo].[SickList]
(
	SickList_Id             int IDENTITY(1,1)      NOT NULL,
	SickList_PersCard_Id    int                    NOT NULL,  --������ �� �������� ���������
	SickList_RefDep_Id      int                    NOT NULL,  --������ �� ���������� �������������
	SickList_Date           date                           ,  --����
	SickList_DaysEntprs     int                            ,  --���, ������������ ������������
	SickList_SmEntprs       numeric(10,2)                  ,  --�����, ������������ ������������
	SickList_DaysSocInsrnc  int                            ,  --���, ������������ ���������
	SickList_SmSocInsrnc    numeric(10,2)                  ,  --�����, ������������ ���������
	SickList_PayDate        date                           ,  --����, �� ������� ���������� ����������
	SickList_DaysTmpDis     int                            ,  --���, ��������� ������������������
	SickList_ResSm          numeric(10,2)                     --�������� �����
 CONSTRAINT [PK_SickList.SickList] PRIMARY KEY CLUSTERED 
 (
	[SickList_Id] ASC
 ),
 CONSTRAINT FK_SickList_RefDep_Id FOREIGN KEY (SickList_RefDep_Id)     
    REFERENCES RefDep (RefDep_Id), 
 CONSTRAINT FK_SickList_PersCard_Id FOREIGN KEY (SickList_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)

create index ind_SickList_1_1 on SickList (SickList_PersCard_Id);
create index ind_SickList_1_2 on SickList (SickList_RefDep_Id);
create index ind_SickList_1_3 on SickList (SickList_RefDep_Id,SickList_Date);
end; 

