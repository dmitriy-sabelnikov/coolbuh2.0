/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы RefPensAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefPensAllwncDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefPensAllwncDelete];
GO
Create Procedure [dbo].[spRefPensAllwncDelete]
	@inRefPensAllwnc_Id   int           --id  
AS                            
BEGIN
	DELETE 
	  FROM RefPensAllwnc
	 WHERE RefPensAllwnc_Id = @inRefPensAllwnc_Id;
END
