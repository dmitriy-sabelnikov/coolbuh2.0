/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы UnionReportT5*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT5Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportT5Delete];
GO
Create Procedure [dbo].[spUnionReportT5Delete]
	@inUnionReportT5_CtId      int = 0      --id каталога

AS                            
BEGIN
  SET NOCOUNT ON

  DELETE 
    FROM UnionReportT5
   WHERE UnionReportT5_CtId = @inUnionReportT5_CtId or @inUnionReportT5_CtId = 0;

END
