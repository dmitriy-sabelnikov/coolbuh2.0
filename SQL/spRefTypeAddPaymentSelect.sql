/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefTypeAddPayment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefTypeAddPaymentSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefTypeAddPaymentSelect];
GO
Create Procedure [dbo].[spRefTypeAddPaymentSelect]
	@inRefTypeAddPayment_Id   int = 0       --id  
AS                            
BEGIN
    SELECT *
      FROM RefTypeAddPayment
     WHERE (RefTypeAddPayment_Id = @inRefTypeAddPayment_Id or @inRefTypeAddPayment_Id = 0) 
END
