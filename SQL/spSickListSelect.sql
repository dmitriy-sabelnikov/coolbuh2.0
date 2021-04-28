/****** Script Date: 19.03.2018 9:00:22 ******/
/*¬ыборка из таблицы SickList*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSickListSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSickListSelect];
GO
Create Procedure [dbo].[spSickListSelect]
	@inSickList_Id          int = 0,      --id   
	@inSickList_RefDep_Id   int = 0,      --id подразделени€
        @inSickList_DateBeg     date = null,  --дата
        @inSickList_DateEnd     date = null   --дата
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM SickList (NOLOCK)
     WHERE (SickList_Id = @inSickList_Id or @inSickList_Id = 0)
       and (SickList_RefDep_Id = @inSickList_RefDep_Id or @inSickList_RefDep_Id = 0)
       and (SickList_Date between @inSickList_DateBeg and @inSickList_DateEnd 
            or coalesce(@inSickList_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inSickList_DateEnd, '1900-01-01') = '1900-01-01') 
END
