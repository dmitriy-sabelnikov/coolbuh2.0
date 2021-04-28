/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefOth*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefOthAllwncInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefOthAllwncInsert];
GO
Create Procedure [dbo].[spRefOthAllwncInsert] 
    @inRefOthAllwnc_Cd             varchar(25)               , --Код
    @inRefOthAllwnc_Nm             varchar(50)               , --Наименование
    @inRefOthAllwnc_Pct            numeric(5,2)              , --процент
    @inRefOthAllwnc_Flg            int                       , --Флаги
    @outId                         int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into RefOthAllwnc (RefOthAllwnc_Cd, RefOthAllwnc_Nm, RefOthAllwnc_Pct, RefOthAllwnc_Flg) 
	      values (@inRefOthAllwnc_Cd, @inRefOthAllwnc_Nm, @inRefOthAllwnc_Pct, @inRefOthAllwnc_Flg);
    select @outId=coalesce(IDENT_CURRENT ('RefOthAllwnc'),0);
END
