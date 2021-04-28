/****** Script Date: 19.03.2018 9:00:22 ******/
/*Выборка из таблицы RefSocBenefit*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefSocBenefitSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefSocBenefitSelect];
GO
Create Procedure [dbo].[spRefSocBenefitSelect]
	@inRefSocBenefit_Id   int = 0       --id   
AS                            
BEGIN
    SET NOCOUNT ON 

    SELECT *
      FROM RefSocBenefit (NOLOCK)
     WHERE (RefSocBenefit_Id = @inRefSocBenefit_Id or @inRefSocBenefit_Id = 0) 
END
