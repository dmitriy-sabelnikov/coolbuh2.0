/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы DFRec*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDFRecSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spDFRecSelect];
GO
Create Procedure [dbo].[spDFRecSelect]
	@inDFRec_Id          int = 0,          --id   
	@inDFRec_DFCt_Id    int = 0           --id каталога
AS                            
BEGIN
    SELECT *
      FROM DFRec
     WHERE (DFRec_Id = @inDFRec_Id or @inDFRec_Id = 0)
       and (DFRec_DFCt_Id = @inDFRec_DFCt_Id or @inDFRec_DFCt_Id = 0)
END
