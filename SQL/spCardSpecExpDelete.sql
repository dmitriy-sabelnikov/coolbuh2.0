/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы CardSpecExp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCardSpecExpDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spCardSpecExpDelete];
GO
Create Procedure [dbo].[spCardSpecExpDelete]
	@inCardSpecExp_Id            int = 0,     --id ребенка  
	@inCardSpecExp_PersCard_Id   int = 0      --id карточки

AS                            
BEGIN
	DELETE 
	  FROM CardSpecExp
	 WHERE (CardSpecExp_Id = @inCardSpecExp_Id or @inCardSpecExp_Id = 0)
           and (CardSpecExp_PersCard_Id = @inCardSpecExp_PersCard_Id or @inCardSpecExp_PersCard_Id = 0);

END
