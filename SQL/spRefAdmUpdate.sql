/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefAdm*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefAdmUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefAdmUpdate];
GO
Create Procedure [dbo].[spRefAdmUpdate]
	@inRefAdm_Id        int,           --id   
	@inRefAdm_TIN	    nvarchar(10),
	@inRefAdm_FIO	    nvarchar(50),
	@inRefAdm_Tel       nvarchar(12),
	@inRefAdm_TypDol    int
AS                            
BEGIN
	UPDATE RefAdm SET
     	   RefAdm_TIN    = @inRefAdm_TIN,
     	   RefAdm_FIO    = @inRefAdm_FIO,
     	   RefAdm_Tel    = @inRefAdm_Tel, 
           RefAdm_TypDol = @inRefAdm_TypDol 
    WHERE RefAdm_Id = @inRefAdm_Id;
END
