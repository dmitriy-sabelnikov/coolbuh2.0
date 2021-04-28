/****** Script Date: 19.03.2018 9:00:22 ******/
/*�������� ������ �� ������� Payment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPaymentDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spPaymentDelete];
GO
Create Procedure [dbo].[spPaymentDelete]
	@inPayment_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM Payment
	 WHERE Payment_Id = @inPayment_Id;
END
