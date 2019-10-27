/****** Object:  Table [dbo].[UST6]    Script Date: 19.03.2018 8:58:01 ******/
--ЕСВ. Таблица 6
IF OBJECT_ID(N'[UST6]','U') IS NULL
CREATE TABLE [dbo].[UST6]
(
    UST6_Id                    int IDENTITY(1,1)  NOT NULL,
    UST6_USTCt_Id              int                NOT NULL,  --Ссылка на каталог ЕСВ
    UST6_ISUKR                 int                        ,  --Гражданство Украины(1 - да) 
    UST6_SEX                   int                        ,  --Пол(0-Ж, 1-М)                                    
    UST6_TIN                   nvarchar(12)               ,  --ИНН
    UST6_LName                 nvarchar(35)               ,  --Фамилия
    UST6_FName                 nvarchar(35)               ,  --Имя
    UST6_MName                 nvarchar(35)               ,  --Отчество     
    UST6_Category_Cd           int                        ,  --Код категории застрахованного лица 
    UST6_Accr_Cd               int                        ,  --Код типа начислений
    UST6_Month                 int                        ,  --Месяц, за который проводится начисление
    UST6_Year                  int                        ,  --Год, за который проводится начисление
    UST6_DisabDays             int                        ,  --Количество календарных дней временной нетрудоспособности
    UST6_NoSalDays             int                        ,  --Количество календарных дней без сохранения зарплаты
    UST6_EmplDays              int                        ,  --Количество дней пребывания в трудовых отношениях
    UST6_VocDays               int                        ,  --Количество дней календарных дней отпуска в связи с беремменостью и родами
    UST6_TotalSm               numeric(16,2)              ,  --Общая сумма начиселнной зарплаты/дохода (всего с начала отчетного месяца)
    UST6_MaxSm                 numeric(16,2)              ,  --Cумма начиселнной зарплаты/дохода в границах макс. величины, на которую начисляется взнос
    UST6_DiffSm                numeric(16,2)              ,  --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
    UST6_WithHeldUSTSm         numeric(16,2)              ,  --Cумма удержанного единого взноса
    UST6_AccrUSTSm             numeric(16,2)              ,  --Cумма начисленного единого взноса
    UST6_WB                    int                        ,  --Признак наличия трудовой книжки(1 - да, 0 - нет)
    UST6_SpecExp               int                        ,  --Признак наличия спецстажа(1 - да, 0 - нет)
    UST6_PWT                   int                        ,  --Признак неполного рабочего времени(1 - да, 0 - нет)
    UST6_NWP                   int                           --Признак нового рабочего места(1 - да, 0 - нет)
 CONSTRAINT [PK_UST6.UST6] PRIMARY KEY CLUSTERED 
 (
	[UST6_Id] ASC
 ),
 CONSTRAINT FK_UST6_USTCt_Id_USTCt_USTCt_Id FOREIGN KEY (UST6_USTCt_Id)     
    REFERENCES dbo.USTCt (USTCt_Id)
)


