--/****** Object:  Table [dbo].[UnionReportT4]    Script Date: 19.03.2018 8:58:01 ******/
--Объединенная отчетность. Таблица 4
IF OBJECT_ID(N'[UnionReportT4]','U') IS NULL
CREATE TABLE [dbo].[UnionReportT4]
(
        UnionReportT4_Id             int IDENTITY(1,1)  NOT NULL,
        UnionReportT4_CtId           int                NOT NULL,  --Ссылка на каталог 
        UnionReportT4_Date           Date               NOT NULL,  --Отчетный период
	UnionReportT4_ExportFile     int                        ,  --Номер файла(1, 2, 3). Для экспорта
        UnionReportT4_ISUKR          int                        ,  --Гражданство Украины(1 - да) 
        UnionReportT4_TIN            nvarchar(12)               ,  --ИНН
        UnionReportT4_LName          nvarchar(35)               ,  --Фамилия
        UnionReportT4_FName          nvarchar(35)               ,  --Имя
        UnionReportT4_MName          nvarchar(35)               ,  --Отчество     
        UnionReportT4_C_Pid          nvarchar(25)               ,  --Код основния для учета спецстажа
        UnionReportT4_Start_Days     int                        ,  --Период начало
        UnionReportT4_Stop_Days      int                        ,  --Период конец              
        UnionReportT4_Days           int                        ,  --Дни              
        UnionReportT4_Hours          int                        ,  --Часы              
        UnionReportT4_Minutes        int                        ,  --Минуты                 
        UnionReportT4_DaysNorm       int                        ,  --Норма длительности работы для ее зачисления за полный месяц спецстажа, дни, 
        UnionReportT4_HoursNorm      int                        ,  --Норма длительности работы для ее зачисления за полный месяц спецстажа, часы
        UnionReportT4_MinutesNorm    int                        ,  --Норма длительности работы для ее зачисления за полный месяц спецстажа, минуты
        UnionReportT4_Ord_Num        nvarchar(8)                ,  --Номер приказа о проведении аттестации рабочего места
        UnionReportT4_Ord_Dat        int                        ,  --Дата приказа о проведении аттестации рабочего места
        UnionReportT4_SSN            int                           --Признак сезонности

 CONSTRAINT [PK_UnionReportT4.UnionReportT4] PRIMARY KEY CLUSTERED 
 (
	[UnionReportT4_Id] ASC
 ),
  CONSTRAINT FK_UnionReportT4_CtId_UnionReportCt_Id FOREIGN KEY (UnionReportT4_CtId)     
    REFERENCES dbo.UnionReportCt (UnionReportCt_Id)

)


