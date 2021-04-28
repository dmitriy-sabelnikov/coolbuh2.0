--Объединенная отчетность. Расчет таблицы 4
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT4Clc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportT4Clc];
GO
Create Procedure [dbo].[spUnionReportT4Clc]
	@inUnionReportT4_CtId  int 
AS   
  DECLARE @quarter int,                         --квартал
          @year    int,                         --год
          @month   int,                         --месяц
          @date_begin DateTime                 --дата начала учетного периода
BEGIN
    SET NOCOUNT ON 

    SELECT @quarter = UnionReportCt_Qrt,
           @year    = UnionReportCt_Year
      FROM dbo.UnionReportCt (NOLOCK)
     WHERE UnionReportCt_Id = @inUnionReportT4_CtId
    
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
       [dat] datetime NOT NULL PRIMARY KEY,  
       [file_number]  int
    ) 
    INSERT INTO #Period (dat, file_number) VALUES (@date_begin, 1), (dateadd(mm, 1, @date_begin), 2), (dateadd(mm, 2, @date_begin), 3)
        
    INSERT INTO [dbo].[UnionReportT4] (UnionReportT4_CtId, UnionReportT4_Date, UnionReportT4_ExportFile, UnionReportT4_ISUKR, UnionReportT4_TIN, UnionReportT4_LName, UnionReportT4_FName,
                                       UnionReportT4_MName, UnionReportT4_C_Pid, UnionReportT4_Start_Days, UnionReportT4_Stop_Days, UnionReportT4_Days, UnionReportT4_Hours,
                                       UnionReportT4_Minutes, UnionReportT4_DaysNorm, UnionReportT4_HoursNorm, UnionReportT4_MinutesNorm, UnionReportT4_Ord_Num,
                                       UnionReportT4_Ord_Dat, UnionReportT4_SSN)


    SELECT @inUnionReportT4_CtId                       as UnionReportT4_CtId, 
           p.dat                                       as UnionReportT4_Date, 
           p.file_number                               as UnionReportT1_ExportFile,
           1                                           as UnionReportT4_ISUKR, 
           pc.PersCard_TIN                             as UnionReportT4_TIN, 
           pc.PersCard_LName                           as UnionReportT4_LName, 
           pc.PersCard_FName                           as UnionReportT4_FName,
           pc.PersCard_MName                           as UnionReportT4_MName, 
           cardspec.C_Pid                              as UnionReportT4_C_Pid, 
           1                                           as UnionReportT4_Start_Days, 
           DAY(dateadd(dd, -1, dateadd(mm, 1, p.dat))) as UnionReportT4_Stop_Days, 
           DAY(dateadd(dd, -1, dateadd(mm, 1, p.dat))) as UnionReportT4_Days, 
           0                                           as UnionReportT4_Hours,
           0                                           as UnionReportT4_Minutes, 
           DAY(dateadd(dd, -1, dateadd(mm, 1, p.dat))) as UnionReportT4_DaysNorm, 
           0                                           as UnionReportT4_HoursNorm, 
           0                                           as UnionReportT4_MinutesNorm, 
           null                                        as UnionReportT4_Ord_Num,
           null                                        as UnionReportT4_Ord_Dat, 
           0                                           as UnionReportT4_SSN
    FROM PersCard pc (NOLOCK)
    INNER JOIN #Period p ON 1=1
    CROSS APPLY(SELECT TOP 1 rse.RefSpecExp_C_PID C_Pid
                  FROM CardSpecExp cse (NOLOCK)
                 INNER JOIN RefSpecExp rse (NOLOCK) on rse.RefSpecExp_Id = cse.CardSpecExp_RefSpecExp_Id
                 WHERE cse.CardSpecExp_PersCard_Id = pc.PersCard_Id
                   AND DATEADD(dd, -1, DATEADD(mm, 1, p.dat)) between ISNULL(CardSpecExp_PerBeg, {d'1900-01-01'}) and ISNULL(CardSpecExp_PerEnd,{d'2500-01-01'})
                   AND rse.RefSpecExp_Cd > 0
                  ) cardspec
END   
