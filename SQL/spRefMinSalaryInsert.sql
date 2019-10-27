/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefMinSalary*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefMinSalaryInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefMinSalaryInsert];
GO
Create Procedure [dbo].[spRefMinSalaryInsert] 
    @inRefMinSalary_PerBeg           date,
    @inRefMinSalary_PerEnd           date,
    @inRefMinSalary_Sm               numeric(16,2),
    @outId                           int output
AS                            
BEGIN
    insert into RefMinSalary (RefMinSalary_PerBeg, RefMinSalary_PerEnd, RefMinSalary_Sm) 
	      values (@inRefMinSalary_PerBeg, @inRefMinSalary_PerEnd, @inRefMinSalary_Sm);
    select @outId=coalesce(IDENT_CURRENT ('RefMinSalary'),0);
END