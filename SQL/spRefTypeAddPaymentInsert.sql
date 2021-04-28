/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefTypeAddPayment*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefTypeAddPaymentInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefTypeAddPaymentInsert];
GO
Create Procedure [dbo].[spRefTypeAddPaymentInsert] 
	@inRefTypeAddPayment_Cd   nvarchar(25),  --Код  
	@inRefTypeAddPayment_Nm   nvarchar(250), --Наименование 
        @outId                    int output
AS                            
BEGIN
  SET NOCOUNT ON 

    insert into RefTypeAddPayment (RefTypeAddPayment_Cd, RefTypeAddPayment_Nm) values (@inRefTypeAddPayment_Cd, @inRefTypeAddPayment_Nm);
    select @outId=coalesce(IDENT_CURRENT ('RefTypeAddPayment'),0);
END