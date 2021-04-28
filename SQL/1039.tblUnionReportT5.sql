--/****** Object:  Table [dbo].[UnionReportT5]    Script Date: 19.03.2018 8:58:01 ******/
--Объединенная отчетность. Таблица 5
IF OBJECT_ID(N'[UnionReportT5]','U') IS NULL
CREATE TABLE [dbo].[UnionReportT5]
(
       UnionReportT5_Id                int IDENTITY(1,1)  NOT NULL,
       UnionReportT5_CtId              int                NOT NULL,  --Ссылка на каталог 
       UnionReportT5_Date              Date               NOT NULL,  --Отчетный период
       UnionReportT5_ExportFile        int                        ,  --Номер файла(1, 2, 3). Для экспорта
       UnionReportT5_ISUKR             int                        ,  --Гражданство Украины(1 - да) 
       UnionReportT5_TIN               nvarchar(12)               ,  --ИНН
       UnionReportT5_LName             nvarchar(35)               ,  --Фамилия
       UnionReportT5_FName             nvarchar(35)               ,  --Имя
       UnionReportT5_MName             nvarchar(35)               ,  --Отчество     
       UnionReportT5_Category_Cd       int                        ,  --Код категории застрахованного лица 
       UnionReportT5_MaterialAidStart  int                        ,  --Дата старта получения матпомощи
       UnionReportT5_MaterialAidEnd    int                        ,  --Дата окночания получения матпомощи
       UnionReportT5_Accr_Cd           int                        ,  --Код типа начислений
       UnionReportT5_Month             int                        ,  --Месяц, за который проводится начисление
       UnionReportT5_Year              int                        ,  --Год, за который проводится начисление
       UnionReportT5_TotalSm           numeric(16,2)              ,  --Общая сумма начиселнной матпомощи/компенсации/минимальной зп, установленной законодательством (всего с начала отчетного месяца)
       UnionReportT5_MaxSm             numeric(16,2)              ,  --Cумма начиселенной матпомощи/компенсации/минимальной зп в границах макс. величины, на которую начисляется ЕСВ
       UnionReportT1_AccrUSTSm      numeric(16,2)                 ,  --Cумма начисленного единого взноса
 CONSTRAINT [PK_UnionReportT5.UnionReportT5] PRIMARY KEY CLUSTERED 
 (
	[UnionReportT5_Id] ASC
 ),
  CONSTRAINT FK_UnionReportT5_CtId_UnionReportCt_Id FOREIGN KEY (UnionReportT5_CtId)     
    REFERENCES dbo.UnionReportCt (UnionReportCt_Id)

)


