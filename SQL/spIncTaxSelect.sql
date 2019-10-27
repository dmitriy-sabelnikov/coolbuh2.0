/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы IncTax*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spIncTaxSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spIncTaxSelect];
GO
Create Procedure [dbo].[spIncTaxSelect]
	@inIncTax_Id          int = 0,          --id   
        @inIncTax_DateBeg     date = null,      --дата
        @inIncTax_DateEnd     date = null       --дата
AS                            
BEGIN
    SELECT *
      FROM IncTax
     WHERE (IncTax_Id = @inIncTax_Id or @inIncTax_Id = 0)
       and (IncTax_Date between @inIncTax_DateBeg and @inIncTax_DateEnd 
            or coalesce(@inIncTax_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inIncTax_DateEnd, '1900-01-01') = '1900-01-01') 

END
