/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefLivWage*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefLivWageUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefLivWageUpdate];
GO
Create Procedure [dbo].[spRefLivWageUpdate]
	@inRefLivWage_Id          int,           --id   
    @inRefLivWage_PerBeg      date,
    @inRefLivWage_PerEnd      date,
    @inRefLivWage_Sm          numeric(16,2)
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE RefLivWage SET
     	   RefLivWage_PerBeg  = @inRefLivWage_PerBeg,
     	   RefLivWage_PerEnd  = @inRefLivWage_PerEnd,
     	   RefLivWage_Sm      = @inRefLivWage_Sm
    WHERE RefLivWage_Id = @inRefLivWage_Id;
END
