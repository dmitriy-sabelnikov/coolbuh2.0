--Персонификация
--Таблица 6 e04t06f

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUST6Clc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUST6Clc];
GO
Create Procedure [dbo].[spUST6Clc]
	@inUSTCt_Id  int 
AS   
  Declare @date_ust datetime;                         
BEGIN
  SET NOCOUNT ON

  select @date_ust = USTCt_Date From USTCt (NOLOCK) where USTCt_Id = @inUSTCt_Id;

  insert into UST6 (UST6_USTCt_Id, UST6_ISUKR, UST6_SEX, UST6_TIN, UST6_LName, UST6_FName, UST6_MName,    
                    UST6_Category_Cd, UST6_Accr_Cd, UST6_Month, UST6_Year, UST6_DisabDays, UST6_NoSalDays, 
                    UST6_VocDays, UST6_EmplDays, UST6_TotalSm, UST6_MaxSm, UST6_DiffSm, UST6_WithHeldUSTSm, 
                    UST6_AccrUSTSm, UST6_WB, UST6_SpecExp, UST6_PWT, UST6_NWP) 
--declare 
--  @inDate   DateTime = {d'2018-01-01'}
  select
        @inUSTCt_Id                                             UST6_USTCt_Id 
        ,1                                                           UST6_ISUKR          --Громадянство України (1 - так)
        ,PersCard.PersCard_Sex                                       UST6_SEX            --ST
        ,PersCard.PersCard_TIN                                       UST6_TIN            --ИНН
        ,PersCard.PersCard_LName                                     UST6_LName          --Прізвище    
        ,PersCard.PersCard_FName                                     UST6_FName          --Ім'я
        ,PersCard.PersCard_MName                                     UST6_MName          --По батькові
        ,(case when coalesce(disab.Attr, 0) <= 1 then 1		         
               else disab.Attr								         
           end)	                                                     UST6_Category_Cd    --Код категории застрахованного лица     
        ,0                                                           UST6_Accr_Cd        --Код типу нарахувань
        ,MONTH(@date_ust)                                            UST6_Month          --Місяць, за який проведено нарахування
        ,YEAR(@date_ust)                                             UST6_Year	         --Рік, за який проведено нарахування
        ,0                                                           UST6_DisabDays      --Кількість календарних днів тимчасової непрацездатності                                         
        ,0                                                           UST6_NoSalDays      --Кількість календарних днів без збереження заробітної плати  
        ,DAY(dateadd(dd, -1, dateadd(mm, 1, @date_ust)))             UST6_EmplDays       --Кількість днів перебування у трудових / ЦП відносинах    
        ,0                                                           UST6_VocDays        --Кількість календарних днів відпустки у зв'язку з вагітністю та пологами
        ,coalesce(sal.Salary_ResSm, 0) + coalesce(addAccrClc.AddAccr_Sm, 0) UST6_TotalSm --Загальна сума нарахованої заробітної плати/доходу (усього з початку звітного місяця)        
        ,coalesce(sal.Salary_ResSm, 0) + coalesce(addAccrClc.AddAccr_Sm, 0) UST6_MaxSm   --Сума нарахованої заробітної плати/доходу у межах максимальної величини, на яку нараховуєтьсяєдиний внесок
        ,0                                                           UST6_DiffSm         --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
		,0                                                           UST6_WithHeldUSTSm  --Сума утриманого єдиного внеску за звітний місяць (із заробітної плати/доходу)
        ,0                                                           UST6_AccrUSTSm      --Сума нарахованного єдиного внеску за звітний місяць (із заробітної плати/доходу)
		--cardstat = 2 временный
        ,(case when coalesce(cardstat.typ, 0) = 2 then 0 else 1 end) UST6_WB             --Ознака наявності трудової книжки (1 – так, 0 – ні)         
        ,(case when coalesce(cardspec.cd,0) > 0 then 1 else 0 end)   UST6_SpecExp        --Ознака наявності спец. стажу (1 – так, 0 – ні)        
        ,0                                                           UST6_PWT            --Ознака неповного робочого часу (1 – так, 0 – ні)
		,0                                                           UST6_NWP            --Ознака нового робочого місця (1 – так, 0 – ні)        
	From PersCard (NOLOCK)
	left join ( select Salary_PersCard_Id, SUM(coalesce(Salary_ResSm,0)) Salary_ResSm
                  from Salary (NOLOCK)
                 where Salary_date = @date_ust
                 group by Salary_PersCard_Id
              ) sal on sal.Salary_PersCard_Id = PersCard.PersCard_Id
    left join (select AddAccr_PersCard_Id, Sum(coalesce(AddAccr_Sm, 0)) AddAccr_Sm 
                 from AddAccr (NOLOCK)
                inner join RefTypeAddAccr on RefTypeAddAccr.RefTypeAddAccr_Id = AddAccr.AddAccr_RefTypeAddAccr_Id
                where (RefTypeAddAccr.RefTypeAddAccr_Flg & 1) > 0
                  and AddAccr_Date  = @date_ust
                group by AddAccr_PersCard_Id
              ) addAccrClc on addAccrClc.AddAccr_PersCard_Id = PersCard.PersCard_Id
    left join (select Disability_PersCard_Id, MAX(coalesce(Disability_Attr, 0)) Attr
                From Disability (NOLOCK)
               where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(Disability_PerBeg, {d'1900-01-01'}) and coalesce(Disability_PerEnd,{d'2500-01-01'})
               group by Disability_PersCard_Id ) disab on disab.Disability_PersCard_Id = PersCard.PersCard_Id 
    left join (select CardStatus_PersCard_Id, MAX(coalesce(CardStatus_Type, 0)) typ
                 From CardStatus (NOLOCK)
                where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd,{d'2500-01-01'})
                group by CardStatus_PersCard_Id ) cardstat on cardstat.CardStatus_PersCard_Id = PersCard.PersCard_Id 
    left join (select CardSpecExp_PersCard_Id, MAX(coalesce(RefSpecExp.RefSpecExp_Cd, 0)) cd
                 From CardSpecExp (NOLOCK)
                inner join RefSpecExp (NOLOCK) on RefSpecExp.RefSpecExp_Id = CardSpecExp.CardSpecExp_RefSpecExp_Id
                where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(CardSpecExp_PerEnd,{d'2500-01-01'})
                group by CardSpecExp_PersCard_Id ) cardspec on cardspec.CardSpecExp_PersCard_Id = PersCard.PersCard_Id 
   where coalesce(sal.Salary_ResSm, 0) + coalesce(addAccrClc.AddAccr_Sm, 0) <> 0
	--where (coalesce(sal.Salary_ResSm, 0) + coalesce(addAccrClc.AddAccr_Sm, 0) + 
	--       coalesce(sickl.SickList_ResSm, 0) +	coalesce(voc.Vocation_Sm, 0)+ 
	--	   coalesce(law.Vocation_Sm, 0)) != 0
