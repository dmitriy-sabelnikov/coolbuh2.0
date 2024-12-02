--Расчет военого сбора
if exists (select * from dbo.sysobjects where id = OBJECT_ID(N'[dbo].[fn_ClcMilitary]') AND OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
  drop function [dbo].[fn_ClcMilitary];
GO
Create function [dbo].[fn_ClcMilitary] 
(
	@inGrossInc          numeric(10,2),    --Валовый доход 
    @inCalcDate          DATE              --Дата расчета налога  
)
RETURNS numeric(10,2)
AS   
BEGIN
  
  DECLARE @MilitaryPrc numeric(10,4);
  SET @MilitaryPrc = CASE WHEN @inCalcDate >= '2024-12-01' THEN 0.05
                          ELSE 0.015
                      END

  set @inGrossInc = coalesce(@inGrossInc, 0);

  RETURN  ROUND(@inGrossInc * @MilitaryPrc,2);;
END;   

