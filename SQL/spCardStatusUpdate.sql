/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы CardStatus*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCardStatusUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spCardStatusUpdate];
GO
Create Procedure [dbo].[spCardStatusUpdate]
    @inCardStatus_Id           int,   --id карточки
    @inCardStatus_PersCard_Id  int,   --Ссылка на карточку работника
    @inCardStatus_PerBeg       Date,  --Период начало
    @inCardStatus_PerEnd       Date,  --Период конец
    @inCardStatus_Type         int    --Тип статуса
AS                            
BEGIN
	UPDATE CardStatus SET
	  CardStatus_PersCard_Id     = @inCardStatus_PersCard_Id,
	  CardStatus_PerBeg	        = @inCardStatus_PerBeg, 
	  CardStatus_PerEnd	        = @inCardStatus_PerEnd,   
	  CardStatus_Type	        = @inCardStatus_Type   
    WHERE CardStatus_Id = @inCardStatus_Id;
END
