/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы AddPayment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddPaymentDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spAddPaymentDelete];
GO
Create Procedure [dbo].[spAddPaymentDelete]
	@inAddPayment_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM AddPayment
	 WHERE AddPayment_Id = @inAddPayment_Id;
END
