/****** Script Date: 19.03.2018 9:00:22 ******/
/*�������� ������ �� ������� RefMinSalary*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefMinSalaryDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefMinSalaryDelete];
GO
Create Procedure [dbo].[spRefMinSalaryDelete]
	@inRefMinSalary_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM RefMinSalary
	 WHERE RefMinSalary_Id = @inRefMinSalary_Id;
END