UNION ALL
/*==============================================================================================*/
/*                                      Отпускные                                               */
/*==============================================================================================*/
  select 
         @inUSTCt_Id                                                 UST6_USTCt_Id 
        ,1                                                           UST6_ISUKR         --Громадянство України (1 - так)
        ,PersCard.PersCard_Sex                                       UST6_SEX           --ST
        ,PersCard.PersCard_TIN                                       UST6_TIN           --ИНН
        ,PersCard.PersCard_LName                                     UST6_LName         --Прізвище    
        ,PersCard.PersCard_FName                                     UST6_FName         --Ім'я
        ,PersCard.PersCard_MName                                     UST6_MName         --По батькові
        ,(case when coalesce(disab.Attr, 0) <= 1 then 1		         
               else disab.Attr								         
           end)	                                                     UST6_Category_Cd   --Код категории застрахованного лица     
        ,10                                                          UST6_Accr_Cd       --Код типу нарахувань
        ,MONTH(Vocation_PayDate)                                     UST6_Month         --Місяць, за який проведено нарахування
        ,YEAR(Vocation_PayDate)                                      UST6_Year	     	--Рік, за який проведено нарахування
        ,0                                                           UST6_DisabDays     --Кількість календарних днів тимчасової непрацездатності                                         
        ,0                                                           UST6_NoSalDays     --Кількість календарних днів без збереження заробітної плати  
        ,0                                                           UST6_EmplDays      --Кількість днів перебування у трудових / ЦП відносинах    
        ,0                                                           UST6_VocDays        --Кількість календарних днів відпустки у зв'язку з вагітністю та пологами
        ,Vocation_Sm                                                 UST6_TotalSm       --Загальна сума нарахованої заробітної плати/доходу (усього з початку звітного місяця)        
		,Vocation_Sm                                                 UST6_MaxSm         --Сума нарахованої заробітної плати/доходу у межах максимальної величини, на яку нараховуєтьсяєдиний внесок
        ,0                                                           UST6_DiffSm         --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
        ,0                                                           UST6_WithHeldUSTSm  --Сума утриманого єдиного внеску за звітний місяць (із заробітної плати/доходу)
        ,0                                                           UST6_AccrUSTSm      --Сума нарахованного єдиного внеску за звітний місяць (із заробітної плати/доходу)
        --cardstat = 2 временный
        ,(case when coalesce(cardstat.typ, 0) = 2 then 0 else 1 end) UST6_WB            --Ознака наявності трудової книжки (1 – так, 0 – ні)         
        ,(case when coalesce(cardspec.cd,0) > 0 then 1 else 0 end)   UST6_SpecExp       --Ознака наявності спец. стажу (1 – так, 0 – ні)        
        ,0                                                           UST6_PWT            --Ознака неповного робочого часу (1 – так, 0 – ні)
        ,0                                                           UST6_NWP           --Ознака нового робочого місця (1 – так, 0 – ні)        
	From PersCard (NOLOCK)
	inner join Vocation on Vocation_PersCard_Id = PersCard.PersCard_Id and Vocation_Date = @date_ust 
    left join (select Disability_PersCard_Id, MAX(coalesce(Disability_Attr, 0)) Attr
                 From Disability (NOLOCK)
                where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(Disability_PerBeg, {d'1900-01-01'}) and coalesce(Disability_PerEnd,{d'2500-01-01'})
                group by Disability_PersCard_Id ) disab on disab.Disability_PersCard_Id = PersCard.PersCard_Id 
    left join (select CardStatus_PersCard_Id, MAX(coalesce(CardStatus_Type, 0)) typ
                 From CardStatus (NOLOCK)
                where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd,{d'2500-01-01'})
                group by CardStatus_PersCard_Id ) cardstat on cardstat.CardStatus_PersCard_Id = PersCard.PersCard_Id 
    left join (select CardSpecExp_PersCard_Id, MAX(coalesce(RefSpecExp.RefSpecExp_Cd, 0)) cd
                 From CardSpecExp (NOLOCK)
                inner join RefSpecExp (NOLOCK) on RefSpecExp.RefSpecExp_Id = CardSpecExp.CardSpecExp_RefSpecExp_Id
                where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(CardSpecExp_PerEnd,{d'2500-01-01'})
                group by CardSpecExp_PersCard_Id ) cardspec on cardspec.CardSpecExp_PersCard_Id = PersCard.PersCard_Id 
   where coalesce(Vocation.Vocation_Sm, 0) > 0
