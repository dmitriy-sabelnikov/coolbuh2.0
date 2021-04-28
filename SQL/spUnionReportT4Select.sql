/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы UnionReportT4*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT4Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUnionReportT4Select];
GO
Create Procedure [dbo].[spUnionReportT4Select]
	@inUnionReportT4_CtId    int = 0           --id каталога
AS                            
BEGIN
    SET NOCOUNT ON

    SELECT *
      FROM UnionReportT4 (NOLOCK)
     WHERE (UnionReportT4_CtId = @inUnionReportT4_CtId or @inUnionReportT4_CtId = 0)
END
