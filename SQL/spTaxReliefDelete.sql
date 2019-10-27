/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы TaxRelief*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTaxReliefDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spTaxReliefDelete];
GO
Create Procedure [dbo].[spTaxReliefDelete]
	@inTaxRelief_Id            int = 0,     --id ребенка  
	@inTaxRelief_PersCard_Id   int = 0      --id карточки

AS                            
BEGIN
	DELETE 
	  FROM TaxRelief
	 WHERE (TaxRelief_Id = @inTaxRelief_Id or @inTaxRelief_Id = 0)
           and (TaxRelief_PersCard_Id = @inTaxRelief_PersCard_Id or @inTaxRelief_PersCard_Id = 0);

END
