/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefTypeAddPayment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefTypeAddPaymentUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefTypeAddPaymentUpdate];
GO
Create Procedure [dbo].[spRefTypeAddPaymentUpdate]
	@inRefTypeAddPayment_Id   int,           --id  
	@inRefTypeAddPayment_Cd   nvarchar(25),  --Код  
	@inRefTypeAddPayment_Nm   nvarchar(250)  --Наименование 
AS                            
BEGIN
	UPDATE RefTypeAddPayment SET
		RefTypeAddPayment_Cd   = @inRefTypeAddPayment_Cd, 
		RefTypeAddPayment_Nm   = @inRefTypeAddPayment_Nm
    WHERE RefTypeAddPayment_Id = @inRefTypeAddPayment_Id;
END
