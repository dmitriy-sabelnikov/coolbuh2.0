/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу CardStatus*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCardStatusInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spCardStatusInsert];
GO
Create Procedure [dbo].[spCardStatusInsert] 
    @inCardStatus_PersCard_Id  int              ,  --Ссылка на карточку работника
    @inCardStatus_PerBeg       Date	            ,  --Период начало
    @inCardStatus_PerEnd       Date             ,  --Период конец
    @inCardStatus_Type        int	               --Тип статуса
AS                            
BEGIN
    insert into CardStatus (CardStatus_PersCard_Id, CardStatus_PerBeg, CardStatus_PerEnd, CardStatus_Type) 
	 values (@inCardStatus_PersCard_Id, @inCardStatus_PerBeg, @inCardStatus_PerEnd, @inCardStatus_Type);
END