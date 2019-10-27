/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы SetupApp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSetupAppUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spSetupAppUpdate];
GO
Create Procedure [dbo].[spSetupAppUpdate]
	@inSetupApp_Type        int,  --тип настройки  
	@inSetupApp_ValueDigit  int,  --числовое значение 
	@inSetupApp_ValueString nvarchar(250) --символьное значение 
AS                            
BEGIN
	UPDATE SetupApp SET
		SetupApp_ValueDigit  = @inSetupApp_ValueDigit,
		SetupApp_ValueString = @inSetupApp_ValueString
    WHERE SetupApp_Type = @inSetupApp_Type;
END
