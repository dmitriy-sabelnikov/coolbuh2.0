/****** Object:  Table [dbo].[RefTypeAddAccr]    Script Date: 19.03.2018 8:58:01 ******/
--����������. ��� �������������� ���������� ��������
IF OBJECT_ID(N'[RefTypeAddAccr]','U') IS NULL
begin
CREATE TABLE [dbo].[RefTypeAddAccr]
(
	RefTypeAddAccr_Id     int IDENTITY(1,1)      NOT NULL,
	RefTypeAddAccr_Cd     varchar(25)            NOT NULL,  --��� ����������
	RefTypeAddAccr_Nm     varchar(50)            NOT NULL,  --������������ ����������
	RefTypeAddAccr_Flg    int
 CONSTRAINT [PK_RefTypeAddAccr.RefTypeAddAccr] PRIMARY KEY CLUSTERED 
 (
	[RefTypeAddAccr_Id] ASC
 ),
)
end; 

