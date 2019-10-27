--/****** Object:  Table [dbo].[USTCt]    Script Date: 19.03.2018 8:58:01 ******/
--ЕСВ. Каталог
IF OBJECT_ID(N'[USTCt]','U') IS NULL
CREATE TABLE [dbo].[USTCt]
(
	USTCt_Id             int IDENTITY(1,1)  NOT NULL,
	USTCt_Date           Date               NOT NULL,  --Дата ЕСВ
	USTCt_Nmr            int                NOT NULL,  --Номер
        USTCt_Nm             Varchar(100)	        ,  --Наименование
	USTCt_DateClc        DateTime	                ,  --Дата расчета
	USTCt_Flg            int	                   --Флаги
 CONSTRAINT [PK_USTCt.USTCt] PRIMARY KEY CLUSTERED 
 (
	[USTCt_Id] ASC
 )
)


