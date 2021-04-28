/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы DfCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDfCtDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spDfCtDelete];
GO
Create Procedure [dbo].[spDfCtDelete]
	@inDfCt_Id   int           --id  
AS                            
BEGIN
    SET NOCOUNT ON 

  BEGIN TRANSACTION
	DELETE 
	  FROM DFRec
	 WHERE DFRec_DFCt_Id = @inDfCt_Id;

	DELETE 
	  FROM DfCt
	 WHERE DfCt_Id = @inDfCt_Id;
  IF(@@error <> 0)
    ROLLBACK TRANSACTION
  ELSE 
    COMMIT TRANSACTION;
END
