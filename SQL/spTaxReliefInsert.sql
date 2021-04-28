/****** Script Date: 19.03.2018 9:00:22 ******/
/*������� � ������� TaxRelief*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTaxReliefInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spTaxReliefInsert];
GO
Create Procedure [dbo].[spTaxReliefInsert] 
    @inTaxRelief_PersCard_Id  int               ,  --������ �� �������� ���������
    @inTaxRelief_PerBeg       Date	        ,  --������ ������
    @inTaxRelief_PerEnd       Date              ,  --������ �����
    @inTaxRelief_Koef         numeric(10,2)        --�����������
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into TaxRelief (TaxRelief_PersCard_Id, TaxRelief_PerBeg, TaxRelief_PerEnd, TaxRelief_Koef) 
	 values (@inTaxRelief_PersCard_Id, @inTaxRelief_PerBeg, @inTaxRelief_PerEnd, @inTaxRelief_Koef);
END