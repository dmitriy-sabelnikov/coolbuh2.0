/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы UST7*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUST7Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUST7Delete];
GO
Create Procedure [dbo].[spUST7Delete]
	@inUST7_Id            int = 0,     --id 
	@inUST7_USTCt_Id      int = 0      --id каталога

AS                            
BEGIN
	DELETE 
	  FROM UST7
	 WHERE (UST7_Id = @inUST7_Id or @inUST7_Id = 0)
           and (UST7_USTCt_Id = @inUST7_USTCt_Id or @inUST7_USTCt_Id = 0);
END
