/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу AddAccr*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddAccrInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spAddAccrInsert];
GO
Create Procedure [dbo].[spAddAccrInsert] 
    @inAddAccr_PersCard_Id           int,
    @inAddAccr_RefDep_Id             int,
    @inAddAccr_RefTypeAddAccr_Id     int,
    @inAddAccr_Date                  date,
    @inAddAccr_Sm                    numeric(10,2),
    @outId                           int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into AddAccr (AddAccr_PersCard_Id, AddAccr_RefDep_Id, AddAccr_RefTypeAddAccr_Id, AddAccr_Date, AddAccr_Sm) 
	      values (@inAddAccr_PersCard_Id, @inAddAccr_RefDep_Id, @inAddAccr_RefTypeAddAccr_Id, @inAddAccr_Date, @inAddAccr_Sm);
    select @outId=coalesce(IDENT_CURRENT ('AddAccr'),0);
END