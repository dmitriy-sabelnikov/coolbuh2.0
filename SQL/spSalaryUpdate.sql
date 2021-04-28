/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы Salary*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSalaryUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSalaryUpdate];
GO
Create Procedure [dbo].[spSalaryUpdate]
	@inSalary_Id             int             ,  --id
	@inSalary_PersCard_Id    int             ,  --Ссылка на карточку работника
	@inSalary_RefDep_Id      int             ,  --Ссылка на справочник подразделений
	@inSalary_Date           date            ,  --Дата
	@inSalary_Days           int             ,  --Отработанные дни
	@inSalary_Hours          numeric(5,2)    ,  --Отработанные часы
	@inSalary_BaseSm         numeric(10,2)   ,  --Основная зарплата
	@inSalary_PensId         int             ,  --Доплата пенсионеру(id доплаты из Allowance)
	@inSalary_PensPct        numeric(5,2)    ,  --Доплата пенсионеру(процент)
	@inSalary_PensSm         numeric(10,2)   ,  --Доплата пенсионеру(сумма)
	@inSalary_ExpId          int             ,  --Доплата за стаж(id доплаты из Allowance)
	@inSalary_ExpPct         numeric(5,2)    ,  --Доплата за стаж(процент)
	@inSalary_ExpSm          numeric(10,2)   ,  --Доплата за стаж(сумма)
	@inSalary_GradeId        int             ,  --Доплата за класность(id доплаты из Allowance)
	@inSalary_GradePct       numeric(5,2)    ,  --Доплата за класность(процент)
	@inSalary_GradeSm        numeric(10,2)   ,  --Доплата за класность(сумма)
	@inSalary_OthId          int             ,  --Другие доплаты(id доплаты из Allowance)
	@inSalary_OthPct         numeric(5,2)    ,  --Другие доплаты(процент)
	@inSalary_OthSm          numeric(10,2)   ,  --Другие доплаты(сумма)
	@inSalary_KTU            numeric(5,2)    ,  --КТУ
	@inSalary_KTUSm          numeric(10,2)   ,  --Доплата за КТУ
        @inSalary_ResSm          numeric(10,2)      --Итоговая сумма
AS                            
BEGIN
  SET NOCOUNT ON 

	UPDATE Salary SET
	  Salary_PersCard_Id = @inSalary_PersCard_Id,
	  Salary_RefDep_Id    = @inSalary_RefDep_Id,  
	  Salary_Date         = @inSalary_Date,
	  Salary_Days         = @inSalary_Days,       
	  Salary_Hours        = @inSalary_Hours,      
	  Salary_BaseSm       = @inSalary_BaseSm,     
	  Salary_PensId       = @inSalary_PensId,     
	  Salary_PensPct      = @inSalary_PensPct,     
	  Salary_PensSm       = @inSalary_PensSm,     
	  Salary_ExpId        = @inSalary_ExpId,      
	  Salary_ExpPct       = @inSalary_ExpPct,      
	  Salary_ExpSm        = @inSalary_ExpSm,      
	  Salary_GradeId      = @inSalary_GradeId,    
	  Salary_GradePct     = @inSalary_GradePct,    
	  Salary_GradeSm      = @inSalary_GradeSm,    
	  Salary_OthId        = @inSalary_OthId,      
	  Salary_OthPct       = @inSalary_OthPct,      
	  Salary_OthSm        = @inSalary_OthSm,      
	  Salary_KTU          = @inSalary_KTU,        
	  Salary_KTUSm        = @inSalary_KTUSm,
          Salary_ResSm        = @inSalary_ResSm
    WHERE Salary_Id = @inSalary_Id;
END
