/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу SickList*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSickListInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSickListInsert];
GO
Create Procedure [dbo].[spSickListInsert] 
    @inSickList_PersCard_Id    int,
    @inSickList_RefDep_Id      int,
    @inSickList_Date           date,
    @inSickList_DaysEntprs     int,
    @inSickList_SmEntprs       numeric(10,2),
    @inSickList_DaysSocInsrnc  int,          
    @inSickList_SmSocInsrnc    numeric(10,2),
    @inSickList_PayDate        date,
    @inSickList_DaysTmpDis     int,
    @inSickList_ResSm          numeric(10,2),
    @outId                     int output

AS                            
BEGIN
    SET NOCOUNT ON 

    insert into SickList (SickList_PersCard_Id, SickList_RefDep_Id, SickList_Date, SickList_DaysEntprs,
                          SickList_SmEntprs, SickList_DaysSocInsrnc, SickList_SmSocInsrnc, SickList_PayDate, SickList_DaysTmpDis, SickList_ResSm) 
	      values (@inSickList_PersCard_Id, @inSickList_RefDep_Id, @inSickList_Date, @inSickList_DaysEntprs, 
                  @inSickList_SmEntprs, @inSickList_DaysSocInsrnc, @inSickList_SmSocInsrnc, @inSickList_PayDate, @inSickList_DaysTmpDis, @inSickList_ResSm)

    select @outId=coalesce(IDENT_CURRENT ('SickList'),0);
END

