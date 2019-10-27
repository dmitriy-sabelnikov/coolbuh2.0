/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefSpecExp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefSpecExpUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefSpecExpUpdate];
GO
Create Procedure [dbo].[spRefSpecExpUpdate]
	@inRefSpecExp_Id        int,           --id 
	@inRefSpecExp_Cd        nvarchar(25),  --Код спецстажа  
	@inRefSpecExp_C_PID     nvarchar(25),  --Краткое наименование 
	@inRefSpecExp_Name      nvarchar(250)  --Полное наименование
AS                            
BEGIN
	UPDATE RefSpecExp SET
		RefSpecExp_Cd        = @inRefSpecExp_Cd, 
		RefSpecExp_C_PID     = @inRefSpecExp_C_PID,
		RefSpecExp_Name      = @inRefSpecExp_Name
    WHERE RefSpecExp_Id = @inRefSpecExp_Id;
END
