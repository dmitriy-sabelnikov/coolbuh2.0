/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы AddPayment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddPaymentUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spAddPaymentUpdate];
GO
Create Procedure [dbo].[spAddPaymentUpdate]
    @inAddPayment_Id                    int,
    @inAddPayment_PersCard_Id           int,
    @inAddPayment_Date                  date,
    @inAddPayment_TypeAddPayment_Id     int,
    @inAddPayment_Sm                    numeric(10,2)
AS                            
BEGIN
    UPDATE AddPayment SET
      AddPayment_PersCard_Id           = @inAddPayment_PersCard_Id,
      AddPayment_Date                  = @inAddPayment_Date,
      AddPayment_TypeAddPayment_Id     = @inAddPayment_TypeAddPayment_Id,
      AddPayment_Sm                    = @inAddPayment_Sm                
    WHERE AddPayment_Id = @inAddPayment_Id;
END
