/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы Company*/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCompanySelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[spCompanySelect];
--GO
--Create Procedure [dbo].[spCompanySelect]
--AS                            
--BEGIN
--    SELECT *
--      FROM Company
--END
