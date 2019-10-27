/****** Script Date: 19.03.2018 9:00:22 ******/
/*¬ыборка из таблицы AddAccr*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddAccrSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spAddAccrSelect];
GO
Create Procedure [dbo].[spAddAccrSelect]
	@inAddAccr_Id          int = 0,          --id   
	@inAddAccr_RefDep_Id   int = 0,          --id подразделени€
        @inAddAccr_DateBeg     date = null,      --дата
        @inAddAccr_DateEnd     date = null       --дата

AS                            
BEGIN
    SELECT *
      FROM AddAccr
     WHERE (AddAccr_Id = @inAddAccr_Id or @inAddAccr_Id = 0)
       and (AddAccr_RefDep_Id = @inAddAccr_RefDep_Id or @inAddAccr_RefDep_Id = 0)
       and (AddAccr_Date between @inAddAccr_DateBeg and @inAddAccr_DateEnd 
            or coalesce(@inAddAccr_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inAddAccr_DateEnd, '1900-01-01') = '1900-01-01') 
END
