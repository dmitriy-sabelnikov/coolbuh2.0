--/****** Object:  Table [dbo].[Disability]    Script Date: 19.03.2018 8:58:01 ******/
--������ ��������. ������������
IF OBJECT_ID(N'[Disability]','U') IS NULL
CREATE TABLE [dbo].[Disability]
(
	Disability_Id           int IDENTITY(1,1)  NOT NULL,
	Disability_PersCard_Id  int                NOT NULL,  --������ �� �������� ���������
	Disability_PerBeg       Date	                      ,  --������ ������
	Disability_PerEnd       Date	                      ,  --������ �����
	Disability_Attr         int                              --�������
 CONSTRAINT [PK_Disability.Disability] PRIMARY KEY CLUSTERED 
 (
	[Disability_Id] ASC
 ),
 CONSTRAINT FK_Disability_PersCard_Id FOREIGN KEY (Disability_PersCard_Id)     
    REFERENCES dbo.PersCard (PersCard_Id)
)


