/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы Vocation*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVocationDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spVocationDelete];
GO
Create Procedure [dbo].[spVocationDelete]
	@inVocation_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON

	DELETE 
	  FROM Vocation
	 WHERE Vocation_Id = @inVocation_Id;
END
