/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы PersCard*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPersCardSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spPersCardSelect];
GO
Create Procedure [dbo].[spPersCardSelect]
	@inPersCard_Id   int = 0       --id карточки  
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM PersCard (NOLOCK)
     WHERE (PersCard_Id = @inPersCard_Id or @inPersCard_Id = 0) 
END
