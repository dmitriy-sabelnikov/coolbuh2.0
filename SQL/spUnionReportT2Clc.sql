/****** Script Date: 27.04.2021 9:00:22 ******/
--Объединенная отчетность. Расчет таблицы 2
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT2Clc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportT2Clc];
GO
Create Procedure [dbo].[spUnionReportT2Clc]
	@inUnionReportT2_CtId  int 
AS   
  DECLARE @quarter int,                         --квартал
          @year    int,                         --год
          @month   int,                         --месяц
          @date_begin DateTime,                 --дата начала учетного периода
          @socBenefit_Sm numeric(10,2) = 0,     --соц. льгота
          @socBenefit_LimSm numeric(10,2) = 0,  --ограничение соц. льготы
          @USREOU varchar(250);                  --Код ЕГРПОУ
                                
BEGIN
    SET NOCOUNT ON

    SELECT @quarter = UnionReportCt_Qrt,
           @year    = UnionReportCt_Year
      FROM dbo.UnionReportCt (NOLOCK)
     WHERE UnionReportCt_Id = @inUnionReportT2_CtId
    
    IF @year IS NULL or @quarter is NULL
       return 
    
    IF @quarter = 4 
      SET @month = 10
    ELSE IF @quarter = 3
      SET @month = 7
    ELSE IF @quarter = 2
      SET @month = 4
    ELSE
      SET @month = 1
	
	--Дата начала квартала   
    SET @date_begin = datefromparts(@year, @month, 1)
    --Создаем временную таблицу периодов  
    IF OBJECT_ID('tempdb..#Period') IS NOT NULL
       DROP TABLE #Period
    CREATE TABLE #Period
    (
       [dat] datetime NOT NULL PRIMARY KEY  
    ) 
    INSERT INTO #Period (dat) VALUES (@date_begin), (dateadd(mm, 1, @date_begin)), (dateadd(mm, 2, @date_begin))
    
    --определение социальной льготы
    SELECT @socBenefit_Sm = Max(RefSocBenefit_Sm), 
           @socBenefit_LimSm = Max(RefSocBenefit_LimSM)
      FROM RefSocBenefit rsb (NOLOCK)
     CROSS APPLY(SELECT MAX(dat) dat FROM #Period) p
     WHERE DATEADD(dd, -1, DATEADD(mm, 1, p.dat)) between ISNULL(rsb.RefSocBenefit_PerBeg, {d'1900-01-01'}) and ISNULL(rsb.RefSocBenefit_PerEnd, {d'2500-01-01'})
  
     --Определение кода ЕГРПОУ
     SELECT @USREOU = SetupApp_ValueString 
       FROM SetupApp 
      WHERE SetupApp_Type = 5;       

    IF OBJECT_ID('tempdb..#UnionReportT2') IS NOT NULL
       DROP TABLE #UnionReportT2
    CREATE TABLE #UnionReportT2
    (
        dat datetime NOT NULL,            --Отчетный период
        id int,                           --id карточки работника
        TIN nvarchar(12),                 --ИНН работника
        first_name nvarchar(35),          --Имя
        middle_name nvarchar(35),         --Отчество
        last_name nvarchar(35),           --Фамилия
        accr_inc_sm numeric(16,2),        --Сумма начисленного дохода
		children int,                     --Дети
        relief_flag  int,                 --признак льготы
        accr_flag int,                    --Признак дохода
	    DOR datetime,                     --Дата прийома на работу
	    DOD datetime,                     --Дата увольнения
        tax_koef numeric(10,2),           --коэффициент льготы
        tax_sm numeric(16,2),             --сумма налога    
        war_sm numeric(16,2),             --сумма военного сбора
        CONSTRAINT PK_temp_T2 PRIMARY KEY (dat, id)
    )
     

    INSERT INTO #UnionReportT2 (dat, id, TIN, first_name, middle_name, last_name, accr_inc_sm, children, relief_flag, accr_flag, DOR, DOD, tax_koef, tax_sm, war_sm)
    SELECT p.dat,
           pc.PersCard_Id,
           pc.PersCard_TIN,
           pc.PersCard_FName,
           pc.PersCard_MName,
           pc.PersCard_LName,
           ISNULL(sal.sm, 0) + ISNULL(sick.sm, 0) + ISNULL(voc.sm, 0) + ISNULL(law.sm, 0) + ISNULL(accr_clc.sm, 0),
           children.cnt,
           (case when round(tax.koef, 0) = 1.0 or round(tax.koef, 0) = 2.0 then 1
			     when round(tax.koef, 0) = 3.0 then 5
				 when round(tax.koef, 0) = 4.0 or round(tax.koef, 0) = 5.0 then 2
				 when round(tax.koef, 0) = 9.0 then 3
				 when round(tax.koef, 0) = 14.0 then 4
				 else 0 
            end) relief_flag,
           IIF(stat.typ = 2, 2, 101) accr_flag,
           pc.PersCard_DOR,
           pc.PersCard_DOD,
           tax.koef,
           0 tax_sm,
           0 war_sm
      FROM PersCard pc (NOLOCK)
      INNER JOIN #Period p ON 1=1
      OUTER APPLY (SELECT SUM(ISNULL(s.Salary_ResSm, 0)) sm
                     FROM Salary s (NOLOCK)
                    WHERE s.Salary_PersCard_Id = pc.PersCard_Id
                      AND s.Salary_Date = p.dat
                  ) sal
      OUTER APPLY (SELECT SUM(ISNULL(sl.SickList_ResSm, 0)) sm
                     FROM SickList sl (NOLOCK)
                    WHERE sl.SickList_PersCard_Id = pc.PersCard_Id
                      AND sl.SickList_Date = p.dat
                  ) sick
      OUTER APPLY (SELECT SUM(ISNULL(v.Vocation_Sm, 0)) sm
                    FROM Vocation v (NOLOCK)
                   WHERE v.Vocation_PersCard_Id = pc.PersCard_Id
                    AND v.Vocation_Date = p.dat  
                  ) voc
      OUTER APPLY (SELECT SUM(ISNULL(lc.LawContract_Sm, 0)) sm
                     FROM LawContract lc (NOLOCK)
                    WHERE lc.LawContract_PersCard_Id = pc.PersCard_Id
                      AND lc.LawContract_Date = p.dat 
                   ) law
      OUTER APPLY (SELECT SUM(ISNULL(aa.AddAccr_Sm, 0)) sm
                     FROM AddAccr aa (NOLOCK)
     		       INNER JOIN RefTypeAddAccr rtaa (NOLOCK) on rtaa.RefTypeAddAccr_Id = aa.AddAccr_RefTypeAddAccr_Id
     		       WHERE aa.AddAccr_PersCard_Id = pc.PersCard_Id 
                      AND (rtaa.RefTypeAddAccr_Flg & 1) > 0
                      AND aa.AddAccr_Date = p.dat
                   ) accr_clc
       OUTER APPLY (SELECT SUM(ISNULL(c.Child_Count, 0)) cnt
                     FROM Child c (NOLOCK)
                     WHERE c.Child_PersCard_Id = pc.PersCard_Id 
                      AND DATEADD(dd, -1, Dateadd(mm, 1, p.dat)) between ISNULL(c.Child_PerBeg, {d'1900-01-01'}) and ISNULL(c.Child_PerEnd, {d'2500-01-01'})
                    ) children
       OUTER APPLY (SELECT MAX(ISNULL(tr.TaxRelief_Koef, 0)) koef
                     FROM TaxRelief tr (NOLOCK)
                     CROSS APPLY (SELECT MAX(dat) dat FROM #Period) p2 
                     WHERE tr.TaxRelief_PersCard_Id = pc.PersCard_Id
                      AND DATEADD(dd, -1, DATEADD(mm, 1, p2.dat)) between ISNULL(tr.TaxRelief_PerBeg, {d'1900-01-01'}) and ISNULL(tr.TaxRelief_PerEnd, {d'2500-01-01'})
                    ) tax
       OUTER APPLY (SELECT MAX(ISNULL(cs.CardStatus_Type, 0 )) typ  --1-постоянный, 2-временный, 3-ассоциированный
                      FROM CardStatus cs (NOLOCK)
                     CROSS APPLY (SELECT MAX(dat) dat FROM #Period) p2 
                     WHERE cs.CardStatus_PersCard_Id = pc.PersCard_Id
                      AND DATEADD(dd, -1, DATEADD(mm, 1, p2.dat)) between ISNULL(cs.CardStatus_PerBeg, {d'1900-01-01'}) and ISNULL(cs.CardStatus_PerEnd, {d'2500-01-01'})
                    ) stat
    --Расчет налога и военного сбора
    UPDATE src
       SET src.tax_sm = dbo.fn_ClcTax(src.accr_inc_sm, @socBenefit_Sm, @socBenefit_LimSm, src.tax_koef, src.children),
           src.war_sm = dbo.fn_ClcMilitary(src.accr_inc_sm)
      FROM #UnionReportT2 src
      WHERE ISNULL(src.accr_inc_sm, 0) > 0 
    
    INSERT INTO dbo.UnionReportT2 (UnionReportT2_CtId, UnionReportT2_USREOU, UnionReportT2_Type, UnionReportT2_TIN, UnionReportT2_LName,
                                   UnionReportT2_FName, UnionReportT2_MName, UnionReportT2_AccrIncSm, UnionReportT2_PaidIncSm, 
                                   UnionReportT2_AccrTaxSm, UnionReportT2_TransfTaxSm, UnionReportT2_IncFlg, UnionReportT2_DOR, 
                                   UnionReportT2_DOD, UnionReportT2_SocBenefitFlg, UnionReportT2_AccrWarTaxSm, UnionReportT2_TransWarTaxSm)
    
    SELECT @inUnionReportT2_CtId           as UnionReportT2_CtId ,
           @USREOU                         as UnionReportT2_USREOU,
           0                               as UnionReportT2_Type,
           t2.TIN                          as UnionReportT2_TIN, 
           t2.last_name                    as UnionReportT2_LName,
           t2.first_name                   as UnionReportT2_FName, 
           t2.middle_name                  as UnionReportT2_MName,
           SUM(ISNULL(t2.accr_inc_sm, 0))  as UnionReportT2_AccrIncSm, 
           SUM(ISNULL(t2.accr_inc_sm, 0))  as UnionReportT2_PaidIncSm,
           SUM(ISNULL(t2.tax_sm, 0))       as UnionReportT2_AccrTaxSm, 
           SUM(ISNULL(t2.tax_sm, 0))       as UnionReportT2_TransfTaxSm, 
           t2.accr_flag                    as UnionReportT2_IncFlg, 
           t2.DOR                          as UnionReportT2_DOR,
           t2.DOD                          as UnionReportT2_DOD,
           t2.relief_flag                  as UnionReportT2_SocBenefitFlg, 
           SUM(ISNULL(t2.war_sm, 0))       as UnionReportT2_AccrWarTaxSm, 
           SUM(ISNULL(t2.war_sm, 0))       as UnionReportT2_TransWarTaxSm
      FROM #UnionReportT2 t2
      GROUP BY t2.TIN, t2.last_name, t2.first_name, t2.middle_name, t2.accr_flag, t2.DOR, t2.DOD, t2.relief_flag 
      HAVING SUM(ISNULL(t2.accr_inc_sm, 0)) > 0 or SUM(ISNULL(t2.tax_sm, 0)) > 0 or SUM(ISNULL(t2.war_sm, 0)) > 0
END   

