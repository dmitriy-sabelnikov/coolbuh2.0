/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы RefLivWage*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefLivWageDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefLivWageDelete];
GO
Create Procedure [dbo].[spRefLivWageDelete]
	@inRefLivWage_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM RefLivWage
	 WHERE RefLivWage_Id = @inRefLivWage_Id;
END
