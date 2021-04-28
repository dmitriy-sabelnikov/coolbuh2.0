/****** Script Date: 27.04.2021 9:00:22 ******/
/*Удаление строки из таблицы UnionReportT1*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT1Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportT1Delete];
GO
Create Procedure [dbo].[spUnionReportT1Delete]
	@inUnionReportT1_CtId      int = 0      --id каталога

AS                            
BEGIN
  SET NOCOUNT ON

  DELETE 
    FROM UnionReportT1
   WHERE UnionReportT1_CtId = @inUnionReportT1_CtId or @inUnionReportT1_CtId = 0;

END
