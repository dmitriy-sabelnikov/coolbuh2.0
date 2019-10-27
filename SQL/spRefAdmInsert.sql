/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefAdm*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefAdmInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefAdmInsert];
GO
Create Procedure [dbo].[spRefAdmInsert] 
	@inRefAdm_TIN	    nvarchar(10),
	@inRefAdm_FIO	    nvarchar(50),
	@inRefAdm_Tel       nvarchar(12),
        @inRefAdm_TypDol    int,
        @outId              int output
AS                            
BEGIN
    insert into RefAdm (RefAdm_TIN, RefAdm_FIO, RefAdm_Tel, RefAdm_TypDol) 
	      values (@inRefAdm_TIN, @inRefAdm_FIO, @inRefAdm_Tel, @inRefAdm_TypDol);
    select @outId=coalesce(IDENT_CURRENT ('RefAdm'),0);
END
