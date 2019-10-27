--/****** Object:  Table [dbo].[DFCt]    Script Date: 19.03.2018 8:58:01 ******/
--1ДФ. Каталог
IF OBJECT_ID(N'[DFCt]','U') IS NULL
CREATE TABLE [dbo].[DFCt]
(
	DFCt_Id             int IDENTITY(1,1)  NOT NULL,
	DFCt_Date           Date               NOT NULL,  --Дата ЕСВ
	DFCt_Nmr            int                NOT NULL,  --Номер
  DFCt_Nm             Varchar(100)	            ,  --Наименование
	DFCt_DateClc        DateTime	                ,  --Дата расчета
	DFCt_Flg            int	                       --Флаги
 CONSTRAINT [PK_DFCt.DFCt] PRIMARY KEY CLUSTERED 
 (
	[DFCt_Id] ASC
 )
)


