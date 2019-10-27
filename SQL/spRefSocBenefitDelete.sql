/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы RefSocBenefit*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefSocBenefitDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spRefSocBenefitDelete];
GO
Create Procedure [dbo].[spRefSocBenefitDelete]
	@inRefSocBenefit_Id   int           --id  
AS                            
BEGIN
	DELETE 
	  FROM RefSocBenefit
	 WHERE RefSocBenefit_Id = @inRefSocBenefit_Id;
END
