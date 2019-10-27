/****** Script Date: 19.03.2018 9:00:22 ******/
/*¬ыборка из таблицы Salary*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSalarySelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSalarySelect];
GO
Create Procedure [dbo].[spSalarySelect]
	@inSalary_Id          int = 0,          --id строки
	@inSalary_RefDep_Id   int = 0,          --id подразделени€
        @inSalary_DateBeg     date = null,      --дата
        @inSalary_DateEnd     date = null       --дата

AS                            
BEGIN
    SELECT *
      FROM Salary
     WHERE (Salary_Id = @inSalary_Id or @inSalary_Id = 0)
       and (Salary_RefDep_Id = @inSalary_RefDep_Id or @inSalary_RefDep_Id = 0)
       and (Salary_Date between @inSalary_DateBeg and @inSalary_DateEnd 
            or coalesce(@inSalary_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inSalary_DateEnd, '1900-01-01') = '1900-01-01') 
END
