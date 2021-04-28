--/****** Object:  Table [dbo].[UnionReportCt]    Script Date: 19.03.2018 8:58:01 ******/
--Объединенная отчетность. Каталог
IF OBJECT_ID(N'[UnionReportCt]','U') IS NULL
CREATE TABLE [dbo].[UnionReportCt]
(
	UnionReportCt_Id             int IDENTITY(1,1)  NOT NULL,
	UnionReportCt_Qrt            int                NOT NULL,  --Квартал
	UnionReportCt_Year           int                NOT NULL,  --Год
	UnionReportCt_Nmr            int                NOT NULL,  --Номер
	UnionReportCt_Nm             Varchar(100)	        ,  --Наименование
	UnionReportCt_DateClc        DateTime	                ,  --Дата расчета
	UnionReportCt_Flg            int	                   --Флаги
 CONSTRAINT [PK_UnionReportCt.UnionReportCt] PRIMARY KEY CLUSTERED 
 (
	[UnionReportCt_Id] ASC
 )
)


