--Расчет налога
if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'[dbo].[fn_ClcTax]') AND OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
  drop function [dbo].[fn_ClcTax];
GO
Create function [dbo].[fn_ClcTax] 
(
	@inGrossInc          numeric(10,2),     --Валовый доход  
	@inSocBenefit_Sm     numeric(10,2),     --Социальная льгота 
	@inSocBenefit_LimSm  numeric(10,2),     --Ограничение соц льготы
	@inTaxRelief_Koef    numeric(10,2),     --Коэффициент льготы работника
    @inChildren          int                --Дети
)
RETURNS numeric(10,2)
AS   
BEGIN
  Declare @TaxSm numeric(10,2) = 0;
  Declare @TmpSm numeric(10,2) = @inGrossInc;
  Declare @TaxPrc numeric(10,2) = 0.18;

  set @inGrossInc         = coalesce(@inGrossInc, 0);
  set @inSocBenefit_Sm    = coalesce(@inSocBenefit_Sm, 0);
  set @inSocBenefit_LimSm = coalesce(@inSocBenefit_LimSm, 0);
  set @inTaxRelief_Koef   = coalesce(@inTaxRelief_Koef, 0);
  set @inChildren         = coalesce(@inChildren, 0);
  
  IF ((@inChildren >= 1 AND @inChildren <= 30 AND @inGrossInc <= @inSocBenefit_LimSm * @inChildren) OR
      (@inChildren > 30 AND @inGrossInc <= @inSocBenefit_LimSm * (@inChildren -30)) OR
	  (@inChildren  = 0 AND @inGrossInc <= @inSocBenefit_LimSm)
	 )
    BEGIN 
       set @TmpSm = @inGrossInc - @inSocBenefit_Sm * @inTaxRelief_Koef; 
    END
  
  IF (@TmpSm > 0)
    SET @TaxSm = ROUND(@TmpSm * @TaxPrc,2);

  RETURN @TaxSm;
END;   

