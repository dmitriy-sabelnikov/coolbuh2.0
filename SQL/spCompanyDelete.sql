/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы Company*/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCompanyDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--  drop procedure [dbo].[spCompanyDelete];
--GO
--Create Procedure [dbo].[spCompanyDelete]
--AS                            
--BEGIN
--	DELETE 
--	  FROM Company
--END
