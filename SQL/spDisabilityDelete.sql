/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы Disability*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDisabilityDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spDisabilityDelete];
GO
Create Procedure [dbo].[spDisabilityDelete]
	@inDisability_Id            int = 0,     --id ребенка  
	@inDisability_PersCard_Id   int = 0      --id карточки

AS                            
BEGIN
	DELETE 
	  FROM Disability
	 WHERE (Disability_Id = @inDisability_Id or @inDisability_Id = 0)
           and (Disability_PersCard_Id = @inDisability_PersCard_Id or @inDisability_PersCard_Id = 0);

END
