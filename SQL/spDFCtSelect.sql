/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы DfCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDfCtSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spDfCtSelect];
GO
Create Procedure [dbo].[spDfCtSelect]
	@inDfCt_Id          int = 0,          --id   
	@inDatePerN          date = null,
	@inDatePerK          date = null

AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM DfCt (NOLOCK)
     WHERE (DfCt_Id = @inDfCt_Id or @inDfCt_Id = 0)
       and (DfCt_Date between @inDatePerN and @inDatePerK 
        or coalesce(@inDatePerN, '1900-01-01') = '1900-01-01'
        or coalesce(@inDatePerK, '1900-01-01') = '1900-01-01') 
END
