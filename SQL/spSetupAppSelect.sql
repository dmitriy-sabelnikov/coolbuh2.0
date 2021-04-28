/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы SetupApp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSetupAppSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSetupAppSelect];
GO
Create Procedure [dbo].[spSetupAppSelect]
	@inSetupApp_Type int = 0  --тип настройки  
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM SetupApp (NOLOCK)
     WHERE (SetupApp_Type = @inSetupApp_Type or @inSetupApp_Type = 0) 
END
