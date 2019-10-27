/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы Company*/
--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCompanyUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
--	drop procedure [dbo].[spCompanyUpdate];
--GO
--Create Procedure [dbo].[spCompanyUpdate]
--    @inCompany_USREOU           varchar(10),
--    @inCompany_Nm               varchar(100)
--AS                            
--BEGIN
--	UPDATE Company SET
--    Company_USREOU  = @inCompany_USREOU,
--    Company_Nm      = @inCompany_Nm
--END
