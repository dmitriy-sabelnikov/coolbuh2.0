/****** Script Date: 19.03.2018 9:00:22 ******/
/*���������� ������� TaxRelief*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spTaxReliefUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spTaxReliefUpdate];
GO
Create Procedure [dbo].[spTaxReliefUpdate]
    @inTaxRelief_Id           int,           --id ��������
    @inTaxRelief_PersCard_Id  int,           --������ �� �������� ���������
    @inTaxRelief_PerBeg       Date,          --������ ������
    @inTaxRelief_PerEnd       Date,          --������ �����
    @inTaxRelief_Koef         numeric(10,2)  --�����������
AS                            
BEGIN
	UPDATE TaxRelief SET
	  TaxRelief_PersCard_Id     = @inTaxRelief_PersCard_Id,
	  TaxRelief_PerBeg	        = @inTaxRelief_PerBeg, 
	  TaxRelief_PerEnd	        = @inTaxRelief_PerEnd,   
	  TaxRelief_Koef	        = @inTaxRelief_Koef   
    WHERE TaxRelief_Id = @inTaxRelief_Id;
END
