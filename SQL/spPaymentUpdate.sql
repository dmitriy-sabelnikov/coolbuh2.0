/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы Payment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPaymentUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spPaymentUpdate];
GO
Create Procedure [dbo].[spPaymentUpdate]
    @inPayment_Id                int, --id 
	@inPayment_PersCard_Id       int, 
	@inPayment_Date              date,
	@inPayment_Type              int,
	@inPayment_Amt               numeric(10,2),
	@inPayment_Price             numeric(10,2),
	@inPayment_Sm                numeric(10,2)
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE Payment SET
	    Payment_PersCard_Id = @inPayment_PersCard_Id,
	    Payment_Date        = @inPayment_Date,
	    Payment_Type        = @inPayment_Type,
	    Payment_Amt         = @inPayment_Amt,
	    Payment_Price       = @inPayment_Price,
	    Payment_Sm          = @inPayment_Sm
    WHERE Payment_Id = @inPayment_Id;
END
