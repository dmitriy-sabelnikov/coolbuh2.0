/****** Object:  Table [dbo].[Payment]    Script Date: 19.03.2018 8:58:01 ******/
--�������
IF OBJECT_ID(N'[Payment]','U') IS NULL
begin
CREATE TABLE [dbo].[Payment]
(
	Payment_Id                int IDENTITY(1,1)      NOT NULL,
	Payment_PersCard_Id       int                    NOT NULL,  --������ �� �������� ���������
	Payment_Date              date                           ,  --����
	Payment_Type              int                    NOT NULL,  --��� �������(1-�����, 2-�������, 3-������, 4-�����������)
	Payment_Amt               numeric(10,2)                  ,  --����������
	Payment_Price             numeric(10,2)                  ,  --����
  Payment_Sm                numeric(10,2)                     --�����
 CONSTRAINT [PK_Payment.Payment_Id] PRIMARY KEY CLUSTERED 
 (
	[Payment_Id] ASC
 ),
 CONSTRAINT FK_Payment_PersCard_Id FOREIGN KEY (Payment_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)
create index ind_Payment_1_1 on Payment (Payment_PersCard_Id);
create index ind_Payment_1_2 on Payment (Payment_Date);
end; 

