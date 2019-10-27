--Расчет проф взнососв
if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'[dbo].[fn_ClcProf]') AND OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
  drop function [dbo].[fn_ClcProf];
GO
Create function [dbo].[fn_ClcProf] 
(
	@inGrossInc          numeric(10,2)     --Валовый доход  
)
RETURNS numeric(10,2)
AS   
BEGIN
  Declare @ProfPrc numeric(10,2) = 0.01;

  set @inGrossInc = coalesce(@inGrossInc, 0);

  RETURN  ROUND(@inGrossInc * @ProfPrc,2);;
END;   

