/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы USTCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUSTCtSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUSTCtSelect];
GO
Create Procedure [dbo].[spUSTCtSelect]
	@inUSTCt_Id          int = 0,          --id   
	@inDatePerN          date = null,
	@inDatePerK          date = null

AS                            
BEGIN
    SELECT *
      FROM USTCt
     WHERE (USTCt_Id = @inUSTCt_Id or @inUSTCt_Id = 0)
       and (USTCt_Date between @inDatePerN and @inDatePerK 
        or coalesce(@inDatePerN, '1900-01-01') = '1900-01-01'
        or coalesce(@inDatePerK, '1900-01-01') = '1900-01-01') 
END