UNION ALL
/*==============================================================================================*/
/*                                      Договора ГПХ                                            */
/*==============================================================================================*/
  select 
         @inUSTCt_Id                                                 UST6_USTCt_Id 
        ,1                                                           UST6_ISUKR         --Громадянство України (1 - так)
        ,PersCard.PersCard_Sex                                       UST6_SEX           --ST
        ,PersCard.PersCard_TIN                                       UST6_TIN           --ИНН
        ,PersCard.PersCard_LName                                     UST6_LName         --Прізвище    
        ,PersCard.PersCard_FName                                     UST6_FName         --Ім'я
        ,PersCard.PersCard_MName                                     UST6_MName         --По батькові
        ,26	                                                         UST6_Category_Cd   --Код категории застрахованного лица     
        ,0                                                           UST6_Accr_Cd       --Код типу нарахувань
        ,MONTH(LawContract_PayDate)                                  UST6_Month         --Місяць, за який проведено нарахування
        ,YEAR(LawContract_PayDate)                                   UST6_Year	     	--Рік, за який проведено нарахування
        ,0                                                           UST6_DisabDays     --Кількість календарних днів тимчасової непрацездатності                                         
        ,0                                                           UST6_NoSalDays     --Кількість календарних днів без збереження заробітної плати  
        ,DAY(dateadd(dd, -1, dateadd(mm, 1, @date_ust)))             UST6_EmplDays      --Кількість днів перебування у трудових / ЦП відносинах    
        ,0                                                           UST6_VocDays        --Кількість календарних днів відпустки у зв'язку з вагітністю та пологами
        ,LawContract_Sm                                              UST6_TotalSm       --Загальна сума нарахованої заробітної плати/доходу (усього з початку звітного місяця)        
        ,LawContract_Sm                                              UST6_MaxSm         --Сума нарахованої заробітної плати/доходу у межах максимальної величини, на яку нараховуєтьсяєдиний внесок
        ,0                                                           UST6_DiffSm         --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
		,round((LawContract_Sm * 0.026),2)                           UST6_WithHeldUSTSm  --Сума утриманого єдиного внеску за звітний місяць (із заробітної плати/доходу)
        ,0                                                           UST6_AccrUSTSm      --Сума нарахованного єдиного внеску за звітний місяць (із заробітної плати/доходу)
        --cardstat = 2 временный
        ,(case when coalesce(cardstat.typ, 0) = 2 then 0 else 1 end) UST6_WB            --Ознака наявності трудової книжки (1 – так, 0 – ні)         
        ,(case when coalesce(cardspec.cd,0) > 0 then 1 else 0 end)   UST6_SpecExp       --Ознака наявності спец. стажу (1 – так, 0 – ні)        
        ,0                                                           UST6_PWT            --Ознака неповного робочого часу (1 – так, 0 – ні)
        ,0                                                           UST6_NWP           --Ознака нового робочого місця (1 – так, 0 – ні)        
	From PersCard (NOLOCK)
	inner join LawContract (NOLOCK) on LawContract_PersCard_Id = PersCard.PersCard_Id and LawContract_Date = @date_ust 
    left join (select CardStatus_PersCard_Id, MAX(coalesce(CardStatus_Type, 0)) typ
                From CardStatus (NOLOCK)
               where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd,{d'2500-01-01'})
               group by CardStatus_PersCard_Id ) cardstat on cardstat.CardStatus_PersCard_Id = PersCard.PersCard_Id 
    left join (select CardSpecExp_PersCard_Id, MAX(coalesce(RefSpecExp.RefSpecExp_Cd, 0)) cd
                 From CardSpecExp (NOLOCK)
                inner join RefSpecExp (NOLOCK) on RefSpecExp.RefSpecExp_Id = CardSpecExp.CardSpecExp_RefSpecExp_Id
                where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(CardSpecExp_PerEnd,{d'2500-01-01'})
                group by CardSpecExp_PersCard_Id ) cardspec on cardspec.CardSpecExp_PersCard_Id = PersCard.PersCard_Id 
   where coalesce(LawContract_Sm, 0) > 0
