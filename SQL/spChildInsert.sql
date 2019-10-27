/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу Child*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spChildInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spChildInsert];
GO
Create Procedure [dbo].[spChildInsert] 
    @inChild_PersCard_Id  int               ,  --Ссылка на карточку работника
    @inChild_PerBeg       Date	            ,  --Период начало
    @inChild_PerEnd       Date              ,  --Период конец
    @inChild_Count        int	               --Количество
AS                            
BEGIN
    insert into Child (Child_PersCard_Id, Child_PerBeg, Child_PerEnd, Child_Count) 
	 values (@inChild_PersCard_Id, @inChild_PerBeg, @inChild_PerEnd, @inChild_Count);
END