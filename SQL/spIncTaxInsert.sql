/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу IncTax*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spIncTaxInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spIncTaxInsert];
GO
Create Procedure [dbo].[spIncTaxInsert] 
    @inIncTax_PersCard_Id      int,
    @inIncTax_Date             date,
    @inIncTax_Sm               numeric(10,2),
    @outId                     int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into IncTax (IncTax_PersCard_Id, IncTax_Date, IncTax_Sm) 
	      values (@inIncTax_PersCard_Id, @inIncTax_Date, @inIncTax_Sm);
    select @outId=coalesce(IDENT_CURRENT ('IncTax'),0);
END



