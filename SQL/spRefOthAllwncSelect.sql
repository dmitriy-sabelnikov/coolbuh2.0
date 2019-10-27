/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefOth*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefOthAllwncSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefOthAllwncSelect];
GO
Create Procedure [dbo].[spRefOthAllwncSelect]
	@inRefOthAllwnc_Id   int = 0       --id   
AS                            
BEGIN
    SELECT *
      FROM RefOthAllwnc
     WHERE (RefOthAllwnc_Id = @inRefOthAllwnc_Id or @inRefOthAllwnc_Id = 0) 
END
