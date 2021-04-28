/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы UST6*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUST6Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUST6Delete];
GO
Create Procedure [dbo].[spUST6Delete]
	@inUST6_Id            int = 0,     --id 
	@inUST6_USTCt_Id      int = 0      --id каталога

AS                            
BEGIN
        DELETE 
	  FROM UST6
	 WHERE (UST6_Id = @inUST6_Id or @inUST6_Id = 0)
           and (UST6_USTCt_Id = @inUST6_USTCt_Id or @inUST6_USTCt_Id = 0);
END
