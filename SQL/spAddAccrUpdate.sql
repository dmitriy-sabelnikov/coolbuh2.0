/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы AddAccr*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spAddAccrUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spAddAccrUpdate];
GO
Create Procedure [dbo].[spAddAccrUpdate]
	@inAddAccr_Id                    int,
    @inAddAccr_PersCard_Id           int,
    @inAddAccr_RefDep_Id             int,
    @inAddAccr_RefTypeAddAccr_Id     int,
    @inAddAccr_Date                  date,
    @inAddAccr_Sm                    numeric(10,2)
AS                            
BEGIN
	UPDATE AddAccr SET
    AddAccr_PersCard_Id           = @inAddAccr_PersCard_Id,
    AddAccr_RefDep_Id             = @inAddAccr_RefDep_Id,
    AddAccr_RefTypeAddAccr_Id     = @inAddAccr_RefTypeAddAccr_Id,
    AddAccr_Date                  = @inAddAccr_Date,
	AddAccr_Sm                    = @inAddAccr_Sm                
    WHERE AddAccr_Id = @inAddAccr_Id;
END
