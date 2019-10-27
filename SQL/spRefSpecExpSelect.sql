/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefSpecExp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefSpecExpSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefSpecExpSelect];
GO
Create Procedure [dbo].[spRefSpecExpSelect]
	@inRefSpecExp_Id int = 0  --id   
AS                            
BEGIN
    SELECT *
      FROM RefSpecExp
     WHERE (RefSpecExp_Id = @inRefSpecExp_Id or @inRefSpecExp_Id = 0) 
END
