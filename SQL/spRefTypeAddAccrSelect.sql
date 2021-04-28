/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefTypeAddAccr*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefTypeAddAccrSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefTypeAddAccrSelect];
GO
Create Procedure [dbo].[spRefTypeAddAccrSelect]
	@inRefTypeAddAccr_Id          int = 0          --id   
AS                            
BEGIN
  SET NOCOUNT ON 

    SELECT *
      FROM RefTypeAddAccr (NOLOCK)
     WHERE (RefTypeAddAccr_Id = @inRefTypeAddAccr_Id or @inRefTypeAddAccr_Id = 0);
END
