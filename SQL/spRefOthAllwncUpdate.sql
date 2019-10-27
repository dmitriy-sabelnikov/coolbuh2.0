/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefOthAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefOthAllwncUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefOthAllwncUpdate];
GO
Create Procedure [dbo].[spRefOthAllwncUpdate]
    @inRefOthAllwnc_Id             int                       , --id 
    @inRefOthAllwnc_Cd             varchar(25)               , --Код
    @inRefOthAllwnc_Nm             varchar(50)               , --Наименование
    @inRefOthAllwnc_Pct            numeric(5,2)              , --процент
    @inRefOthAllwnc_Flg            int                         --Флаги
AS                            
BEGIN
	UPDATE RefOthAllwnc SET
           RefOthAllwnc_Cd  = @inRefOthAllwnc_Cd,
           RefOthAllwnc_Nm  = @inRefOthAllwnc_Nm,
           RefOthAllwnc_Pct = @inRefOthAllwnc_Pct,
           RefOthAllwnc_Flg = @inRefOthAllwnc_Flg
    WHERE RefOthAllwnc_Id = @inRefOthAllwnc_Id;
END
