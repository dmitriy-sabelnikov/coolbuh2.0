/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу Payment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPaymentInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spPaymentInsert];
GO
Create Procedure [dbo].[spPaymentInsert] 
	@inPayment_PersCard_Id       int, 
	@inPayment_Date              date,
	@inPayment_Type              int,
	@inPayment_Amt               numeric(10,2),
	@inPayment_Price             numeric(10,2),
        @inPayment_Sm                numeric(10,2),
        @outId                       int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into Payment (Payment_PersCard_Id, Payment_Date, Payment_Type, Payment_Amt, Payment_Price, Payment_Sm) 
	      values (@inPayment_PersCard_Id, @inPayment_Date, @inPayment_Type, @inPayment_Amt, @inPayment_Price, @inPayment_Sm);
    select @outId=coalesce(IDENT_CURRENT ('Payment'),0);
END