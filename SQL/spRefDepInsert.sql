/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefDep*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefDepInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefDepInsert];
GO
Create Procedure [dbo].[spRefDepInsert] 
	@inRefDep_Cd   nvarchar(25),  --Код подразделения  
	@inRefDep_Nm   nvarchar(250), --Наименование подразделения 
        @outId         int output
AS                            
BEGIN
    insert into RefDep (RefDep_Cd, RefDep_Nm) values (@inRefDep_Cd, @inRefDep_Nm);
    select @outId=coalesce(IDENT_CURRENT ('RefDep'),0);
END