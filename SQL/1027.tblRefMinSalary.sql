/****** Object:  Table [dbo].[RefMinSalary]    Script Date: 19.03.2018 8:58:01 ******/
--����������� �/�
IF OBJECT_ID(N'[RefMinSalary]','U') IS NULL
CREATE TABLE [dbo].RefMinSalary
(
    RefMinSalary_Id                    int IDENTITY(1,1)  NOT NULL,
    RefMinSalary_PerBeg                date                       ,  --���� ������
    RefMinSalary_PerEnd                date                       ,  --���� ����� 
    RefMinSalary_Sm                    numeric(16,2)                 --����� ����������� �/�
 CONSTRAINT [PK_RefMinSalary.RefMinSalary] PRIMARY KEY CLUSTERED 
 (
	[RefMinSalary_Id] ASC
 )
)


