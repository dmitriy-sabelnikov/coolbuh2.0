/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefGradeAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefGradeAllwncSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefGradeAllwncSelect];
GO
Create Procedure [dbo].[spRefGradeAllwncSelect]
	@inRefGradeAllwnc_Id   int = 0       --id   
AS                            
BEGIN
    SELECT *
      FROM RefGradeAllwnc
     WHERE (RefGradeAllwnc_Id = @inRefGradeAllwnc_Id or @inRefGradeAllwnc_Id = 0) 
END
