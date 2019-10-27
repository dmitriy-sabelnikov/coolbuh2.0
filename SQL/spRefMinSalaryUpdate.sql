/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefMinSalary*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefMinSalaryUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefMinSalaryUpdate];
GO
Create Procedure [dbo].[spRefMinSalaryUpdate]
	@inRefMinSalary_Id               int,
    @inRefMinSalary_PerBeg           date,
    @inRefMinSalary_PerEnd           date,
    @inRefMinSalary_Sm               numeric(16,2)
AS                            
BEGIN
	UPDATE RefMinSalary SET
      RefMinSalary_PerBeg   = @inRefMinSalary_PerBeg,
      RefMinSalary_PerEnd   = @inRefMinSalary_PerEnd,
      RefMinSalary_Sm       = @inRefMinSalary_Sm
    WHERE RefMinSalary_Id = @inRefMinSalary_Id;
END
