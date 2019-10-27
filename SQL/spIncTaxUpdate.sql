/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы IncTax*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spIncTaxUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spIncTaxUpdate];
GO
Create Procedure [dbo].[spIncTaxUpdate]
    @inIncTax_Id              int,
    @inIncTax_PersCard_Id     int,
    @inIncTax_Date            date,
    @inIncTax_Sm              numeric(10,2)
AS                            
BEGIN
	UPDATE IncTax SET
           IncTax_PersCard_Id  = @inIncTax_PersCard_Id,
           IncTax_Date         = @inIncTax_Date,
           IncTax_Sm           = @inIncTax_Sm
    WHERE IncTax_Id = @inIncTax_Id;
END

