/****** Object:  Table [dbo].[RefLivWage]    Script Date: 19.03.2018 8:58:01 ******/
--����������� �������
IF OBJECT_ID(N'[RefLivWage]','U') IS NULL
CREATE TABLE [dbo].RefLivWage
(
    RefLivWage_Id                    int IDENTITY(1,1)  NOT NULL,
    RefLivWage_PerBeg                date                       ,  --���� ������
    RefLivWage_PerEnd                date                       ,  --���� ����� 
    RefLivWage_Sm                    numeric(16,2)                 --����� ������������ ��������
 CONSTRAINT [PK_RefLivWage.RefLivWage] PRIMARY KEY CLUSTERED 
 (
	[RefLivWage_Id] ASC
 )
)


