--Расчет баланса
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spSalBalanceCalc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spSalBalanceCalc];
GO

Create Procedure [dbo].[spSalBalanceCalc]
	@inDatBeg            datetime,          --Период начала расчета  
	@inDatEnd            datetime           --Период конца расчета  
AS	 
DECLARE @id_card integer, 
        @date_salary datetime, 
        @balance_sm numeric(10,2),
        @prev_sm numeric(10,2), 
        @tmp_dat datetime;
            
BEGIN
  SET NOCOUNT ON 

  IF OBJECT_ID('tempdb..#Period') IS NOT NULL
  BEGIN
    DROP TABLE #Period
  END
  --Создаем временную таблицу периодов  
create table #Period
(
   [dat]        datetime NOT NULL  
) 
--Заполняем временную таблицу периодов

set @tmp_dat = @inDatBeg;
while @tmp_dat <= @inDatEnd
begin
  insert into #Period (dat) values (@tmp_dat);
  set @tmp_dat = dateadd(mm, 1, @tmp_dat);
end;
DECLARE cursor_Balance CURSOR FOR 

select tt.PersCard_Id,
       tt.dat,
       (tt.Salary_ResSm + tt.SickList_ResSm + tt.Vocation_Sm + tt.LawContract_Sm + tt.IncTax_Sm + tt.AddAccrNoClc_Sm + tt.AddAccrClc_Sm-
	     ((case when tt.status_type = 1 then 0 else tt.Tax_Sm end) + tt.prof_sm + tt.Payment_Sm + tt.military_sm + tt.AddPaym_Sm)) balance_sm
  from 
