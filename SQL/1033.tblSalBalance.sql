--/****** Object:  Table [dbo].[SalBalance]    Script Date: 19.03.2018 8:58:01 ******/
--������
IF OBJECT_ID(N'[SalBalance]','U') IS NULL
begin
CREATE TABLE [dbo].[SalBalance]
(
	SalBalance_Id                int IDENTITY(1,1)      NOT NULL,
	SalBalance_PersCard_Id       int                    NOT NULL,  --������ �� �������� ���������
	SalBalance_Date              date                           ,  --����
        SalBalance_BegMonthSm        numeric(10,2)                  ,  --������ �� ������ ������
        SalBalance_EndMonthSm        numeric(10,2)                  ,  --������ �� ����� ������
	SalBalance_Flg               int                               --�����

 CONSTRAINT [PK_SalBalance.SalBalance_Id] PRIMARY KEY CLUSTERED 
 (
	[SalBalance_Id] ASC
 ),
 CONSTRAINT FK_SalBalance_PersCard_Id FOREIGN KEY (SalBalance_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)
create index ind_SalBalance_1_1 on SalBalance (SalBalance_PersCard_Id);
create index ind_SalBalance_1_2 on SalBalance (SalBalance_Date);
end; 


