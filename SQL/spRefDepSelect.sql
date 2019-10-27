/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefDep*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefDepSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefDepSelect];
GO
Create Procedure [dbo].[spRefDepSelect]
	@inRefDep_Id   int = 0       --id подразделения  
AS                            
BEGIN
    SELECT *
      FROM RefDep
     WHERE (RefDep_Id = @inRefDep_Id or @inRefDep_Id = 0) 
END
