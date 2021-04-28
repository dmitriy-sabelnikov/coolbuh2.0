/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefMinSalary*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefMinSalarySelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefMinSalarySelect];
GO
Create Procedure [dbo].[spRefMinSalarySelect]
	@inRefMinSalary_Id          int = 0          --id   
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM RefMinSalary (NOLOCK)
     WHERE (RefMinSalary_Id = @inRefMinSalary_Id or @inRefMinSalary_Id = 0)
END
