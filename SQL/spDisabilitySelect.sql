/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы Disability*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDisabilitySelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spDisabilitySelect];
GO
Create Procedure [dbo].[spDisabilitySelect]
	@inDisability_Id            int = 0,     --id   
	@inDisability_PersCard_Id   int = 0      --id карточки

AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM Disability (NOLOCK)
     WHERE (Disability_Id = @inDisability_Id or @inDisability_Id = 0) 
       and (Disability_PersCard_Id = @inDisability_PersCard_Id or @inDisability_PersCard_Id = 0)
END