(
select t.PersCard_Id,
       t.dat,
	     t.Salary_ResSm,
	     t.SickList_ResSm,
	     t.Vocation_Sm,
	     t.LawContract_Sm,
	     t.AddAccrClc_Sm,
	     t.AddAccrNoClc_Sm,
	     t.Koef,
	     t.socben_sm,
	     t.socben_limSm, 
	     t.children,
	     t.IncTax_Sm,
	     t.status_type,
	     t.Payment_Sm,
       t.AddPaym_Sm,
	     dbo.fn_ClcTax(t.Salary_ResSm + t.SickList_ResSm + t.Vocation_Sm + t.LawContract_Sm + t.AddAccrClc_Sm,   
                     t.socben_sm, t.socben_limSm, t.Koef, t.children) Tax_Sm,
       dbo.fn_ClcProf(case when t.status_type in (1, 3) then (t.Salary_ResSm + t.SickList_ResSm + t.Vocation_Sm + t.LawContract_Sm + t.AddAccrClc_Sm)  
                           else 0 
                       end) prof_sm,	     
       dbo.fn_ClcMilitary(t.Salary_ResSm + t.SickList_ResSm + t.Vocation_Sm + t.LawContract_Sm + t.AddAccrClc_Sm, t.dat) military_sm  
  From
(
SELECT PersCard.PersCard_Id, 
       #Period.dat,
       SUM(coalesce(sal.Salary_ResSm, 0))Salary_ResSm,
       SUM(coalesce(sick.SickList_ResSm, 0))SickList_ResSm,
       SUM(coalesce(voc.Vocation_Sm, 0))Vocation_Sm,
       SUM(coalesce(law.LawContract_Sm, 0))LawContract_Sm,
       SUM(coalesce(accr_clc.AddAccr_Sm, 0))AddAccrClc_Sm,
       SUM(coalesce(accr_noclc.AddAccr_Sm, 0))AddAccrNoClc_Sm,
       SUM(coalesce(paym.Payment_Sm, 0)) Payment_Sm,
	     sum(coalesce(addPaym.AddPayment_Sm, 0)) AddPaym_Sm,
       coalesce((select Max(coalesce(TaxRelief_Koef,0)) TaxRelief_Koef
	                 from TaxRelief
	              	where TaxRelief_PersCard_Id = PersCard.PersCard_Id
		                and dateadd(d, -1, dateadd(mm, 1, #Period.dat))  between coalesce(TaxRelief_PerBeg, {d'1900-01-01'}) and coalesce(TaxRelief_PerEnd, {d'2500-01-01'}) 
		           ),0) Koef,
	     coalesce((select max(coalesce(RefSocBenefit_Sm,0))RefSocBenefit_Sm  
		               from RefSocBenefit
		              where dateadd(d, -1, dateadd(mm, 1, #Period.dat)) between coalesce(RefSocBenefit_PerBeg, {d'1900-01-01'}) and coalesce(RefSocBenefit_PerEnd, {d'2500-01-01'}) 
               ),0) socben_sm,
	     coalesce((select max(coalesce(RefSocBenefit_LimSM,0))RefSocBenefit_LimSM  
		              from RefSocBenefit
		             where dateadd(d, -1, dateadd(mm, 1, #Period.dat)) between coalesce(RefSocBenefit_PerBeg, {d'1900-01-01'}) and coalesce(RefSocBenefit_PerEnd, {d'2500-01-01'}) 
               ),0) socben_limSm,
	     coalesce((select SUM(coalesce(Child_Count,0)) Child_Count
	                from Child
		             where Child_PersCard_Id  = PersCard.PersCard_Id
		               and dateadd(d, -1, dateadd(mm, 1, #Period.dat)) between coalesce(Child_PerBeg, {d'1900-01-01'}) and coalesce(Child_PerEnd, {d'2500-01-01'}) 
		           ),0) children,
       coalesce((select Max(coalesce(CardStatus_Type,0)) CardStatus_Type
	                 from CardStatus
		              where CardStatus_PersCard_Id = PersCard.PersCard_Id
		                and dateadd(d, -1, dateadd(mm, 1, #Period.dat))  between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd, {d'2500-01-01'}) 
	            ),0) status_type,
		   SUM(coalesce(tax.IncTax_Sm,0)) IncTax_Sm
 FROM PersCard (NOLOCK)
 INNER JOIN #Period on 1 = 1
 LEFT JOIN (select Salary_PersCard_Id, Salary_KTU, Salary_Date, sum(Salary_BaseSm)Salary_BaseSm, sum(Salary_PensSm)Salary_PensSm, 
                   sum(Salary_ExpSm)Salary_ExpSm, sum(Salary_GradeSm)Salary_GradeSm, sum(Salary_OthSm)Salary_OthSm,
			             sum(Salary_KTUSm)Salary_KTUSm, sum(Salary_ResSm) Salary_ResSm  
             from Salary (NOLOCK)
   		       group by Salary_PersCard_Id, Salary_Date, Salary_KTU) sal 
       on sal.Salary_PersCard_Id = PersCard.PersCard_Id and sal.Salary_Date = #Period.dat
LEFT JOIN (select SickList_PersCard_Id, SickList_Date, sum(SickList_ResSm) SickList_ResSm
             from SickList (NOLOCK)
 		 group by SickList_PersCard_Id, SickList_Date) sick 
     on sick.SickList_PersCard_Id = PersCard.PersCard_Id and sick.SickList_Date = #Period.dat
 LEFT JOIN (select Vocation_PersCard_Id, Vocation_Date, sum(Vocation_Sm) Vocation_Sm
             from Vocation (NOLOCK)
 		 group by Vocation_PersCard_Id, Vocation_Date) voc 
     on voc.Vocation_PersCard_Id = PersCard.PersCard_Id and voc.Vocation_Date = #Period.dat
 LEFT JOIN (select LawContract_PersCard_Id, LawContract_Date, sum(LawContract_Sm) LawContract_Sm
             from LawContract (NOLOCK)
 		 group by LawContract_PersCard_Id, LawContract_Date) law 
     on law.LawContract_PersCard_Id = PersCard.PersCard_Id  and law.LawContract_Date = #Period.dat
 
 LEFT JOIN (select AddAccr_PersCard_Id, AddAccr_Date, SUM(AddAccr_Sm) AddAccr_Sm
              from AddAccr (NOLOCK)
 		   INNER JOIN RefTypeAddAccr (NOLOCK) on RefTypeAddAccr.RefTypeAddAccr_Id = AddAccr.AddAccr_RefTypeAddAccr_Id
		   where (RefTypeAddAccr.RefTypeAddAccr_Flg & 1) > 0
 		  group by AddAccr_PersCard_Id, AddAccr_Date ) accr_clc
     on accr_clc.AddAccr_PersCard_Id = PersCard.PersCard_Id and accr_clc.AddAccr_Date = #Period.dat

 LEFT JOIN (select AddAccr_PersCard_Id, AddAccr_Date, SUM(AddAccr_Sm) AddAccr_Sm
              from AddAccr (NOLOCK)
 		   INNER JOIN RefTypeAddAccr (NOLOCK) on RefTypeAddAccr.RefTypeAddAccr_Id = AddAccr.AddAccr_RefTypeAddAccr_Id
		   where (RefTypeAddAccr.RefTypeAddAccr_Flg & 1) = 0
 		  group by AddAccr_PersCard_Id, AddAccr_Date ) accr_noclc
     on accr_noclc.AddAccr_PersCard_Id = PersCard.PersCard_Id and accr_noclc.AddAccr_Date =#Period.dat
 LEFT JOIN (select IncTax_PersCard_Id, IncTax_Date, SUM(IncTax_Sm) IncTax_Sm 
              From IncTax (NOLOCK)
           group by IncTax_PersCard_Id, IncTax_Date ) tax
     on tax.IncTax_PersCard_Id = PersCard.PersCard_Id and tax.IncTax_Date = #Period.dat

LEFt JOIN (select Payment_PersCard_Id, Payment_Date, sum(Payment_Sm) Payment_Sm
            from Payment (NOLOCK)
           group by Payment_PersCard_Id, Payment_Date) paym
     on paym.Payment_PersCard_Id = PersCard.PersCard_Id and paym.Payment_Date between #Period.dat and dateadd(d, -1, dateadd(mm, 1, #Period.dat)) 
LEFt JOIN (select AddPayment_PersCard_Id, AddPayment_Date, sum(AddPayment_Sm) AddPayment_Sm
            from AddPayment (NOLOCK)
           group by AddPayment_PersCard_Id, AddPayment_Date) addPaym
     on addPaym.AddPayment_PersCard_Id = PersCard.PersCard_Id and addPaym.AddPayment_Date = #Period.dat 
GROUP BY PersCard.PersCard_Id, #Period.dat

) t
)tt
order by tt.PersCard_Id,  tt.dat

delete SalBalance where SalBalance.SalBalance_Date between @inDatBeg and @inDatEnd;

OPEN cursor_Balance;
 /*Выбираем первую строку*/
FETCH NEXT FROM cursor_Balance INTO @id_card, @date_salary, @balance_sm;
/*Выполняем в цикле перебор строк*/
WHILE @@FETCH_STATUS = 0
BEGIN
  set @prev_sm = (select SalBalance_EndMonthSm from SalBalance (NOLOCK) where SalBalance_PersCard_Id = @id_card and SalBalance_Date = dateadd(mm, -1, @date_salary));
  set @prev_sm = coalesce(@prev_sm, 0);
  print cast (@date_salary as varchar(16));
  print cast (@prev_sm as varchar(10));
  print cast (@id_card as varchar(10));
  
  insert into SalBalance (SalBalance_PersCard_Id, SalBalance_Date, SalBalance_BegMonthSm, SalBalance_EndMonthSm)
                  values (@id_card, @date_salary, @prev_sm, @prev_sm + @balance_sm);
FETCH NEXT FROM cursor_Balance INTO @id_card, @date_salary, @balance_sm;
END;


CLOSE cursor_Balance;

DEALLOCATE cursor_Balance;

drop table #Period;  
END;


