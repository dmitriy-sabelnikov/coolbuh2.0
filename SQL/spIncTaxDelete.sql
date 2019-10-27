/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы IncTax*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spIncTaxDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spIncTaxDelete];
GO
Create Procedure [dbo].[spIncTaxDelete]
	@inIncTax_Id   int           --id  
AS                            
BEGIN
	DELETE 
	  FROM IncTax
	 WHERE IncTax_Id = @inIncTax_Id;
END
