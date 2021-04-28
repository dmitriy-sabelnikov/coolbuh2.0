--sw_v+ su_l+su_lk+su_v+su_d+su_dd
--1 ДФ
--1 квартал - da161501.1 1-3
--2 квартал - da161501.2 4-6
--3 квартал - da161501.3 7-9
--4 квартал - da161501.4 10-12

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDFRecClc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spDFRecClc];
GO

Create Procedure [dbo].[spDFRecClc]
	@inDFCt_Id  int             
AS
  Declare @socBenefit_Sm numeric(10,2) = 0;     --соц. льгота
  Declare @socBenefit_LimSm numeric(10,2) = 0;  --ограничение соц. льготы
  Declare @USREOU varchar(250); --Код ЕГРПОУ

  Declare @qrt_beg datetime; --начало квартала
  Declare @qrt_end datetime; --конец квартала
  Declare @tmp_dat datetime;
BEGIN
  SET NOCOUNT ON 
  --определяем дату начала квартала
  select @qrt_beg = DFCt_Date From DFCt where DFCt_Id = @inDFCt_Id; 
  --определяем дату конца квартала
  set @qrt_end = dateadd(mm, 3, @qrt_beg) - 1;
  
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
  set @tmp_dat = @qrt_beg;
  insert into #Period (dat) values (@tmp_dat);
  set @tmp_dat = dateadd(mm, 1, @tmp_dat);
  insert into #Period (dat) values (@tmp_dat);
  set @tmp_dat = dateadd(mm, 1, @tmp_dat);
  insert into #Period (dat) values (@tmp_dat);
  
  --определение социальной льготы
  select @socBenefit_Sm = Max(RefSocBenefit_Sm), @socBenefit_LimSm = Max(RefSocBenefit_LimSM)
    from RefSocBenefit (NOLOCK) 
   where @qrt_end between coalesce(RefSocBenefit_PerBeg, {d'1900-01-01'}) and coalesce(RefSocBenefit_PerEnd, {d'2500-01-01'})
  --Определение кода ЕГРПОУ
  select @USREOU = SetupApp_ValueString from SetupApp (NOLOCK) where SetupApp_Type = 5;                            

  insert into DFRec (DFRec_DFCt_Id, DFRec_USREOU, DFRec_Type, DFRec_FName, DFRec_MName, DFRec_LName, 
                     DFRec_TIN, DFRec_AccrIncSm, DFRec_PaidIncSm, DFRec_AccrTaxSm, DFRec_TransfTaxSm, 
					 DFRec_IncFlg, DFRec_DOR, DFRec_DOD, DFRec_SocBenefitFlg, 
					 DFRec_Flg 
					 )
   (select @inDFCt_Id        DFRec_DFCt_Id,
           @USREOU           DFRec_USREOU,             
	   0                 DFRec_Type,               
           tt.PersCard_FName DFRec_FName,              
           tt.PersCard_MName DFRec_MName,              
           tt.PersCard_LName DFRec_LName,              
           tt.PersCard_TIN DFRec_TIN,  
           sum(coalesce(tt.s_dox,0)) DFRec_AccrIncSm, 
           sum(coalesce(tt.s_nar,0)) DFRec_PaidIncSm, 
           sum(coalesce(tt.s_taxn,0)) DFRec_AccrTaxSm, 
           sum(coalesce(tt.s_taxn,0)) DFRec_TransfTaxSm, 
           MAX(ozn_dox) DFRec_IncFlg, 
           d_priyn DFRec_DOR, 
           d_zviln DFRec_DOD,
           MAX(ozn_pilg) DFRec_SocBenefitFlg,
           oznaka DFRec_Flg 
   from ( 
     select t.dat, t.PersCard_TIN, t.PersCard_FName, t.PersCard_MName, t.PersCard_LName, t.s_dox, t.s_dox s_nar, t.children, t.koef,  
	        (case when t.typ = 2 then 2 else 101 end) ozn_dox, t.d_priyn, t.d_zviln, 
			(case when round(t.koef, 0) = 1.0 or round(t.koef, 0) = 2.0 then 1
			     when round(t.koef, 0) = 3.0 then 5.0
				 when round(t.koef, 0) = 4.0 or round(t.koef, 0) = 5.0 then 2
				 when round(t.koef, 0) = 9.0 then 3.0
				 when round(t.koef, 0) = 14.0 then 4
				 else 0 
            end) ozn_pilg,
			0 oznaka,
            (dbo.fn_ClcTax(t.s_dox , @socBenefit_Sm, @socBenefit_LimSm, t.koef, t.children)) s_taxn
      from (
             select #Period.dat,
                    PersCard.PersCard_Id,
                    PersCard.PersCard_TIN,
                    PersCard.PersCard_FName,
                    PersCard.PersCard_MName,
                    PersCard.PersCard_LName,
                    coalesce(sal.Salary_ResSm, 0) + coalesce(sick.SickList_ResSm, 0) + coalesce(voc.Vocation_Sm, 0) +
                    coalesce(law.LawContract_Sm, 0) + coalesce(accr_clc.AddAccr_Sm, 0) s_dox, 
				  
				  coalesce((select sum(coalesce(Child_Count,0)) child_Count 
	  			     from Child 
	  			    where Dateadd(mm, 1, #Period.dat)-1 between coalesce(Child_PerBeg, {d'1900-01-01'}) and coalesce(Child_PerEnd, {d'2500-01-01'}) 
	  				  and Child_PersCard_Id = PersCard.PersCard_Id),0) children,
				  
				  coalesce((select max(coalesce(TaxRelief_Koef,0)) koef 
	  			     from TaxRelief 
	  			    where @qrt_end between coalesce(TaxRelief_PerBeg, {d'1900-01-01'}) and coalesce(TaxRelief_PerEnd, {d'2500-01-01'}) 
	  				  and TaxRelief_PersCard_Id = PersCard.PersCard_Id),0) koef,
				  
				  coalesce((select max(coalesce(CardStatus_Type,0)) typ  --1-постоянный, 2-временный, 3-ассоциированный
	  			     from CardStatus 
	  			    where @qrt_end between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd, {d'2500-01-01'}) 
	  				  and CardStatus_PersCard_Id = PersCard.PersCard_Id),0) typ,
				  
				  PersCard_DOR d_priyn,
				  PersCard_DOD d_zviln

             From PersCard (NOLOCK)
             inner join #Period on 1 = 1
             LEFT JOIN (select Salary_PersCard_Id, Salary_Date, sum(Salary_ResSm) Salary_ResSm
                         from Salary (NOLOCK) 
             		 group by Salary_PersCard_Id, Salary_Date) sal 
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
                 on law.LawContract_PersCard_Id = PersCard.PersCard_Id and law.LawContract_Date = #Period.dat
             LEFT JOIN (select AddAccr_PersCard_Id, AddAccr_Date, SUM(AddAccr_Sm) AddAccr_Sm
                          from AddAccr (NOLOCK)
           			   INNER JOIN RefTypeAddAccr (NOLOCK) on RefTypeAddAccr.RefTypeAddAccr_Id = AddAccr.AddAccr_RefTypeAddAccr_Id
           			  where (RefTypeAddAccr.RefTypeAddAccr_Flg & 1) > 0
           			  group by AddAccr_PersCard_Id, AddAccr_Date) accr_clc 
           	     on accr_clc.AddAccr_PersCard_Id = PersCard.PersCard_Id and accr_clc.AddAccr_Date = #Period.dat 
            --where PersCard_TIN = '2729812858'
           ) t
		 ) tt
   where tt.s_dox > 0 or tt.s_taxn > 0
   group by tt.PersCard_TIN, tt.PersCard_FName, tt.PersCard_MName, tt.PersCard_LName, oznaka, tt.d_priyn, tt.d_zviln
   )
   drop table #Period;  
END
