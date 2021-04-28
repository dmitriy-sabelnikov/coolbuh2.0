--Объединенная отчетность. Расчет таблицы 5
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT5Clc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportT5Clc];
GO
Create Procedure [dbo].[spUnionReportT5Clc]
	@inUnionReportT5_CtId  int 
AS   
  Declare @date_ust datetime;                         
BEGIN                                   
SET NOCOUNT ON

END   
