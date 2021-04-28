/****** Script Date: 27.04.2021 9:00:22 ******/
/*Удаление строки из таблицы UnionReportCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportCtDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportCtDelete];
GO
Create Procedure [dbo].[spUnionReportCtDelete]
	@inUnionReportCt_Id   int           --id  
AS                            
BEGIN
  SET NOCOUNT ON 

  BEGIN TRANSACTION
	DELETE 
	  FROM UnionReportT1
	 WHERE UnionReportT1_CtId = @inUnionReportCt_Id;
	DELETE 
	  FROM UnionReportT2
	 WHERE UnionReportT2_CtId = @inUnionReportCt_Id;
	DELETE 
	  FROM UnionReportT4
	 WHERE UnionReportT4_CtId = @inUnionReportCt_Id;
	DELETE 
	  FROM UnionReportT5
	 WHERE UnionReportT5_CtId = @inUnionReportCt_Id;

	DELETE 
	  FROM UnionReportCt
	 WHERE UnionReportCt_Id = @inUnionReportCt_Id;
  IF(@@error <> 0)
    ROLLBACK TRANSACTION
  ELSE 
    COMMIT TRANSACTION;
END