UNION ALL
/*==============================================================================================*/
/*                                      Больничные                                              */
/*==============================================================================================*/
  select 
         @inUSTCt_Id                                                 UST6_USTCt_Id 
        ,1                                                           UST6_ISUKR          --Громадянство України (1 - так)
        ,PersCard.PersCard_Sex                                       UST6_SEX            --ST
        ,PersCard.PersCard_TIN                                       UST6_TIN            --ИНН
        ,PersCard.PersCard_LName                                     UST6_LName          --Прізвище    
        ,PersCard.PersCard_FName                                     UST6_FName          --Ім'я
        ,PersCard.PersCard_MName                                     UST6_MName          --По батькові
        ,29	                                                         UST6_Category_Cd    --Код категории застрахованного лица     
        ,0                                                           UST6_Accr_Cd        --Код типу нарахувань
        ,MONTH(SickList_PayDate)                                     UST6_Month          --Місяць, за який проведено нарахування
        ,YEAR(SickList_PayDate)                                      UST6_Year	     	 --Рік, за який проведено нарахування
        ,SickList_DaysSocInsrnc + SickList_DaysEntprs                UST6_DisabDays      --Кількість календарних днів тимчасової непрацездатності                                         
        ,0                                                           UST6_NoSalDays      --Кількість календарних днів без збереження заробітної плати  
        ,DAY(dateadd(dd, -1, dateadd(mm, 1, @date_ust)))               UST6_EmplDays       --Кількість днів перебування у трудових / ЦП відносинах    
        ,0                                                           UST6_VocDays        --Кількість календарних днів відпустки у зв'язку з вагітністю та пологами
        ,SickList_ResSm                                              UST6_TotalSm        --Загальна сума нарахованої заробітної плати/доходу (усього з початку звітного місяця)        
        ,SickList_ResSm                                              UST6_MaxSm          --Сума нарахованої заробітної плати/доходу у межах максимальної величини, на яку нараховуєтьсяєдиний внесок
        ,0                                                           UST6_DiffSm         --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
        ,round((SickList_ResSm * 0.02),2)                            UST6_WithHeldUSTSm  --Сума утриманого єдиного внеску за звітний місяць (із заробітної плати/доходу)
        ,0                                                           UST6_AccrUSTSm      --Сума нарахованного єдиного внеску за звітний місяць (із заробітної плати/доходу)
        --cardstat = 2 временный
        ,(case when coalesce(cardstat.typ, 0) = 2 then 0 else 1 end) UST6_WB             --Ознака наявності трудової книжки (1 – так, 0 – ні)         
        ,(case when coalesce(cardspec.cd,0) > 0 then 1 else 0 end)   UST6_SpecExp        --Ознака наявності спец. стажу (1 – так, 0 – ні)        
        ,0                                                           UST6_PWT            --Ознака неповного робочого часу (1 – так, 0 – ні)
        ,0                                                           UST6_NWP            --Ознака нового робочого місця (1 – так, 0 – ні)        
	From PersCard (NOLOCK)
	inner join SickList (NOLOCK) on SickList_PersCard_Id = PersCard.PersCard_Id and SickList_Date = @date_ust 
    left join (select CardStatus_PersCard_Id, MAX(coalesce(CardStatus_Type, 0)) typ
                 From CardStatus (NOLOCK)
                where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd,{d'2500-01-01'})
                group by CardStatus_PersCard_Id ) cardstat on cardstat.CardStatus_PersCard_Id = PersCard.PersCard_Id 
    left join (select CardSpecExp_PersCard_Id, MAX(coalesce(RefSpecExp.RefSpecExp_Cd, 0)) cd
                From CardSpecExp (NOLOCK)
               inner join RefSpecExp (NOLOCK) on RefSpecExp.RefSpecExp_Id = CardSpecExp.CardSpecExp_RefSpecExp_Id
               where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(CardSpecExp_PerEnd,{d'2500-01-01'})
               group by CardSpecExp_PersCard_Id ) cardspec on cardspec.CardSpecExp_PersCard_Id = PersCard.PersCard_Id 
   where coalesce(SickList_ResSm, 0) > 0
END;   
