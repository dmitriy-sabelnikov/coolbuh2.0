/****** Object:  Table [dbo].[RefMinSalary]    Script Date: 19.03.2018 8:58:01 ******/
--Минимальная з/п
IF OBJECT_ID(N'[RefMinSalary]','U') IS NULL
CREATE TABLE [dbo].RefMinSalary
(
    RefMinSalary_Id                    int IDENTITY(1,1)  NOT NULL,
    RefMinSalary_PerBeg                date                       ,  --Дата начала
    RefMinSalary_PerEnd                date                       ,  --Дата конца 
    RefMinSalary_Sm                    numeric(16,2)                 --Сумма минимальной з/п
 CONSTRAINT [PK_RefMinSalary.RefMinSalary] PRIMARY KEY CLUSTERED 
 (
	[RefMinSalary_Id] ASC
 )
)


