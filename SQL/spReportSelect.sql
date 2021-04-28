/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы Report*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spReportSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spReportSelect];
GO
Create Procedure [dbo].[spReportSelect]
AS                            
BEGIN
  SET NOCOUNT ON 

    SELECT *
      FROM Report (NOLOCK)
END
