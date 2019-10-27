/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы Child*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spChildSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spChildSelect];
GO
Create Procedure [dbo].[spChildSelect]
	@inChild_Id            int = 0,     --id   
	@inChild_PersCard_Id   int = 0      --id карточки

AS                            
BEGIN
    SELECT *
      FROM Child
     WHERE (Child_Id = @inChild_Id or @inChild_Id = 0) 
       and (Child_PersCard_Id = @inChild_PersCard_Id or @inChild_PersCard_Id = 0)
END