--/****** Object:  Table [dbo].[CardStatus]    Script Date: 19.03.2018 8:58:01 ******/
--������ ��������. ������
IF OBJECT_ID(N'[CardStatus]','U') IS NULL
CREATE TABLE [dbo].[CardStatus]
(
	CardStatus_Id           int IDENTITY(1,1)  NOT NULL,
	CardStatus_PersCard_Id  int                NOT NULL,  --������ �� �������� ���������
	CardStatus_PerBeg       Date	                    ,  --������ ������
	CardStatus_PerEnd       Date	                    ,  --������ �����
	CardStatus_Type         int                            --��� �������(1-����������, 2-���������, 3-��������������� )
 CONSTRAINT [PK_CardStatus.CardStatus] PRIMARY KEY CLUSTERED 
 (
	[CardStatus_Id] ASC
 ),
 CONSTRAINT FK_CardStatus_PersCard_Id FOREIGN KEY (CardStatus_PersCard_Id)     
    REFERENCES dbo.PersCard (PersCard_Id)
)


