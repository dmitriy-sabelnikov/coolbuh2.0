/****** Object:  Table [dbo].[RefLivWage]    Script Date: 19.03.2018 8:58:01 ******/
--Прожиточный минимум
IF OBJECT_ID(N'[RefLivWage]','U') IS NULL
CREATE TABLE [dbo].RefLivWage
(
    RefLivWage_Id                    int IDENTITY(1,1)  NOT NULL,
    RefLivWage_PerBeg                date                       ,  --Дата начала
    RefLivWage_PerEnd                date                       ,  --Дата конца 
    RefLivWage_Sm                    numeric(16,2)                 --Сумма прожиточного минимума
 CONSTRAINT [PK_RefLivWage.RefLivWage] PRIMARY KEY CLUSTERED 
 (
	[RefLivWage_Id] ASC
 )
)


