/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы TaxRelief*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTaxReliefUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spTaxReliefUpdate];
GO
Create Procedure [dbo].[spTaxReliefUpdate]
    @inTaxRelief_Id           int,           --id карточки
    @inTaxRelief_PersCard_Id  int,           --Ссылка на карточку работника
    @inTaxRelief_PerBeg       Date,          --Период начало
    @inTaxRelief_PerEnd       Date,          --Период конец
    @inTaxRelief_Koef         numeric(10,2)  --Коэффициент
AS                            
BEGIN
	UPDATE TaxRelief SET
	  TaxRelief_PersCard_Id     = @inTaxRelief_PersCard_Id,
	  TaxRelief_PerBeg	        = @inTaxRelief_PerBeg, 
	  TaxRelief_PerEnd	        = @inTaxRelief_PerEnd,   
	  TaxRelief_Koef	        = @inTaxRelief_Koef   
    WHERE TaxRelief_Id = @inTaxRelief_Id;
END
