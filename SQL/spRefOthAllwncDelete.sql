/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы RefOth*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefOthAllwncDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefOthAllwncDelete];
GO
Create Procedure [dbo].[spRefOthAllwncDelete]
	@inRefOthAllwnc_Id   int           --id  
AS                            
BEGIN
	DELETE 
	  FROM RefOthAllwnc
	 WHERE RefOthAllwnc_Id = @inRefOthAllwnc_Id;
END
