--/****** Object:  Table [dbo].[Child]    Script Date: 19.03.2018 8:58:01 ******/
--������ ��������. ����
IF OBJECT_ID(N'[Child]','U') IS NULL
CREATE TABLE [dbo].[Child]
(
	Child_Id           int IDENTITY(1,1)  NOT NULL,
	Child_PersCard_Id  int                NOT NULL,  --������ �� �������� ���������
	Child_PerBeg       Date	                      ,  --������ ������
	Child_PerEnd       Date	                      ,  --������ �����
	Child_Count        int                           --������ �� �������� ���������
 CONSTRAINT [PK_Child.Child] PRIMARY KEY CLUSTERED 
 (
	[Child_Id] ASC
 ),
 CONSTRAINT FK_Child_PersCard_Id FOREIGN KEY (Child_PersCard_Id)     
    REFERENCES dbo.PersCard (PersCard_Id)
)


