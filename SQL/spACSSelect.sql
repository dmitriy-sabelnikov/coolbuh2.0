--Аналитическая расчетная ведомость
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spACSSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spACSSelect];
GO

Create Procedure [dbo].[spACSSelect]
	@inDate_Clc  datetime
AS	             
BEGIN

select t.PersCard_Id,
       t.PersCard_LName,
       t.CardStatus_Type, 
	     t.PersCard_FName,
       t.PersCard_MName,
	     t.PersCard_TIN,
	     t.PersCard_DOB,
	     t.PersCard_DOR,
	     t.PersCard_DOD,
	     t.PersCard_DOP,
	     t.PersCard_Grade,
	     t.PersCard_Exp,
	     t.PersCard_SEX,
	     t.CardStatus_Type,
             t.Disability_Attr,
	     t.Child_Count,
	     t.Salary_Hours,
	     t.Salary_Days,
	     t.Salary_BaseSm,
	     t.Salary_PensSm,
	     t.Salary_GradeSm,
	     t.Salary_ExpSm,
	     t.Salary_OthSm,
	     t.Salary_KTU,
	     t.Salary_KTUSm,
	     t.Salary_ResSm,
       t.SickList_DaysEntprs,
       t.SickList_SmEntprs,
       t.SickList_DaysSocInsrnc,
       t.SickList_SmSocInsrnc,
	     t.SickList_DaysTmpDis,
	     t.SickList_ResSm,
	     t.Vocation_Days, 
	     t.Vocation_Sm,
	     t.LawContract_Days,
	     t.LawContract_Sm,
	     t.AddAccr_SmClc,
	     t.AddAccr_SmNoClc,
	     dbo.fn_ClcTax(t.Salary_ResSm + t.SickList_ResSm + t.Vocation_Sm + t.LawContract_Sm + t.AddAccr_SmClc, 
	                   t.RefSocBenefit_SM, t.RefSocBenefit_LimSm, t.TaxRelief_Koef, t.Child_Count) Tax_Sm,
       dbo.fn_ClcProf(case when t.CardStatus_Type in (1, 3) then (t.Salary_ResSm + t.SickList_ResSm + t.Vocation_Sm + t.LawContract_Sm + t.AddAccr_SmClc) else 0 end) Prof_Sm,
       dbo.fn_ClcMilitary(t.Salary_ResSm + t.SickList_ResSm + t.Vocation_Sm + t.LawContract_Sm + t.AddAccr_SmClc) Military_Sm,
       t.SalBalance_BegMonthSm,
	     t.SalBalance_EndMonthSm,
       t.IncTax_Sm,
       t.CashBox_Sm,
       t.Excerpt_Sm,
       t.list_Sm,
       t.InKindPay_Sm,
       t.AddPayment_Sm
  from (
 
 select PersCard.PersCard_Id, 
        PersCard.PersCard_LName, 
		PersCard.PersCard_FName, 
		PersCard.PersCard_MName, 
		PersCard.PersCard_TIN,
		PersCard.PersCard_DOB,
		PersCard.PersCard_DOR,
		PersCard.PersCard_DOD,
		PersCard.PersCard_DOP,
		PersCard.PersCard_Exp,
		PersCard.PersCard_Grade,
		PersCard.PersCard_SEX,
		card_stat.CardStatus_Type,
                coalesce(disability.Disability_Attr,0)     Disability_Attr,
		soc_benefit.RefSocBenefit_LimSm,
		soc_benefit.RefSocBenefit_Sm,
		coalesce(tax_rel.TaxRelief_Koef,0)          TaxRelief_Koef,
		SUM(coalesce(children.Child_Count      ,0)) Child_Count,
		SUM(coalesce(sal.Salary_Hours          ,0)) Salary_Hours,
		SUM(coalesce(sal.Salary_Days           ,0)) Salary_Days,
		SUM(coalesce(sal.Salary_BaseSm         ,0)) Salary_BaseSm,
		SUM(coalesce(sal.Salary_PensSm         ,0)) Salary_PensSm,
		SUM(coalesce(sal.Salary_GradeSm        ,0)) Salary_GradeSm,
		SUM(coalesce(sal.Salary_ExpSm          ,0)) Salary_ExpSm,
		SUM(coalesce(sal.Salary_OthSm          ,0)) Salary_OthSm,
		SUM(coalesce(sal.Salary_ResSm          ,0)) Salary_ResSm,
		SUM(coalesce(sal.Salary_KTU            ,0)) Salary_KTU,
		SUM(coalesce(sal.Salary_KTUSm          ,0)) Salary_KTUSm,
		SUM(coalesce(sick.SickList_DaysEntprs   ,0)) SickList_DaysEntprs,
		SUM(coalesce(sick.SickList_SmEntprs     ,0)) SickList_SmEntprs,
		SUM(coalesce(sick.SickList_DaysSocInsrnc,0)) SickList_DaysSocInsrnc,
		SUM(coalesce(sick.SickList_SmSocInsrnc  ,0)) SickList_SmSocInsrnc,
		SUM(coalesce(sick.SickList_DaysTmpDis  ,0)) SickList_DaysTmpDis,
		SUM(coalesce(sick.SickList_ResSm       ,0)) SickList_ResSm,
		SUM(coalesce(voc.Vocation_Days         ,0)) Vocation_Days, 
		SUM(coalesce(voc.Vocation_Sm           ,0)) Vocation_Sm,
		SUM(coalesce(law.LawContract_Days      ,0)) LawContract_Days,
		SUM(coalesce(law.LawContract_Sm        ,0)) LawContract_Sm,
		SUM(coalesce(accrClc.AddAccr_Sm        ,0)) AddAccr_SmClc,
		SUM(coalesce(accrNoClc.AddAccr_Sm      ,0)) AddAccr_SmNoClc,
		SUM(coalesce(SalBalance.SalBalance_BegMonthSm,0)) SalBalance_BegMonthSm,
		SUM(coalesce(SalBalance.SalBalance_EndMonthSm,0)) SalBalance_EndMonthSm,
		SUM(coalesce(incomeTax.IncTax_Sm       ,0)) IncTax_Sm,
		SUM(coalesce(cashBox.Payment_Sm        ,0)) CashBox_Sm,
   	SUM(coalesce(excerpt.Payment_Sm        ,0)) Excerpt_Sm,
  	SUM(coalesce(list.Payment_Sm           ,0)) list_Sm,
  	SUM(coalesce(inKindPay.Payment_Sm      ,0)) InKindPay_Sm,
  	SUM(coalesce(addPayment.AddPayment_Sm  ,0)) AddPayment_Sm
   From PersCard
   LEFT JOIN (select Salary_PersCard_Id, Salary_Date, sum(Salary_KTU) Salary_KTU, sum(Salary_Hours) Salary_Hours, sum(Salary_Days) Salary_Days, sum(Salary_BaseSm)Salary_BaseSm, sum(Salary_PensSm)Salary_PensSm, 
                     sum(Salary_ExpSm)Salary_ExpSm, sum(Salary_GradeSm)Salary_GradeSm, sum(Salary_OthSm)Salary_OthSm,
					 sum(Salary_KTUSm)Salary_KTUSm, sum(Salary_ResSm) Salary_ResSm  
               from Salary 
   		 group by Salary_PersCard_Id, Salary_Date) sal 
       on sal.Salary_PersCard_Id = PersCard.PersCard_Id and sal.Salary_Date = @inDate_Clc
   LEFT JOIN (select SickList_PersCard_Id, SickList_Date, 
                     SUM(SickList_DaysEntprs) SickList_DaysEntprs,
                     SUM(SickList_SmEntprs) SickList_SmEntprs,
                     SUM(SickList_DaysSocInsrnc) SickList_DaysSocInsrnc,
                     SUM(SickList_SmSocInsrnc) SickList_SmSocInsrnc,
                     SUM(SickList_DaysTmpDis)SickList_DaysTmpDis, sum(SickList_ResSm) SickList_ResSm
               from SickList 
   		 group by SickList_PersCard_Id, SickList_Date) sick 
       on sick.SickList_PersCard_Id = PersCard.PersCard_Id and sick.SickList_Date = @inDate_Clc


   LEFT JOIN (select Vocation_PersCard_Id, Vocation_Date, SUM(Vocation_Days)Vocation_Days, sum(Vocation_Sm) Vocation_Sm
               from Vocation 
   		 group by Vocation_PersCard_Id, Vocation_Date) voc 
       on voc.Vocation_PersCard_Id = PersCard.PersCard_Id and voc.Vocation_Date = @inDate_Clc
   LEFT JOIN (select LawContract_PersCard_Id, LawContract_Date, sum(LawContract_Days) LawContract_Days ,sum(LawContract_Sm) LawContract_Sm
               from LawContract 
   		 group by LawContract_PersCard_Id, LawContract_Date) law 
       on law.LawContract_PersCard_Id = PersCard.PersCard_Id and law.LawContract_Date = @inDate_Clc
   LEFT JOIN (select AddAccr_PersCard_Id, AddAccr_Date, SUM(AddAccr_Sm) AddAccr_Sm
                from AddAccr
   		          INNER JOIN RefTypeAddAccr on RefTypeAddAccr.RefTypeAddAccr_Id = AddAccr.AddAccr_RefTypeAddAccr_Id
                where ((RefTypeAddAccr.RefTypeAddAccr_Flg & 1)>0)
   		  group by AddAccr_PersCard_Id, AddAccr_Date
            ) accrClc 
       on accrClc.AddAccr_PersCard_Id = PersCard.PersCard_Id and accrClc.AddAccr_Date = @inDate_Clc
   LEFT JOIN (select AddAccr_PersCard_Id, AddAccr_Date, SUM(AddAccr_Sm) AddAccr_Sm
                from AddAccr
   		          INNER JOIN RefTypeAddAccr on RefTypeAddAccr.RefTypeAddAccr_Id = AddAccr.AddAccr_RefTypeAddAccr_Id
                where ((RefTypeAddAccr.RefTypeAddAccr_Flg & 1) = 0)
   		  group by AddAccr_PersCard_Id, AddAccr_Date
            ) accrNoClc 
       on accrNoClc.AddAccr_PersCard_Id = PersCard.PersCard_Id and accrNoClc.AddAccr_Date = @inDate_Clc
LEFT JOIN (select CardStatus_PersCard_Id, coalesce(CardStatus_PerBeg, {d'1900-01-01'}) CardStatus_PerBeg, 
                    coalesce(CardStatus_PerEnd, {d'2500-01-01'}) CardStatus_PerEnd, max(coalesce(CardStatus_Type,0)) CardStatus_Type
               from CardStatus
			  group by CardStatus_PersCard_Id, coalesce(CardStatus_PerBeg, {d'1900-01-01'}), coalesce(CardStatus_PerEnd, {d'2500-01-01'})
	  	    ) card_stat	    
            on card_stat.CardStatus_PersCard_Id = PersCard.PersCard_Id and (dateadd(mm, 1, @inDate_Clc)-1) between card_stat.CardStatus_PerBeg and card_stat.CardStatus_PerEnd
  LEFT JOIN (select Child_PersCard_Id, SUM(coalesce(Child_Count,0)) Child_Count
               from Child
              where (dateadd(mm, 1, @inDate_Clc)-1) between coalesce(Child_PerBeg, {d'1900-01-01'}) and coalesce(Child_PerEnd, {d'2500-01-01'})
			  group by Child_PersCard_Id
	  	    ) children	    
            on children.Child_PersCard_Id = PersCard.PersCard_Id 

  LEFT JOIN (select Disability_PersCard_Id, MAX(coalesce(Disability_Attr,0)) Disability_Attr
               from Disability
              where (dateadd(mm, 1, @inDate_Clc)-1) between coalesce(Disability_PerBeg, {d'1900-01-01'}) and coalesce(Disability_PerEnd, {d'2500-01-01'})
	   group by Disability_PersCard_Id
	  	    ) disability	    
            on disability.Disability_PersCard_Id = PersCard.PersCard_Id 
  LEFT JOIN (select TaxRelief_PersCard_Id, MAX(coalesce(TaxRelief_Koef,0)) TaxRelief_Koef
               from TaxRelief
              where (dateadd(mm, 1, @inDate_Clc)-1) between coalesce(TaxRelief_PerBeg, {d'1900-01-01'}) and coalesce(TaxRelief_PerEnd, {d'2500-01-01'})
			  group by TaxRelief_PersCard_Id
	  	    ) tax_rel	    
            on tax_rel.TaxRelief_PersCard_Id = PersCard.PersCard_Id 
  LEFT JOIN (select max(RefSocBenefit_Sm) RefSocBenefit_Sm, max(RefSocBenefit_LimSm) RefSocBenefit_LimSm  
               from RefSocBenefit
			  where (dateadd(mm, 1, @inDate_Clc)-1) between coalesce(RefSocBenefit_PerBeg, {d'1900-01-01'}) and coalesce(RefSocBenefit_PerEnd, {d'2500-01-01'}) 
			)soc_benefit on 1 = 1 
  LEFT JOIN SalBalance on SalBalance_PersCard_Id = PersCard.PersCard_Id and SalBalance_Date = @inDate_Clc 
  LEFT JOIN (select IncTax_PersCard_Id, IncTax_Date, sum(IncTax_Sm) IncTax_Sm
              from IncTax 
  		 group by IncTax_PersCard_Id, IncTax_Date) incomeTax 
      on incomeTax.IncTax_PersCard_Id = PersCard.PersCard_Id and incomeTax.IncTax_Date = @inDate_Clc
   LEFT JOIN (select Payment_PersCard_Id, Payment_Date, sum(Payment_Sm) Payment_Sm
               from Payment 
              where Payment_Type = 1
                and Payment_Date between @inDate_Clc and (dateadd(mm, 1, @inDate_Clc)-1) 
   		 group by Payment_PersCard_Id, Payment_Date) cashBox 
       on cashBox.Payment_PersCard_Id = PersCard.PersCard_Id 
   LEFT JOIN (select Payment_PersCard_Id, Payment_Date, sum(Payment_Sm) Payment_Sm
               from Payment 
              where Payment_Type = 2
                and Payment_Date between @inDate_Clc and (dateadd(mm, 1, @inDate_Clc)-1) 
   		 group by Payment_PersCard_Id, Payment_Date) excerpt 
       on excerpt.Payment_PersCard_Id = PersCard.PersCard_Id 
   LEFT JOIN (select Payment_PersCard_Id, Payment_Date, sum(Payment_Sm) Payment_Sm
               from Payment 
              where Payment_Type = 3
                and Payment_Date between @inDate_Clc and (dateadd(mm, 1, @inDate_Clc)-1) 
   		 group by Payment_PersCard_Id, Payment_Date) list 
       on list.Payment_PersCard_Id = PersCard.PersCard_Id 
   LEFT JOIN (select Payment_PersCard_Id, Payment_Date, sum(Payment_Sm) Payment_Sm
               from Payment 
              where Payment_Type = 4
                and Payment_Date between @inDate_Clc and (dateadd(mm, 1, @inDate_Clc)-1) 
   		 group by Payment_PersCard_Id, Payment_Date) inKindPay 
       on inKindPay.Payment_PersCard_Id = PersCard.PersCard_Id 
   LEFT JOIN (select AddPayment_PersCard_Id, AddPayment_Date, sum(AddPayment_Sm) AddPayment_Sm
               from AddPayment 
   		 group by AddPayment_PersCard_Id, AddPayment_Date) addPayment 
       on addPayment.AddPayment_PersCard_Id = PersCard.PersCard_Id and addPayment.AddPayment_Date = @inDate_Clc
GROUP BY PersCard.PersCard_Id, PersCard.PersCard_LName, PersCard.PersCard_FName, 
         PersCard.PersCard_MName, PersCard.PersCard_TIN, card_stat.CardStatus_Type, disability.Disability_Attr,
	     PersCard.PersCard_DOB, PersCard.PersCard_DOR, PersCard.PersCard_DOD, PersCard.PersCard_DOP,
		 soc_benefit.RefSocBenefit_LimSm, soc_benefit.RefSocBenefit_Sm, tax_rel.TaxRelief_Koef, 
		 PersCard.PersCard_Grade, PersCard.PersCard_Exp, PersCard.PersCard_SEX
) t
END;

