/****** Script Date: 19.03.2018 9:00:22 ******/
/*¬ыборка из таблицы Vocation*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVocationSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spVocationSelect];
GO
Create Procedure [dbo].[spVocationSelect]
	@inVocation_Id          int = 0,          --id   
	@inVocation_RefDep_Id   int = 0,          --id подразделени€
        @inVocation_DateBeg     date = null,      --дата
        @inVocation_DateEnd     date = null       --дата
AS                            
BEGIN
    SET NOCOUNT ON

    SELECT *
      FROM Vocation (NOLOCK)
     WHERE (Vocation_Id = @inVocation_Id or @inVocation_Id = 0)
       and (Vocation_RefDep_Id = @inVocation_RefDep_Id or @inVocation_RefDep_Id = 0)
       and (Vocation_Date between @inVocation_DateBeg and @inVocation_DateEnd 
            or coalesce(@inVocation_DateBeg, '1900-01-01') = '1900-01-01'
            or coalesce(@inVocation_DateEnd, '1900-01-01') = '1900-01-01') 
END
