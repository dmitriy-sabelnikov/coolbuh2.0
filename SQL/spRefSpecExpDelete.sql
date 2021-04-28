/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы RefExpAllwnc*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefSpecExpDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefSpecExpDelete];
GO
Create Procedure [dbo].[spRefSpecExpDelete]
	@inRefSpecExp_Id        int           --id 
AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM RefSpecExp
	 WHERE RefSpecExp_Id = @inRefSpecExp_Id;
END
