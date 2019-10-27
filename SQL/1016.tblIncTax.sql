/****** Object:  Table [dbo].[IncTax]    Script Date: 19.03.2018 8:58:01 ******/
--������������� ����������� ������
IF OBJECT_ID(N'[IncTax]','U') IS NULL
begin
CREATE TABLE [dbo].[IncTax]
(
	IncTax_Id                int IDENTITY(1,1)      NOT NULL,
	IncTax_PersCard_Id       int                    NOT NULL,  --������ �� �������� ���������
	IncTax_Date              date                           ,  --����
        IncTax_Sm                numeric(10,2)                     --����� ������
 CONSTRAINT [PK_IncTax.IncTax_Id] PRIMARY KEY CLUSTERED 
 (
	[IncTax_Id] ASC
 ),
 CONSTRAINT FK_IncTax_PersCard_Id FOREIGN KEY (IncTax_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)
create index ind_IncTax_1_1 on IncTax (IncTax_PersCard_Id);
create index ind_IncTax_1_2 on IncTax (IncTax_Date);
end; 

