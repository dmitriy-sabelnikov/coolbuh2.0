/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу AddPayment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddPaymentInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spAddPaymentInsert];
GO
Create Procedure [dbo].[spAddPaymentInsert] 
    @inAddPayment_PersCard_Id           int,
    @inAddPayment_Date                  date,
    @inAddPayment_TypeAddPayment_Id     int,
    @inAddPayment_Sm                    numeric(10,2),
    @outId                              int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into AddPayment (AddPayment_PersCard_Id, AddPayment_Date, AddPayment_TypeAddPayment_Id, AddPayment_Sm) 
	      values (@inAddPayment_PersCard_Id, @inAddPayment_Date, @inAddPayment_TypeAddPayment_Id, @inAddPayment_Sm)
    select @outId=coalesce(IDENT_CURRENT ('AddPayment'),0);
END