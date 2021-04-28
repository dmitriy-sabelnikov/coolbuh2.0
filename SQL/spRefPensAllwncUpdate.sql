/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefPensAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefPensAllwncUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefPensAllwncUpdate];
GO
Create Procedure [dbo].[spRefPensAllwncUpdate]
    @inRefPensAllwnc_Id             int                       , --id 
    @inRefPensAllwnc_Cd             varchar(25)               , --Код
    @inRefPensAllwnc_Nm             varchar(50)               , --Наименование
    @inRefPensAllwnc_Pct            numeric(5,2)              , --процент
    @inRefPensAllwnc_Flg            int                         --Флаги
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE RefPensAllwnc SET
           RefPensAllwnc_Cd  = @inRefPensAllwnc_Cd,
           RefPensAllwnc_Nm  = @inRefPensAllwnc_Nm,
           RefPensAllwnc_Pct = @inRefPensAllwnc_Pct,
           RefPensAllwnc_Flg = @inRefPensAllwnc_Flg
    WHERE RefPensAllwnc_Id = @inRefPensAllwnc_Id;
END
