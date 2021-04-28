/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы RefTypeAddPayment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefTypeAddPaymentDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefTypeAddPaymentDelete];
GO
Create Procedure [dbo].[spRefTypeAddPaymentDelete]
	@inRefTypeAddPayment_Id   int           --id  
AS                            
BEGIN
  SET NOCOUNT ON 

	DELETE 
	  FROM RefTypeAddPayment
	 WHERE RefTypeAddPayment_Id = @inRefTypeAddPayment_Id;
END
