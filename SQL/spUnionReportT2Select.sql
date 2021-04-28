/****** Script Date: 27.04.2021 9:00:22 ******/
/*Выборка из таблицы UnionReportT2*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT2Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUnionReportT2Select];
GO
Create Procedure [dbo].[spUnionReportT2Select]
	@inUnionReportT2_CtId    int = 0           --id каталога
AS                            
BEGIN
    SET NOCOUNT ON

    SELECT *
      FROM UnionReportT2 (NOLOCK)
     WHERE (UnionReportT2_CtId = @inUnionReportT2_CtId or @inUnionReportT2_CtId = 0)
END
