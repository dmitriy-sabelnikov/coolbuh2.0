--/****** Object:  Table [dbo].[DFRec]    Script Date: 19.03.2018 8:58:01 ******/
--1ДФ. Каталог
IF OBJECT_ID(N'[DFRec]','U') IS NULL
CREATE TABLE [dbo].[DFRec]
(
	DFRec_Id             int IDENTITY(1,1)  NOT NULL,
	DFRec_DFCt_Id        int                NOT NULL,  --Ссылка на каталог
	DFRec_USREOU         varchar(10)                ,  --Код ЕГРПОУ   
	DFRec_Type           int                        ,  --Тип
	DFRec_FName          nvarchar(35)	              ,  --Имя
	DFRec_MName          nvarchar(35)               ,  --Отчество
	DFRec_LName          nvarchar(35)	              ,  --Фамилия
	DFRec_TIN            nvarchar(12)	              ,  --ИНН
	DFRec_AccrIncSm      numeric(16,2)              ,  --Сумма начисленного дохода
	DFRec_PaidIncSm      numeric(16,2)              ,  --Сумма выплаченного дохода
	DFRec_AccrTaxSm      numeric(16,2)              ,  --Сумма удержанного налога, начисленного
	DFRec_TransfTaxSm    numeric(16,2)              ,  --Сумма удержанного налога, перечисленного
	DFRec_IncFlg         int                        ,  --Признак дохода
	DFRec_DOR            Date	                      ,  --Дата поступления(date of receipt)
	DFRec_DOD            Date	                      ,  --Дата увольнения(date of dismissal)
	DFRec_SocBenefitFlg  int                        ,  --Признак соц. льготы
	DFRec_Flg            int                           --Флаг
 CONSTRAINT [PK_DFRec.DFRec] PRIMARY KEY CLUSTERED 
 (
	[DFRec_Id] ASC
 ),
 CONSTRAINT FK_DFRec_DFRec_Id_DFRec_DFCt_Id FOREIGN KEY (DFRec_DFCt_Id)     
    REFERENCES dbo.DFCt (DFCt_Id)
)


