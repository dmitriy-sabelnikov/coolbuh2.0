/****** Script Date: 27.04.2021 9:00:22 ******/
/*Удаление строки из таблицы UnionReportT2*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT2Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportT2Delete];
GO
Create Procedure [dbo].[spUnionReportT2Delete]
	@inUnionReportT2_CtId      int = 0      --id каталога

AS                            
BEGIN
  SET NOCOUNT ON

  DELETE 
    FROM UnionReportT2
   WHERE UnionReportT2_CtId = @inUnionReportT2_CtId or @inUnionReportT2_CtId = 0;
 
END
