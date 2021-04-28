/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы Child*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spChildUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spChildUpdate];
GO
Create Procedure [dbo].[spChildUpdate]
    @inChild_Id           int,   --id карточки
    @inChild_PersCard_Id  int,   --Ссылка на карточку работника
    @inChild_PerBeg       Date,  --Период начало
    @inChild_PerEnd       Date,  --Период конец
    @inChild_Count        int    --количество
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE Child SET
	  Child_PersCard_Id     = @inChild_PersCard_Id,
	  Child_PerBeg	        = @inChild_PerBeg, 
	  Child_PerEnd	        = @inChild_PerEnd,   
	  Child_Count	        = @inChild_Count   
    WHERE Child_Id = @inChild_Id;
END
