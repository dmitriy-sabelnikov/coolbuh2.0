/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы SalBalance*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSalBalanceDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spSalBalanceDelete];
GO
Create Procedure [dbo].[spSalBalanceDelete]
	@inSalBalance_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM SalBalance
	 WHERE SalBalance_Id = @inSalBalance_Id;
END
