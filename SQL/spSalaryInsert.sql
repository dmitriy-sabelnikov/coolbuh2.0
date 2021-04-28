/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу Salary*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSalaryInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSalaryInsert];
GO
Create Procedure [dbo].[spSalaryInsert]
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
	@inSalary_ResSm          numeric(10,2)   ,  --Итоговая сумма
        @outId                   int output
AS                            
BEGIN
  SET NOCOUNT ON 

    insert into Salary (Salary_PersCard_Id, Salary_RefDep_Id, Salary_Date, Salary_Days,Salary_Hours, Salary_BaseSm,
	         Salary_PensId, Salary_PensPct, Salary_PensSm, Salary_ExpId, Salary_ExpPct, Salary_ExpSm, 
                 Salary_GradeId, Salary_GradePct, Salary_GradeSm, Salary_OthId, Salary_OthPct, Salary_OthSm, 
                 Salary_KTU, Salary_KTUSm, Salary_ResSm) 
	 values (@inSalary_PersCard_Id, @inSalary_RefDep_Id, @inSalary_Date, @inSalary_Days,@inSalary_Hours, @inSalary_BaseSm,
	         @inSalary_PensId, @inSalary_PensPct, @inSalary_PensSm, @inSalary_ExpId, @inSalary_ExpPct, @inSalary_ExpSm, 
                 @inSalary_GradeId, @inSalary_GradePct, @inSalary_GradeSm, @inSalary_OthId, @inSalary_OthPct, @inSalary_OthSm, 
                 @inSalary_KTU, @inSalary_KTUSm, @inSalary_ResSm  
	  );
    select @outId=coalesce(IDENT_CURRENT ('Salary'),0);
END

 