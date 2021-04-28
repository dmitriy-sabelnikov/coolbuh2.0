/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы USTCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUSTCtDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUSTCtDelete];
GO
Create Procedure [dbo].[spUSTCtDelete]
	@inUSTCt_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON

    BEGIN TRANSACTION
	DELETE 
	  FROM UST6
	 WHERE UST6_USTCt_Id = @inUSTCt_Id;

	DELETE 
	  FROM UST7
	 WHERE UST7_USTCt_Id = @inUSTCt_Id;

	DELETE 
	  FROM USTCt
	 WHERE USTCt_Id = @inUSTCt_Id;
  IF(@@error <> 0)
    ROLLBACK TRANSACTION
  ELSE 
    COMMIT TRANSACTION;

END
