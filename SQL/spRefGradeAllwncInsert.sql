/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefGradeAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefGradeAllwncInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefGradeAllwncInsert];
GO
Create Procedure [dbo].[spRefGradeAllwncInsert] 
    @inRefGradeAllwnc_Cd             varchar(25)               , --Код
    @inRefGradeAllwnc_Nm             varchar(50)               , --Наименование
    @inRefGradeAllwnc_Pct            numeric(5,2)              , --процент
    @inRefGradeAllwnc_Grade          int                       , --Условие применения. Классность
    @inRefGradeAllwnc_RefDep_Id      int                       , --Условие применения. Подразделение
    @inRefGradeAllwnc_Flg            int                       , --Флаги
    @outId                           int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into RefGradeAllwnc (RefGradeAllwnc_Cd, RefGradeAllwnc_Nm, RefGradeAllwnc_Pct, RefGradeAllwnc_Grade, RefGradeAllwnc_RefDep_Id, RefGradeAllwnc_Flg) 
	      values (@inRefGradeAllwnc_Cd, @inRefGradeAllwnc_Nm, @inRefGradeAllwnc_Pct, @inRefGradeAllwnc_Grade, @inRefGradeAllwnc_RefDep_Id, @inRefGradeAllwnc_Flg);
    select @outId=coalesce(IDENT_CURRENT ('RefGradeAllwnc'),0);
END