/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы SickList*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSickListUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSickListUpdate];
GO
Create Procedure [dbo].[spSickListUpdate]
	@inSickList_Id             int,
    @inSickList_PersCard_Id    int,
    @inSickList_RefDep_Id      int,
    @inSickList_Date           date,
    @inSickList_DaysEntprs     int,
    @inSickList_SmEntprs       numeric(10,2),
    @inSickList_DaysSocInsrnc  int,          
    @inSickList_SmSocInsrnc    numeric(10,2),
    @inSickList_PayDate        date,
    @inSickList_DaysTmpDis     int,
    @inSickList_ResSm          numeric(10,2)
AS                            
BEGIN
	UPDATE SickList SET
    SickList_PersCard_Id   = @inSickList_PersCard_Id,
    SickList_RefDep_Id     = @inSickList_RefDep_Id,
    SickList_Date          = @inSickList_Date,
    SickList_DaysEntprs    = @inSickList_DaysEntprs,
    SickList_SmEntprs      = @inSickList_SmEntprs,
    SickList_DaysSocInsrnc = @inSickList_DaysSocInsrnc,          
    SickList_SmSocInsrnc   = @inSickList_SmSocInsrnc,
    SickList_PayDate       = @inSickList_PayDate,
    SickList_DaysTmpDis    = @inSickList_DaysTmpDis,
    SickList_ResSm         = @inSickList_ResSm
    WHERE SickList_Id = @inSickList_Id;
END
