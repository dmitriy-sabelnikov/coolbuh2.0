/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefExpAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefExpAllwncSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefExpAllwncSelect];
GO
Create Procedure [dbo].[spRefExpAllwncSelect]
	@inRefExpAllwnc_Id int = 0  --id   
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM RefExpAllwnc (NOLOCK)
     WHERE (RefExpAllwnc_Id = @inRefExpAllwnc_Id or @inRefExpAllwnc_Id = 0) 
END
