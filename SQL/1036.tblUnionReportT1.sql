--/****** Object:  Table [dbo].[UnionReportT1]    Script Date: 19.03.2018 8:58:01 ******/
--Объединенная отчетность. Таблица 1
IF OBJECT_ID(N'[UnionReportT1]','U') IS NULL
CREATE TABLE [dbo].[UnionReportT1]
(
	UnionReportT1_Id             int IDENTITY(1,1)  NOT NULL,
	UnionReportT1_CtId           int                NOT NULL,  --Ссылка на каталог 
	UnionReportT1_Date           Date               NOT NULL,  --Отчетный период
	UnionReportT1_ExportFile     int                        ,  --Номер файла(1, 2, 3). Для экспорта
        UnionReportT1_ISUKR          int                        ,  --Гражданство Украины(1 - да) 
	UnionReportT1_SEX            int                        ,  --Пол(0-Ж, 1-М)                                    
	UnionReportT1_TIN            nvarchar(12)               ,  --ИНН
	UnionReportT1_LName          nvarchar(35)               ,  --Фамилия
	UnionReportT1_FName          nvarchar(35)               ,  --Имя
	UnionReportT1_MName          nvarchar(35)               ,  --Отчество     
	UnionReportT1_Category_Cd    int                        ,  --Код категории застрахованного лица 
	UnionReportT1_Accr_Cd        int                        ,  --Код типа начислений
	UnionReportT1_Month          int                        ,  --Месяц, за который проводится начисление
	UnionReportT1_Year           int                        ,  --Год, за который проводится начисление
	UnionReportT1_DisabDays      int                        ,  --Количество календарных дней временной нетрудоспособности
	UnionReportT1_NoSalDays      int                        ,  --Количество календарных дней без сохранения зарплаты
	UnionReportT1_EmplDays       int                        ,  --Количество дней пребывания в трудовых отношениях
	UnionReportT1_VocDays        int                        ,  --Количество дней календарных дней отпуска в связи с беремменостью и родами
	UnionReportT1_TotalSm        numeric(16,2)              ,  --Общая сумма начисленной зарплаты/дохода (всего с начала отчетного месяца)
	UnionReportT1_MaxSm          numeric(16,2)              ,  --Cумма начиселнной зарплаты/дохода в границах макс. величины, на которую начисляется взнос
	UnionReportT1_DiffSm         numeric(16,2)              ,  --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
	UnionReportT1_WithHeldUSTSm  numeric(16,2)              ,  --Cумма удержанного единого взноса
	UnionReportT1_AccrUSTSm      numeric(16,2)              ,  --Cумма начисленного единого взноса
	UnionReportT1_WB             int                        ,  --Признак наличия трудовой книжки(1 - да, 0 - нет)
	UnionReportT1_SpecExp        int                        ,  --Признак наличия спецстажа(1 - да, 0 - нет)
	UnionReportT1_PWT            int                        ,  --Признак неполного рабочего времени(1 - да, 0 - нет)
	UnionReportT1_NWP            int                           --Признак нового рабочего места(1 - да, 0 - нет)

 CONSTRAINT [PK_UnionReportT1.UnionReportT1] PRIMARY KEY CLUSTERED 
 (
	[UnionReportT1_Id] ASC
 ),
  CONSTRAINT FK_UnionReportT1_CtId_UnionReportCt_Id FOREIGN KEY (UnionReportT1_CtId)     
    REFERENCES dbo.UnionReportCt (UnionReportCt_Id)

)


