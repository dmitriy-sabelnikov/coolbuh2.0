/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу Vocation*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVocationInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spVocationInsert];
GO
Create Procedure [dbo].[spVocationInsert] 
	@inVocation_PersCard_Id     int,
	@inVocation_RefDep_Id       int,
	@inVocation_Date            date,
	@inVocation_Days            int,
	@inVocation_Sm              numeric(10, 2),
        @inVocation_PayDate         date,
        @outId                      int output
AS                            
BEGIN
    insert into Vocation (Vocation_PersCard_Id, Vocation_RefDep_Id, Vocation_Date, Vocation_Days, Vocation_Sm, Vocation_PayDate) 
	      values (@inVocation_PersCard_Id, @inVocation_RefDep_Id, @inVocation_Date, @inVocation_Days, @inVocation_Sm, @inVocation_PayDate);
    select @outId=coalesce(IDENT_CURRENT ('Vocation'),0);
END

    