/****** Script Date: 19.03.2018 9:00:22 ******/
/*¬ыборка из таблицы LawContract*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLawContractSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spLawContractSelect];
GO
Create Procedure [dbo].[spLawContractSelect]
	@inLawContract_Id          int = 0,          --id   
	@inLawContract_RefDep_Id   int = 0,          --id подразделени€
        @inLawContract_DateBeg     date = null,      --дата
        @inLawContract_DateEnd     date = null       --дата
AS                            
BEGIN
    SELECT *
      FROM LawContract
     WHERE (LawContract_Id = @inLawContract_Id or @inLawContract_Id = 0)
       and (LawContract_RefDep_Id = @inLawContract_RefDep_Id or @inLawContract_RefDep_Id = 0)
       and (LawContract_Date between @inLawContract_DateBeg and @inLawContract_DateEnd 
            or coalesce(@inLawContract_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inLawContract_DateEnd, '1900-01-01') = '1900-01-01') 
END
