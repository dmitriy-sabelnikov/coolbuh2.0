/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefPensAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefGradeAllwncUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefGradeAllwncUpdate];
GO
Create Procedure [dbo].[spRefGradeAllwncUpdate]
    @inRefGradeAllwnc_Id             int                       , --id 
    @inRefGradeAllwnc_Cd             varchar(25)               , --Код
    @inRefGradeAllwnc_Nm             varchar(50)               , --Наименование
    @inRefGradeAllwnc_Pct            numeric(5,2)              , --процент
    @inRefGradeAllwnc_Grade          int                      , --Условие применения. Классность
    @inRefGradeAllwnc_RefDep_Id      int                      , --Условие применения. Подразделение
    @inRefGradeAllwnc_Flg             int                         --Флаги
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE RefGradeAllwnc SET
           RefGradeAllwnc_Cd         = @inRefGradeAllwnc_Cd,
           RefGradeAllwnc_Nm         = @inRefGradeAllwnc_Nm,
           RefGradeAllwnc_Pct        = @inRefGradeAllwnc_Pct,
           RefGradeAllwnc_Grade      = @inRefGradeAllwnc_Grade, 
           RefGradeAllwnc_RefDep_Id  = @inRefGradeAllwnc_RefDep_Id, 
           RefGradeAllwnc_Flg        = @inRefGradeAllwnc_Flg
    WHERE RefGradeAllwnc_Id = @inRefGradeAllwnc_Id;
END
