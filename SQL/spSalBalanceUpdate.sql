/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы SalBalance*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSalBalanceUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSalBalanceUpdate];
GO
Create Procedure [dbo].[spSalBalanceUpdate]
	@inSalBalance_Id                    int,
    @inSalBalance_PersCard_Id           int,
    @inSalBalance_Date                  date,
    @inSalBalance_BegMonthSm            numeric(10,2),
    @inSalBalance_EndMonthSm            numeric(10,2),
    @inSalBalance_Flg                   int
AS                            
BEGIN
	UPDATE SalBalance SET
    SalBalance_PersCard_Id           = @inSalBalance_PersCard_Id,
    SalBalance_Date                  = @inSalBalance_Date,
	SalBalance_BegMonthSm            = @inSalBalance_BegMonthSm,
	SalBalance_EndMonthSm            = @inSalBalance_EndMonthSm,
	SalBalance_Flg                   = @inSalBalance_Flg
    WHERE SalBalance_Id = @inSalBalance_Id;
END
