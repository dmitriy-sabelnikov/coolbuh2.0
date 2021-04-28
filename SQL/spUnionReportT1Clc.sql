/****** Script Date: 27.04.2021 9:00:22 ******/
--Объединенная отчетность. Расчет таблицы 1
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT1Clc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportT1Clc];
GO
Create Procedure [dbo].[spUnionReportT1Clc]
	@inUnionReportT1_CtId  int 
AS   
  DECLARE @quarter int,
          @year    int,
          @month   int,
          @date_begin DateTime;                         
BEGIN
    SET NOCOUNT ON 
 	
    SELECT @quarter = UnionReportCt_Qrt,
           @year    = UnionReportCt_Year
      FROM dbo.UnionReportCt (NOLOCK)
     WHERE UnionReportCt_Id = @inUnionReportT1_CtId
    
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
       [dat]          datetime NOT NULL  PRIMARY KEY,
       [file_number]  int
    ) 

    INSERT INTO #Period (dat, file_number) VALUES (@date_begin, 1), (dateadd(mm, 1, @date_begin), 2), (dateadd(mm, 2, @date_begin), 3)

    INSERT INTO [dbo].[UnionReportT1] (UnionReportT1_CtId, UnionReportT1_Date, UnionReportT1_ExportFile, UnionReportT1_ISUKR, UnionReportT1_SEX, UnionReportT1_TIN,
                                       UnionReportT1_LName, UnionReportT1_FName, UnionReportT1_MName, UnionReportT1_Category_Cd, UnionReportT1_Accr_Cd,
    								   UnionReportT1_Month, UnionReportT1_Year, UnionReportT1_DisabDays, UnionReportT1_NoSalDays, UnionReportT1_EmplDays,
    								   UnionReportT1_VocDays, UnionReportT1_TotalSm, UnionReportT1_MaxSm, UnionReportT1_DiffSm, UnionReportT1_WithHeldUSTSm,
    								   UnionReportT1_AccrUSTSm, UnionReportT1_WB, UnionReportT1_SpecExp, UnionReportT1_PWT, UnionReportT1_NWP)
    SELECT @inUnionReportT1_CtId                           as UnionReportT1_CtId,
           p.dat                                           as UnionReportT1_Date,                  --Отчетный период
    	   p.file_number                                   as UnionReportT1_ExportFile,            --Номер файла(1, 2, 3). Для экспорта 
           1                                               as UnionReportT1_ISUKR,				   --Гражданство Украины(1 - да) 
    	   pc.PersCard_SEX                                 as UnionReportT1_SEX,				   --Пол(0-Ж, 1-М)                                    
    	   pc.PersCard_TIN                                 as UnionReportT1_TIN,				   --ИНН
    	   pc.PersCard_LName                               as UnionReportT1_LName,				   --Фамилия
    	   pc.PersCard_FName                               as UnionReportT1_FName,				   --Имя
    	   pc.PersCard_MName                               as UnionReportT1_MName,				   --Отчество     
    	   IIF(ISNULL(disab.attr, 0) < 1, 1, disab.attr)   as UnionReportT1_Category_Cd,		   --Код категории застрахованного лица 
    	   0                                               as UnionReportT1_Accr_Cd,			   --Код типа начислений
           MONTH(p.dat)                                    as UnionReportT1_Month, 				   --Месяц, за который проводится начисление
    	   YEAR(p.dat)                                     as UnionReportT1_Year,				   --Год, за который проводится начисление
    	   0                                               as UnionReportT1_DisabDays, 			   --Количество календарных дней временной нетрудоспособности
    	   0                                               as UnionReportT1_NoSalDays,			   --Количество календарных дней без сохранения зарплаты
    	   DAY(dateadd(dd, -1, dateadd(mm, 1, p.dat)))     as UnionReportT1_EmplDays,			   --Количество дней пребывания в трудовых отношениях
    	   0                                               as UnionReportT1_VocDays,			   --Количество дней календарных дней отпуска в связи с беремменостью и родами
    	   ISNULL(sal.sm, 0) + ISNULL(addAccrClc.sm, 0)    as UnionReportT1_TotalSm,			   --Общая сумма начисленной зарплаты/дохода (всего с начала отчетного месяца)
    	   ISNULL(sal.sm, 0) + ISNULL(addAccrClc.sm, 0)    as UnionReportT1_MaxSm,				   --Cумма начиселнной зарплаты/дохода в границах макс. величины, на которую начисляется взнос
    	   0                                               as UnionReportT1_DiffSm,				   --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
    	   0                                               as UnionReportT1_WithHeldUSTSm,		   --Cумма удержанного единого взноса
    	   0                                               as UnionReportT1_AccrUSTSm,			   --Cумма начисленного единого взноса
    	   IIF(ISNULL(cardstat.typ, 0) = 2, 0, 1)          as UnionReportT1_WB,					   --Признак наличия трудовой книжки(1 - да, 0 - нет)
    	   IIF(ISNULL(cardspec.cd,0) > 0, 1, 0)            as UnionReportT1_SpecExp,			   --Признак наличия спецстажа(1 - да, 0 - нет)
    	   0                                               as UnionReportT1_PWT,				   --Признак неполного рабочего времени(1 - да, 0 - нет)
    	   0                                               as UnionReportT1_NWP					   --Признак нового рабочего места(1 - да, 0 - нет)
      FROM PersCard pc (NOLOCK)
      INNER JOIN #Period p ON 1 = 1
      OUTER APPLY (SELECT SUM(ISNULL(Salary_ResSm, 0)) sm
                     FROM Salary s (NOLOCK)
                    WHERE s.Salary_PersCard_Id = pc.PersCard_Id
    				  AND s.Salary_date = p.dat
                  ) sal 
      OUTER APPLY (SELECT Sum(ISNULL(ac.AddAccr_Sm, 0)) sm 
                     from AddAccr ac (NOLOCK)
                    INNER JOIN RefTypeAddAccr tac on tac.RefTypeAddAccr_Id = ac.AddAccr_RefTypeAddAccr_Id
                     where ac.AddAccr_PersCard_Id = pc.PersCard_Id  
                       AND ac.AddAccr_Date  = p.dat
    				   AND (tac.RefTypeAddAccr_Flg & 1) > 0
                   ) addAccrClc 
      OUTER APPLY (SELECT MAX(ISNULL(d.Disability_Attr, 0)) attr
                     From Disability d (NOLOCK)
                    WHERE d.Disability_PersCard_Id = pc.PersCard_Id
    				  AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(Disability_PerBeg, {d'1900-01-01'}) and coalesce(Disability_PerEnd,{d'2500-01-01'})
    			   ) disab 
      OUTER APPLY (SELECT MAX(ISNULL(CardStatus_Type, 0)) typ
                     FROM CardStatus cs (NOLOCK)
                    WHERE cs.CardStatus_PersCard_Id = pc.PersCard_Id  
    			      AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd,{d'2500-01-01'})
                   ) cardstat  
      OUTER APPLY (SELECT MAX(ISNULL(rse.RefSpecExp_Cd, 0)) cd
                    FROM CardSpecExp cse (NOLOCK)
                   INNER JOIN RefSpecExp rse (NOLOCK) on rse.RefSpecExp_Id = cse.CardSpecExp_RefSpecExp_Id
                   WHERE cse.CardSpecExp_PersCard_Id = pc.PersCard_Id 
                     AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(cse.CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(cse.CardSpecExp_PerEnd,{d'2500-01-01'})
                  ) cardspec 
      WHERE (ISNULL(sal.sm, 0) + ISNULL(addAccrClc.sm, 0)) <> 0
    UNION ALL
/*==============================================================================================*/
/*                                      Отпускные                                               */
/*==============================================================================================*/
    SELECT @inUnionReportT1_CtId                           as UnionReportT1_CtId,
           p.dat                                           as UnionReportT1_Date,                  --Отчетный период
    	   p.file_number                                   as UnionReportT1_ExportFile,            --Номер файла(1, 2, 3). Для экспорта 
    	   1                                               as UnionReportT1_ISUKR,				   --Гражданство Украины(1 - да) 
    	   pc.PersCard_SEX                                 as UnionReportT1_SEX,				   --Пол(0-Ж, 1-М)                                    
    	   pc.PersCard_TIN                                 as UnionReportT1_TIN,				   --ИНН
    	   pc.PersCard_LName                               as UnionReportT1_LName,				   --Фамилия
    	   pc.PersCard_FName                               as UnionReportT1_FName,				   --Имя
    	   pc.PersCard_MName                               as UnionReportT1_MName,				   --Отчество     
    	   IIF(ISNULL(disab.attr, 0) < 1, 1, disab.attr)   as UnionReportT1_Category_Cd,		   --Код категории застрахованного лица 
    	   10                                              as UnionReportT1_Accr_Cd,			   --Код типа начислений
           MONTH(v.Vocation_PayDate)                       as UnionReportT1_Month, 				   --Месяц, за который проводится начисление
    	   YEAR(v.Vocation_PayDate)                        as UnionReportT1_Year,				   --Год, за который проводится начисление
    	   0                                               as UnionReportT1_DisabDays, 			   --Количество календарных дней временной нетрудоспособности
    	   0                                               as UnionReportT1_NoSalDays,			   --Количество календарных дней без сохранения зарплаты
    	   0                                               as UnionReportT1_EmplDays,			   --Количество дней пребывания в трудовых отношениях
    	   0                                               as UnionReportT1_VocDays,			   --Количество дней календарных дней отпуска в связи с беремменостью и родами
    	   v.Vocation_Sm                                   as UnionReportT1_TotalSm,			   --Общая сумма начисленной зарплаты/дохода (всего с начала отчетного месяца)
    	   v.Vocation_Sm                                   as UnionReportT1_MaxSm,				   --Cумма начиселнной зарплаты/дохода в границах макс. величины, на которую начисляется взнос
    	   0                                               as UnionReportT1_DiffSm,				   --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
    	   0                                               as UnionReportT1_WithHeldUSTSm,		   --Cумма удержанного единого взноса
    	   0                                               as UnionReportT1_AccrUSTSm,			   --Cумма начисленного единого взноса
    	   IIF(ISNULL(cardstat.typ, 0) = 2, 0, 1)          as UnionReportT1_WB,					   --Признак наличия трудовой книжки(1 - да, 0 - нет)
    	   IIF(ISNULL(cardspec.cd,0) > 0, 1, 0)            as UnionReportT1_SpecExp,			   --Признак наличия спецстажа(1 - да, 0 - нет)
    	   0                                               as UnionReportT1_PWT,				   --Признак неполного рабочего времени(1 - да, 0 - нет)
    	   0                                               as UnionReportT1_NWP					   --Признак нового рабочего места(1 - да, 0 - нет)
      FROM PersCard pc (NOLOCK)
      INNER JOIN #Period p ON 1 = 1
	  INNER JOIN Vocation v (NOLOCK) on v.Vocation_PersCard_Id = pc.PersCard_Id and v.Vocation_Date = p.dat 
      OUTER APPLY (SELECT MAX(ISNULL(d.Disability_Attr, 0)) attr
                     From Disability d (NOLOCK)
                    WHERE d.Disability_PersCard_Id = pc.PersCard_Id
    				  AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(Disability_PerBeg, {d'1900-01-01'}) and coalesce(Disability_PerEnd,{d'2500-01-01'})
    			   ) disab 
      OUTER APPLY (SELECT MAX(ISNULL(CardStatus_Type, 0)) typ
                     FROM CardStatus cs (NOLOCK)
                    WHERE cs.CardStatus_PersCard_Id = pc.PersCard_Id  
    			      AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd,{d'2500-01-01'})
                   ) cardstat  
      OUTER APPLY (SELECT MAX(ISNULL(rse.RefSpecExp_Cd, 0)) cd
                    FROM CardSpecExp cse (NOLOCK)
                   INNER JOIN RefSpecExp rse (NOLOCK) on rse.RefSpecExp_Id = cse.CardSpecExp_RefSpecExp_Id
                   WHERE cse.CardSpecExp_PersCard_Id = pc.PersCard_Id 
                     AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(cse.CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(cse.CardSpecExp_PerEnd,{d'2500-01-01'})
                  ) cardspec 
      WHERE ISNULL(v.Vocation_Sm, 0) <> 0
    UNION ALL
/*==============================================================================================*/
/*                                      Договора ГПХ                                            */
/*==============================================================================================*/
    SELECT @inUnionReportT1_CtId                           as UnionReportT1_CtId,
           p.dat                                           as UnionReportT1_Date,                  --Отчетный период
    	   p.file_number                                   as UnionReportT1_ExportFile,            --Номер файла(1, 2, 3). Для экспорта 
    	   1                                               as UnionReportT1_ISUKR,				   --Гражданство Украины(1 - да) 
    	   pc.PersCard_SEX                                 as UnionReportT1_SEX,				   --Пол(0-Ж, 1-М)                                    
    	   pc.PersCard_TIN                                 as UnionReportT1_TIN,				   --ИНН
    	   pc.PersCard_LName                               as UnionReportT1_LName,				   --Фамилия
    	   pc.PersCard_FName                               as UnionReportT1_FName,				   --Имя
    	   pc.PersCard_MName                               as UnionReportT1_MName,				   --Отчество     
    	   26                                              as UnionReportT1_Category_Cd,		   --Код категории застрахованного лица 
    	   0                                               as UnionReportT1_Accr_Cd,			   --Код типа начислений
           MONTH(lc.LawContract_PayDate)                   as UnionReportT1_Month, 				   --Месяц, за который проводится начисление
    	   YEAR(lc.LawContract_PayDate)                    as UnionReportT1_Year,				   --Год, за который проводится начисление
    	   0                                               as UnionReportT1_DisabDays, 			   --Количество календарных дней временной нетрудоспособности
    	   0                                               as UnionReportT1_NoSalDays,			   --Количество календарных дней без сохранения зарплаты
    	   DAY(dateadd(dd, -1, dateadd(mm, 1, p.dat)))     as UnionReportT1_EmplDays,			   --Количество дней пребывания в трудовых отношениях
    	   0                                               as UnionReportT1_VocDays,			   --Количество дней календарных дней отпуска в связи с беремменостью и родами
    	   lc.LawContract_Sm                               as UnionReportT1_TotalSm,			   --Общая сумма начисленной зарплаты/дохода (всего с начала отчетного месяца)
    	   lc.LawContract_Sm                               as UnionReportT1_MaxSm,				   --Cумма начиселнной зарплаты/дохода в границах макс. величины, на которую начисляется взнос
    	   0                                               as UnionReportT1_DiffSm,				   --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
    	   round((lc.LawContract_Sm * 0.026), 2)           as UnionReportT1_WithHeldUSTSm,		   --Cумма удержанного единого взноса
    	   0                                               as UnionReportT1_AccrUSTSm,			   --Cумма начисленного единого взноса
    	   IIF(ISNULL(cardstat.typ, 0) = 2, 0, 1)          as UnionReportT1_WB,					   --Признак наличия трудовой книжки(1 - да, 0 - нет)
    	   IIF(ISNULL(cardspec.cd,0) > 0, 1, 0)            as UnionReportT1_SpecExp,			   --Признак наличия спецстажа(1 - да, 0 - нет)
    	   0                                               as UnionReportT1_PWT,				   --Признак неполного рабочего времени(1 - да, 0 - нет)
    	   0                                               as UnionReportT1_NWP					   --Признак нового рабочего места(1 - да, 0 - нет)
      FROM PersCard pc (NOLOCK)
      INNER JOIN #Period p ON 1 = 1
	  INNER JOIN LawContract lc (NOLOCK) on lc.LawContract_PersCard_Id = pc.PersCard_Id and lc.LawContract_Date = p.dat 
      OUTER APPLY (SELECT MAX(ISNULL(CardStatus_Type, 0)) typ
                     FROM CardStatus cs (NOLOCK)
                    WHERE cs.CardStatus_PersCard_Id = pc.PersCard_Id  
    			      AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd,{d'2500-01-01'})
                   ) cardstat  
      OUTER APPLY (SELECT MAX(ISNULL(rse.RefSpecExp_Cd, 0)) cd
                    FROM CardSpecExp cse (NOLOCK)
                   INNER JOIN RefSpecExp rse (NOLOCK) on rse.RefSpecExp_Id = cse.CardSpecExp_RefSpecExp_Id
                   WHERE cse.CardSpecExp_PersCard_Id = pc.PersCard_Id 
                     AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(cse.CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(cse.CardSpecExp_PerEnd,{d'2500-01-01'})
                  ) cardspec 
      WHERE ISNULL(lc.LawContract_Sm, 0) <> 0
    UNION ALL
/*==============================================================================================*/
/*                                      Больничные                                              */
/*==============================================================================================*/
    SELECT @inUnionReportT1_CtId                           as UnionReportT1_CtId,
           p.dat                                           as UnionReportT1_Date,                  --Отчетный период
    	   p.file_number                                   as UnionReportT1_ExportFile,            --Номер файла(1, 2, 3). Для экспорта 
    	   1                                               as UnionReportT1_ISUKR,				   --Гражданство Украины(1 - да) 
    	   pc.PersCard_SEX                                 as UnionReportT1_SEX,				   --Пол(0-Ж, 1-М)                                    
    	   pc.PersCard_TIN                                 as UnionReportT1_TIN,				   --ИНН
    	   pc.PersCard_LName                               as UnionReportT1_LName,				   --Фамилия
    	   pc.PersCard_FName                               as UnionReportT1_FName,				   --Имя
    	   pc.PersCard_MName                               as UnionReportT1_MName,				   --Отчество     
    	   29                                              as UnionReportT1_Category_Cd,		   --Код категории застрахованного лица 
    	   0                                               as UnionReportT1_Accr_Cd,			   --Код типа начислений
           MONTH(sl.SickList_PayDate)                      as UnionReportT1_Month, 				   --Месяц, за который проводится начисление
    	   YEAR(sl.SickList_PayDate)                       as UnionReportT1_Year,				   --Год, за который проводится начисление
    	   ISNULL(sl.SickList_DaysSocInsrnc, 0) + ISNULL(sl.SickList_DaysEntprs, 0) as UnionReportT1_DisabDays, --Количество календарных дней временной нетрудоспособности
    	   0                                               as UnionReportT1_NoSalDays,			   --Количество календарных дней без сохранения зарплаты
    	   DAY(dateadd(dd, -1, dateadd(mm, 1, p.dat)))     as UnionReportT1_EmplDays,			   --Количество дней пребывания в трудовых отношениях
    	   0                                               as UnionReportT1_VocDays,			   --Количество дней календарных дней отпуска в связи с беремменостью и родами
    	   sl.SickList_ResSm                               as UnionReportT1_TotalSm,			   --Общая сумма начисленной зарплаты/дохода (всего с начала отчетного месяца)
    	   sl.SickList_ResSm                               as UnionReportT1_MaxSm,				   --Cумма начиселнной зарплаты/дохода в границах макс. величины, на которую начисляется взнос
    	   0                                               as UnionReportT1_DiffSm,				   --Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
    	   round((sl.SickList_ResSm * 0.02), 2)            as UnionReportT1_WithHeldUSTSm,		   --Cумма удержанного единого взноса
    	   0                                               as UnionReportT1_AccrUSTSm,			   --Cумма начисленного единого взноса
    	   IIF(ISNULL(cardstat.typ, 0) = 2, 0, 1)          as UnionReportT1_WB,					   --Признак наличия трудовой книжки(1 - да, 0 - нет)
    	   IIF(ISNULL(cardspec.cd,0) > 0, 1, 0)            as UnionReportT1_SpecExp,			   --Признак наличия спецстажа(1 - да, 0 - нет)
    	   0                                               as UnionReportT1_PWT,				   --Признак неполного рабочего времени(1 - да, 0 - нет)
    	   0                                               as UnionReportT1_NWP					   --Признак нового рабочего места(1 - да, 0 - нет)
      FROM PersCard pc (NOLOCK)
      INNER JOIN #Period p ON 1 = 1
	  INNER JOIN SickList sl (NOLOCK) on sl.SickList_PersCard_Id = pc.PersCard_Id and sl.SickList_Date = p.dat 
      OUTER APPLY (SELECT MAX(ISNULL(CardStatus_Type, 0)) typ
                     FROM CardStatus cs (NOLOCK)
                    WHERE cs.CardStatus_PersCard_Id = pc.PersCard_Id  
    			      AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(CardStatus_PerBeg, {d'1900-01-01'}) and coalesce(CardStatus_PerEnd,{d'2500-01-01'})
                   ) cardstat  
      OUTER APPLY (SELECT MAX(ISNULL(rse.RefSpecExp_Cd, 0)) cd
                    FROM CardSpecExp cse (NOLOCK)
                   INNER JOIN RefSpecExp rse (NOLOCK) on rse.RefSpecExp_Id = cse.CardSpecExp_RefSpecExp_Id
                   WHERE cse.CardSpecExp_PersCard_Id = pc.PersCard_Id 
                     AND dateadd(dd, -1, dateadd(mm, 1, p.dat)) between coalesce(cse.CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(cse.CardSpecExp_PerEnd,{d'2500-01-01'})
                  ) cardspec 
      WHERE ISNULL(sl.SickList_ResSm, 0) <> 0
END   