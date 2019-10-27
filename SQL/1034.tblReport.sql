--/****** Object:  Table [dbo].[Report]    Script Date: 19.03.2018 8:58:01 ******/
--Отчеты
IF OBJECT_ID(N'[Report]','U') IS NULL
begin
CREATE TABLE [dbo].[Report]
(
	Report_Id                int IDENTITY(1,1)      NOT NULL,
	Report_Name              varchar(255)                   , --Наименование отчета
	Report_File              varchar(255)                     --Наименование файла отчета
 CONSTRAINT [PK_Report.Report_Id] PRIMARY KEY CLUSTERED 
 (
	[Report_Id] ASC
 )
)
end; 


