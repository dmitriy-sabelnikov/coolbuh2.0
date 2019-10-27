/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы RefTypeAddAccr*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefTypeAddAccrDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefTypeAddAccrDelete];
GO
Create Procedure [dbo].[spRefTypeAddAccrDelete]
	@inRefTypeAddAccr_Id   int           --id  
AS                            
BEGIN
	DELETE 
	  FROM RefTypeAddAccr
	 WHERE RefTypeAddAccr_Id = @inRefTypeAddAccr_Id;
END
