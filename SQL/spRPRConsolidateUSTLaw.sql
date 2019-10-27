--ÇÂIÒ ªÑÂ ïî äîãîâîðàõ ÖÏÕ
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRPRConsolidateUSTLaw]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRPRConsolidateUSTLaw];
GO
Create Procedure [dbo].[spRPRConsolidateUSTLaw] 
    @inDate_Clc           date,
	@outLawConstCntWrk    int output,
	@outLawTmpCntWrk      int output,
	@outLawAssCntWrk      int output,
	@outLawConstFromSm    numeric(10,2) output,
	@outLawTmpFromSm      numeric(10,2) output,
	@outLawAssFromSm      numeric(10,2) output
AS                            
BEGIN
select @outLawConstCntWrk = tt.LawConstCntWrk, @outLawTmpCntWrk = tt.LawTmpCntWrk, @outLawAssCntWrk = tt.LawAssCntWrk,
       @outLawConstFromSm = tt.LawConstFromSm, @outLawTmpFromSm = tt.LawTmpFromSm, @outLawAssFromSm = tt.LawAssFromSm
  from (
select MAX((case when t.stat_type = 1 then t.cnt else 0 end)) LawConstCntWrk,
       MAX((case when t.stat_type = 2 then t.cnt else 0 end)) LawTmpCntWrk,
       MAX((case when t.stat_type = 3 then t.cnt else 0 end)) LawAssCntWrk,
	   MAX((case when t.stat_type = 1 then t.res_sm else 0 end)) LawConstFromSm,
       MAX((case when t.stat_type = 2 then t.res_sm else 0 end)) LawTmpFromSm,
       MAX((case when t.stat_type = 3 then t.res_sm else 0 end)) LawAssFromSm
  from (
 select stat_type, 
        SUM(coalesce(sal.Salary_ResSm, 0)+coalesce(law.LawContract_Sm, 0) + coalesce(accr_clc.AddAccr_Sm, 0) + coalesce(voc.Vocation_Sm, 0)) res_sm,
		count(stat_type) cnt
   From PersCard
 inner join (select CardStatus_PersCard_Id ,max(CardStatus_Type) stat_type 
               from CardStatus 
			  where @inDate_Clc between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd, {d'2500-01-01'})
			  group by CardStatus_PersCard_Id) stat on stat.CardStatus_PersCard_Id = PersCard.PersCard_Id  
   LEFT JOIN (select Salary_PersCard_Id, Salary_Date, sum(Salary_ResSm) Salary_ResSm
               from Salary 
   		 group by Salary_PersCard_Id, Salary_Date) sal 
       on sal.Salary_PersCard_Id = PersCard.PersCard_Id and sal.Salary_Date = @inDate_Clc
   LEFT JOIN (select SickList_PersCard_Id, SickList_Date, sum(SickList_ResSm) SickList_ResSm
               from SickList 
   		 group by SickList_PersCard_Id, SickList_Date) sick 
       on sick.SickList_PersCard_Id = PersCard.PersCard_Id and sick.SickList_Date = @inDate_Clc
   LEFT JOIN (select Vocation_PersCard_Id, Vocation_Date, sum(Vocation_Sm) Vocation_Sm
               from Vocation 
   		 group by Vocation_PersCard_Id, Vocation_Date) voc 
       on voc.Vocation_PersCard_Id = PersCard.PersCard_Id and voc.Vocation_Date = @inDate_Clc
   LEFT JOIN (select LawContract_PersCard_Id, LawContract_Date, sum(LawContract_Sm) LawContract_Sm
               from LawContract 
   		 group by LawContract_PersCard_Id, LawContract_Date) law 
       on law.LawContract_PersCard_Id = PersCard.PersCard_Id and law.LawContract_Date = @inDate_Clc
   LEFT JOIN (select AddAccr_PersCard_Id, AddAccr_Date, SUM(AddAccr_Sm) AddAccr_Sm
                from AddAccr
   		   INNER JOIN RefTypeAddAccr on RefTypeAddAccr.RefTypeAddAccr_Id = AddAccr.AddAccr_RefTypeAddAccr_Id
   		  where (RefTypeAddAccr.RefTypeAddAccr_Flg & 1) > 0
   		  group by AddAccr_PersCard_Id, AddAccr_Date) accr_clc 
       on accr_clc.AddAccr_PersCard_Id = PersCard.PersCard_Id and accr_clc.AddAccr_Date = @inDate_Clc
where coalesce(sal.Salary_ResSm, 0) + coalesce(law.LawContract_Sm, 0) + coalesce(accr_clc.AddAccr_Sm, 0) + coalesce(voc.Vocation_Sm, 0) + coalesce(sick.SickList_ResSm, 0) != 0
group by stat_type
) t
)tt
END








