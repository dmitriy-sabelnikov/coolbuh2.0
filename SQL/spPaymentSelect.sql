/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы Payment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPaymentSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spPaymentSelect];
GO
Create Procedure [dbo].[spPaymentSelect]
    @inPayment_Id          int = 0,      --id  
    @inPayment_Type        int = 0,      --Тип выплаты
    @inPayment_DateBeg     date = null,  --дата
    @inPayment_DateEnd     date = null   --дата 
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM Payment (NOLOCK)
     WHERE (Payment_Id = @inPayment_Id or @inPayment_Id = 0) 
	   and (Payment_Type = @inPayment_Type or @inPayment_Type = 0)
       and (Payment_Date between @inPayment_DateBeg and @inPayment_DateEnd 
            or coalesce(@inPayment_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inPayment_DateEnd, '1900-01-01') = '1900-01-01') 
END
