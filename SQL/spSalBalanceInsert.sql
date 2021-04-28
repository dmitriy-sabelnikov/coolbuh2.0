/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу SalBalance*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSalBalanceInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSalBalanceInsert];
GO
Create Procedure [dbo].[spSalBalanceInsert] 
    @inSalBalance_PersCard_Id           int,
    @inSalBalance_Date                  date,
    @inSalBalance_BegMonthSm            numeric(10,2),
    @inSalBalance_EndMonthSm            numeric(10,2),
    @inSalBalance_Flg                   int,
    @outId                              int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into SalBalance (SalBalance_PersCard_Id, SalBalance_Date, SalBalance_BegMonthSm, SalBalance_EndMonthSm, SalBalance_Flg) 
	      values (@inSalBalance_PersCard_Id, @inSalBalance_Date, @inSalBalance_BegMonthSm, @inSalBalance_EndMonthSm, @inSalBalance_Flg);
    select @outId=coalesce(IDENT_CURRENT ('SalBalance'),0);
END