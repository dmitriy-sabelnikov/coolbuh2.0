/****** Object:  Table [dbo].[UST7]    Script Date: 19.03.2018 8:58:01 ******/
--ЕСВ. Таблица 7
IF OBJECT_ID(N'[UST7]','U') IS NULL
CREATE TABLE [dbo].[UST7]
(
    UST7_Id                    int IDENTITY(1,1)  NOT NULL,
    UST7_USTCt_Id              int                NOT NULL,  --Ссылка на каталог ЕСВ
    UST7_ISUKR                 int                        ,  --Гражданство Украины(1 - да) 
    UST7_TIN                   nvarchar(12)               ,  --ИНН
    UST7_LName                 nvarchar(35)               ,  --Фамилия
    UST7_FName                 nvarchar(35)               ,  --Имя
    UST7_MName                 nvarchar(35)               ,  --Отчество     
    UST7_C_Pid                 nvarchar(25)               ,  --Код основния для учета спецстажа
    UST7_Start_Days            int                        ,  --Период начало
    UST7_Stop_Days             int                        ,  --Период конец              
    UST7_Days                  int                        ,  --Дни              
    UST7_Hours                 int                        ,  --Часы              
    UST7_Minutes               int                        ,  --Минуты                 
    UST7_Norm                  int                        ,  --Норма длительности работы для ее зачисления за полный месяц спецстажа
    UST7_Ord_Num               nvarchar(8)                ,  --Номер приказа о проведении аттестации рабочего места
    UST7_Ord_Dat               int                        ,  --Дата приказа о проведении аттестации рабочего места
    UST7_SSN                   int                           --Признак сезонности
 CONSTRAINT [PK_UST7.UST7] PRIMARY KEY CLUSTERED 
 (
	[UST7_Id] ASC
 ),
 CONSTRAINT FK_UST7_USTCt_Id_USTCt_USTCt_Id FOREIGN KEY (UST7_USTCt_Id)     
    REFERENCES dbo.USTCt (USTCt_Id)
)


