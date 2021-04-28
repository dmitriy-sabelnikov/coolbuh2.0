/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefExpAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefExpAllwncUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefExpAllwncUpdate];
GO
Create Procedure [dbo].[spRefExpAllwncUpdate]
	@inRefExpAllwnc_Id              int,          --id 
	@inRefExpAllwnc_Cd              varchar(25),  --Код
	@inRefExpAllwnc_Nm              varchar(50),  --Наименование
	@inRefExpAllwnc_Year            int,          --год 
	@inRefExpAllwnc_Mech            numeric(5,2), --Надбавка механикам
        @inRefExpAllwncMech_RefDep_Id   int,          --Условие применения для надбавки механикам. Подразделение
	@inRefExpAllwnc_Oth             numeric(5,2), --Надбавка другим
        @inRefExpAllwnc_Flg            int           --Флаг  
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE RefExpAllwnc SET
           RefExpAllwnc_Cd            = @inRefExpAllwnc_Cd,         
           RefExpAllwnc_Nm            = @inRefExpAllwnc_Nm,         
           RefExpAllwnc_Year          = @inRefExpAllwnc_Year,          
           RefExpAllwnc_Mech          = @inRefExpAllwnc_Mech,          
           RefExpAllwncMech_RefDep_Id = @inRefExpAllwncMech_RefDep_Id, 
           RefExpAllwnc_Oth           = @inRefExpAllwnc_Oth,           
           RefExpAllwnc_Flg           = @inRefExpAllwnc_Flg          
    WHERE RefExpAllwnc_Id = @inRefExpAllwnc_Id;
END
