/****** Object:  Table [dbo].[RefSocBenefit]    Script Date: 19.03.2018 8:58:01 ******/
--Социальная льгота
IF OBJECT_ID(N'[RefSocBenefit]','U') IS NULL
CREATE TABLE [dbo].RefSocBenefit
(
    RefSocBenefit_Id                    int IDENTITY(1,1)  NOT NULL,
    RefSocBenefit_PerBeg                date                       ,  --Дата начала
    RefSocBenefit_PerEnd                date                       ,  --Дата конца 
    RefSocBenefit_Sm                    numeric(16,2)              ,  --Сумма льготы
    RefSocBenefit_LimSm                 numeric(16,2)                 --Ограничение социальной льготы
 CONSTRAINT [PK_RefSocBenefit.RefSocBenefit] PRIMARY KEY CLUSTERED 
 (
	[RefSocBenefit_Id] ASC
 )
)


