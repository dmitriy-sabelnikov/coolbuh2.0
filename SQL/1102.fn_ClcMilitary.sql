--Расчет военого сбора
if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'[dbo].[fn_ClcMilitary]') AND OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
  drop function [dbo].[fn_ClcMilitary];
GO
Create function [dbo].[fn_ClcMilitary] 
(
	@inGrossInc          numeric(10,2)     --Валовый доход  
)
RETURNS numeric(10,2)
AS   
BEGIN
  Declare @MilitaryPrc numeric(10,4) = 0.015;

  set @inGrossInc = coalesce(@inGrossInc, 0);

  RETURN  ROUND(@inGrossInc * @MilitaryPrc,2);;
END;   

