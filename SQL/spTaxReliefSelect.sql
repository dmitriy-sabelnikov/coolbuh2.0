/****** Script Date: 19.03.2018 9:00:22 ******/
/*������� �� ������� TaxRelief*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTaxReliefSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spTaxReliefSelect];
GO
Create Procedure [dbo].[spTaxReliefSelect]
	@inTaxRelief_Id            int = 0,     --id   
	@inTaxRelief_PersCard_Id   int = 0      --id ��������

AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM TaxRelief (NOLOCK)
     WHERE (TaxRelief_Id = @inTaxRelief_Id or @inTaxRelief_Id = 0) 
       and (TaxRelief_PersCard_Id = @inTaxRelief_PersCard_Id or @inTaxRelief_PersCard_Id = 0)
END