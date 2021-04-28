--/****** Object:  Table [dbo].[UnionReportT2]    Script Date: 19.03.2018 8:58:01 ******/
--Объединенная отчетность. Таблица 2
IF OBJECT_ID(N'[UnionReportT2]','U') IS NULL
CREATE TABLE [dbo].[UnionReportT2]
(
        UnionReportT2_Id             int IDENTITY(1,1)  NOT NULL,
        UnionReportT2_CtId           int                NOT NULL,  --Ссылка на каталог 
        UnionReportT2_USREOU         varchar(10)                ,  --Код ЕГРПОУ   
	UnionReportT2_Type           int                        ,  --Тип
        UnionReportT2_TIN            nvarchar(12)	        ,  --ИНН
	UnionReportT2_LName          nvarchar(35)               ,  --Фамилия
	UnionReportT2_FName          nvarchar(35)               ,  --Имя
	UnionReportT2_MName          nvarchar(35)               ,  --Отчество     
	UnionReportT2_AccrIncSm      numeric(16,2)              ,  --Сумма начисленного дохода
	UnionReportT2_PaidIncSm      numeric(16,2)              ,  --Сумма выплаченного дохода
	UnionReportT2_AccrTaxSm      numeric(16,2)              ,  --Сумма удержанного налога, начисленного
	UnionReportT2_TransfTaxSm    numeric(16,2)              ,  --Сумма удержанного налога, перечисленного
	UnionReportT2_IncFlg         int                        ,  --Признак дохода
	UnionReportT2_DOR            Date	                ,  --Дата поступления(date of receipt)
	UnionReportT2_DOD            Date	                ,  --Дата увольнения(date of dismissal)
	UnionReportT2_SocBenefitFlg  int                        ,  --Признак соц. льготы
	UnionReportT2_AccrWarTaxSm   numeric(16,2)              ,  --Сумма военного сбора, начисленного
	UnionReportT2_TransWarTaxSm  numeric(16,2)              ,  --Сумма военного сбора, перечисленного

 CONSTRAINT [PK_UnionReportT2.UnionReportT2] PRIMARY KEY CLUSTERED 
 (
	[UnionReportT2_Id] ASC
 ),
  CONSTRAINT FK_UnionReportT2_CtId_UnionReportCt_Id FOREIGN KEY (UnionReportT2_CtId)     
    REFERENCES dbo.UnionReportCt (UnionReportCt_Id)

)


