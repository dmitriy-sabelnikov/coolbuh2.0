/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу Company*/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCompanyInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[spCompanyInsert];
--GO
--Create Procedure [dbo].[spCompanyInsert] 
--    @inCompany_USREOU           varchar(10),
--    @inCompany_Nm               varchar(100)
--AS                            
--BEGIN
--    insert into Company (Company_USREOU, Company_Nm) 
--	      values (@inCompany_USREOU, @inCompany_Nm);
--END