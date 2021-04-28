/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы CardStatus*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCardStatusDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spCardStatusDelete];
GO
Create Procedure [dbo].[spCardStatusDelete]
	@inCardStatus_Id            int = 0,     --id ребенка  
	@inCardStatus_PersCard_Id   int = 0      --id карточки

AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM CardStatus
	 WHERE (CardStatus_Id = @inCardStatus_Id or @inCardStatus_Id = 0)
           and (CardStatus_PersCard_Id = @inCardStatus_PersCard_Id or @inCardStatus_PersCard_Id = 0);

END
