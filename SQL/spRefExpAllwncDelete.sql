/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы RefExpAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefExpAllwncDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefExpAllwncDelete];
GO
Create Procedure [dbo].[spRefExpAllwncDelete]
	@inRefExpAllwnc_Id   int           --id  
AS                            
BEGIN
	DELETE 
	  FROM RefExpAllwnc
	 WHERE RefExpAllwnc_Id = @inRefExpAllwnc_Id;
END
