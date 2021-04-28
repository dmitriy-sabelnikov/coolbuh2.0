/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу CardSpecExp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCardSpecExpInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spCardSpecExpInsert];
GO
Create Procedure [dbo].[spCardSpecExpInsert] 
    @inCardSpecExp_PersCard_Id     int               ,  --Ссылка на карточку работника
    @inCardSpecExp_PerBeg          Date	             ,  --Период начало
    @inCardSpecExp_PerEnd          Date              ,  --Период конец
    @inCardSpecExp_RefSpecExp_Id   int	               -- Ссылка на справочник спецстажей
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into CardSpecExp (CardSpecExp_PersCard_Id, CardSpecExp_PerBeg, CardSpecExp_PerEnd, CardSpecExp_RefSpecExp_Id) 
	 values (@inCardSpecExp_PersCard_Id, @inCardSpecExp_PerBeg, @inCardSpecExp_PerEnd, @inCardSpecExp_RefSpecExp_Id);
END