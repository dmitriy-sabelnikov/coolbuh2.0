/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefTypeAddAccr*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefTypeAddAccrUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefTypeAddAccrUpdate];
GO
Create Procedure [dbo].[spRefTypeAddAccrUpdate]
    @inRefTypeAddAccr_Id             int,
    @inRefTypeAddAccr_Cd             varchar(25),
    @inRefTypeAddAccr_Nm             varchar(50),
    @inRefTypeAddAccr_Flg            int
AS                            
BEGIN
  SET NOCOUNT ON 

	UPDATE RefTypeAddAccr SET
           RefTypeAddAccr_Cd  = @inRefTypeAddAccr_Cd,
           RefTypeAddAccr_Nm  = @inRefTypeAddAccr_Nm,
           RefTypeAddAccr_Flg = @inRefTypeAddAccr_Flg
    WHERE RefTypeAddAccr_Id = @inRefTypeAddAccr_Id;
END

