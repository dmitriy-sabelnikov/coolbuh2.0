/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefLivWage*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefLivWageSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefLivWageSelect];
GO
Create Procedure [dbo].[spRefLivWageSelect]
	@inRefLivWage_Id   int = 0       --id   
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM RefLivWage (NOLOCK)
     WHERE (RefLivWage_Id = @inRefLivWage_Id or @inRefLivWage_Id = 0) 
END
