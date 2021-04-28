/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы CardSpecExp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCardSpecExpSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spCardSpecExpSelect];
GO
Create Procedure [dbo].[spCardSpecExpSelect]
	@inCardSpecExp_Id            int = 0,     --id   
	@inCardSpecExp_PersCard_Id   int = 0      --id карточки

AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM CardSpecExp (NOLOCK)
     WHERE (CardSpecExp_Id = @inCardSpecExp_Id or @inCardSpecExp_Id = 0) 
       and (CardSpecExp_PersCard_Id = @inCardSpecExp_PersCard_Id or @inCardSpecExp_PersCard_Id = 0)
END