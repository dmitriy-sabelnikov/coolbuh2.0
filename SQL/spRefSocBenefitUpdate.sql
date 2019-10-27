/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы RefSocBenefit*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefSocBenefitUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefSocBenefitUpdate];
GO
Create Procedure [dbo].[spRefSocBenefitUpdate]
	@inRefSocBenefit_Id          int,           --id   
    @inRefSocBenefit_PerBeg      date,
    @inRefSocBenefit_PerEnd      date,
    @inRefSocBenefit_Sm          numeric(16,2),
    @inRefSocBenefit_LimSm       numeric(16,2)
AS                            
BEGIN
	UPDATE RefSocBenefit SET
     	   RefSocBenefit_PerBeg  = @inRefSocBenefit_PerBeg,
     	   RefSocBenefit_PerEnd  = @inRefSocBenefit_PerEnd,
     	   RefSocBenefit_Sm      = @inRefSocBenefit_Sm,
		   RefSocBenefit_LimSm   = @inRefSocBenefit_LimSm
    WHERE RefSocBenefit_Id = @inRefSocBenefit_Id;
END
