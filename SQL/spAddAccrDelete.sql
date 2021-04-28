/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы AddAccr*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddAccrDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spAddAccrDelete];
GO
Create Procedure [dbo].[spAddAccrDelete]
	@inAddAccr_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM AddAccr
	 WHERE AddAccr_Id = @inAddAccr_Id;
END
