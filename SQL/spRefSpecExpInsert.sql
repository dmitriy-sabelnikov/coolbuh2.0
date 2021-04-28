/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefSpecExp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefSpecExpInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefSpecExpInsert];
GO
Create Procedure [dbo].[spRefSpecExpInsert] 
	@inRefSpecExp_Cd        nvarchar(25),  --Код спецстажа  
	@inRefSpecExp_C_PID     nvarchar(25),  --Код основания для учета спецстажа 
	@inRefSpecExp_Name      nvarchar(250), --Полное наименование
        @outId                  int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into RefSpecExp (RefSpecExp_Cd, RefSpecExp_C_PID, RefSpecExp_Name) 
	                values (@inRefSpecExp_Cd, @inRefSpecExp_C_PID, @inRefSpecExp_Name);
    select @outId=coalesce(IDENT_CURRENT ('RefSpecExp'),0);
END