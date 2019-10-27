/****** Script Date: 19.03.2018 9:00:22 ******/
/*������� �� ������� SalBalance*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSalBalanceSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSalBalanceSelect];
GO
Create Procedure [dbo].[spSalBalanceSelect]
	@inSalBalance_Id          int = 0,          --id   
	@inSalBalance_PersCard_Id   int = 0,          --id �������������
    @inSalBalance_DateBeg     date = null,      --����
    @inSalBalance_DateEnd     date = null       --����

AS                            
BEGIN
    SELECT *
      FROM SalBalance
     WHERE (SalBalance_Id = @inSalBalance_Id or @inSalBalance_Id = 0)
       and (SalBalance_PersCard_Id = @inSalBalance_PersCard_Id or @inSalBalance_PersCard_Id = 0)
       and (SalBalance_Date between @inSalBalance_DateBeg and @inSalBalance_DateEnd 
            or coalesce(@inSalBalance_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inSalBalance_DateEnd, '1900-01-01') = '1900-01-01') 
END
