/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы DFRec*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDFRecDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spDFRecDelete];
GO
Create Procedure [dbo].[spDFRecDelete]
	@inDFRec_Id            int = 0,     --id 
	@inDFRec_DFCt_Id      int = 0      --id каталога

AS                            
BEGIN
    SET NOCOUNT ON 

	DELETE 
	  FROM DFRec
	 WHERE (DFRec_Id = @inDFRec_Id or @inDFRec_Id = 0)
           and (DFRec_DFCt_Id = @inDFRec_DFCt_Id or @inDFRec_DFCt_Id = 0);
END
