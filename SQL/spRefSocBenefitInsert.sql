/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefSocBenefit*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefSocBenefitInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefSocBenefitInsert];
GO
Create Procedure [dbo].[spRefSocBenefitInsert] 
    @inRefSocBenefit_PerBeg           date,
    @inRefSocBenefit_PerEnd           date,
    @inRefSocBenefit_Sm               numeric(16,2),
	@inRefSocBenefit_LimSm            numeric(16,2),
    @outId                            int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into RefSocBenefit (RefSocBenefit_PerBeg, RefSocBenefit_PerEnd, RefSocBenefit_Sm, RefSocBenefit_LimSm) 
	      values (@inRefSocBenefit_PerBeg, @inRefSocBenefit_PerEnd, @inRefSocBenefit_Sm, @inRefSocBenefit_LimSm);
    select @outId=coalesce(IDENT_CURRENT ('RefSocBenefit'),0);
END
