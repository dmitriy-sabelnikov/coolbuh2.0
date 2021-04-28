/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы SetupApp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSetupAppDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spSetupAppDelete];
GO
Create Procedure [dbo].[spSetupAppDelete]
	@inSetupApp_Type   int  
AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM SetupApp
	 WHERE SetupApp_Type = @inSetupApp_Type;
END
