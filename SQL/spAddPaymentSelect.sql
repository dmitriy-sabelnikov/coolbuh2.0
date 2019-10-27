/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы AddPayment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddPaymentSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spAddPaymentSelect];
GO
Create Procedure [dbo].[spAddPaymentSelect]
	@inAddPayment_Id                int = 0,          --id   
        @inAddPayment_TypeAddPayment_Id int = 0,          --id
        @inAddPayment_DateBeg           date = null,      --дата
        @inAddPayment_DateEnd           date = null       --дата

AS                            
BEGIN
    SELECT *
      FROM AddPayment
     WHERE (AddPayment_Id = @inAddPayment_Id or @inAddPayment_Id = 0)
       and (AddPayment_TypeAddPayment_Id = @inAddPayment_TypeAddPayment_Id or @inAddPayment_TypeAddPayment_Id = 0)
       and (AddPayment_Date between @inAddPayment_DateBeg and @inAddPayment_DateEnd 
            or coalesce(@inAddPayment_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inAddPayment_DateEnd, '1900-01-01') = '1900-01-01') 
END
