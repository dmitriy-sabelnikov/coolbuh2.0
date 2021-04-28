/****** Script Date: 27.04.2021 9:00:22 ******/
/*Выборка из таблицы UnionReportT1*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT1Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUnionReportT1Select];
GO
Create Procedure [dbo].[spUnionReportT1Select]
	@inUnionReportT1_CtId    int = 0           --id каталога
AS                            
BEGIN
    SET NOCOUNT ON

    SELECT *
      FROM UnionReportT1
     WHERE (UnionReportT1_CtId = @inUnionReportT1_CtId or @inUnionReportT1_CtId = 0)
END
