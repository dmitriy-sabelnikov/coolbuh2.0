/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefTypeAddAccr*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefTypeAddAccrInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefTypeAddAccrInsert];
GO
Create Procedure [dbo].[spRefTypeAddAccrInsert] 
    @inRefTypeAddAccr_Cd      varchar(25),
    @inRefTypeAddAccr_Nm      varchar(50),
    @inRefTypeAddAccr_Flg     int,
    @outId                    int output
AS                            
BEGIN
  SET NOCOUNT ON 

    insert into RefTypeAddAccr (RefTypeAddAccr_Cd, RefTypeAddAccr_Nm, RefTypeAddAccr_Flg) 
	      values (@inRefTypeAddAccr_Cd, @inRefTypeAddAccr_Nm, @inRefTypeAddAccr_Flg);
    select @outId=coalesce(IDENT_CURRENT ('RefTypeAddAccr'),0);
END



