/****** Script Date: 27.04.2021 9:00:22 ******/
/*Выборка из таблицы UnionReportCt*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportCtSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUnionReportCtSelect];
GO
Create Procedure [dbo].[spUnionReportCtSelect]
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM UnionReportCt (NOLOCK)
END
