--/****** Object:  Table [dbo].[TaxRelief]    Script Date: 19.03.2018 8:58:01 ******/
--������ ��������. ������
IF OBJECT_ID(N'[TaxRelief]','U') IS NULL
CREATE TABLE [dbo].[TaxRelief]
(
	TaxRelief_Id           int IDENTITY(1,1)  NOT NULL,
	TaxRelief_PersCard_Id  int                NOT NULL,  --������ �� �������� ���������
	TaxRelief_PerBeg       Date	                  ,  --������ ������
	TaxRelief_PerEnd       Date	                  ,  --������ �����
	TaxRelief_Koef         numeric(10,2)                  --����������� ������
 CONSTRAINT [PK_TaxRelief.TaxRelief] PRIMARY KEY CLUSTERED 
 (
	[TaxRelief_Id] ASC
 ),
 CONSTRAINT FK_TaxRelief_PersCard_Id FOREIGN KEY (TaxRelief_PersCard_Id)     
    REFERENCES dbo.PersCard (PersCard_Id)
)


