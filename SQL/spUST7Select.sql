/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы UST7*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUST7Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUST7Select];
GO
Create Procedure [dbo].[spUST7Select]
	@inUST7_Id          int = 0,          --id   
	@inUST7_USTCt_Id    int = 0           --id каталога
AS                            
BEGIN
    SELECT *
      FROM UST7
     WHERE (UST7_Id = @inUST7_Id or @inUST7_Id = 0)
       and (UST7_USTCt_Id = @inUST7_USTCt_Id or @inUST7_USTCt_Id = 0)
END
