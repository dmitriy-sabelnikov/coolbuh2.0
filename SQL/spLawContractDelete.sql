/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы LawContract*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLawContractDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spLawContractDelete];
GO
Create Procedure [dbo].[spLawContractDelete]
	@inLawContract_Id   int           --id  
AS                            
BEGIN
	DELETE 
	  FROM LawContract
	 WHERE LawContract_Id = @inLawContract_Id;
END
