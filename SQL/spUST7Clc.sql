--Персонификация
--Таблица 7 e04t07f
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUST7Clc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUST7Clc];
GO
Create Procedure [dbo].[spUST7Clc]
	@inUSTCt_Id  int 
AS                            
  Declare @date_ust datetime;
BEGIN
  SET NOCOUNT ON

  select @date_ust = USTCt_Date From USTCt (NOLOCK) where USTCt_Id = @inUSTCt_Id;

  insert into UST7 (UST7_USTCt_Id, UST7_ISUKR, UST7_TIN, UST7_LName, UST7_FName, UST7_MName, UST7_C_Pid, UST7_Start_Days, UST7_Stop_Days,  
                    UST7_Days, UST7_Hours, UST7_Minutes, UST7_Norm, UST7_Ord_Num, UST7_Ord_Dat, UST7_SSN)
  (
select
        @inUSTCt_Id                                                 UST7_USTCt_Id 
       ,1                                                           UST7_ISUKR        --Громадянство України (1 - так)
       ,PersCard.PersCard_TIN                                       UST7_TIN          --ИНН
       ,PersCard.PersCard_LName                                     UST7_LName        --Прізвище    
       ,PersCard.PersCard_FName                                     UST7_FName        --Ім'я
       ,PersCard.PersCard_MName                                     UST7_MName        --По батькові
       ,cardspec.C_PID                                              UST7_C_Pid        --Код підстави для обліку спецстажу
       ,1                                                           UST7_Start_Days   --Початок періоду
       ,DAY(dateadd(dd, -1, dateadd(mm, 1, @date_ust)))             UST7_Stop_Days    --Кінець періоду
       ,DAY(dateadd(dd, -1, dateadd(mm, 1, @date_ust)))             UST7_Days         --Кількість днів
       ,0                                                           UST7_Hours        --Кількість годин
       ,0                                                           UST7_Minutes      --Кількість хвилин
       ,DAY(dateadd(dd, -1, dateadd(mm, 1, @date_ust)))             UST7_Norm         --Норма тривалості роботи для її зарахування за повних місяць спецстажу
       ,''                                                          UST7_Ord_Num      --№ номер наказу про проведення атестації робочого місця
       ,0                                                           UST7_Ord_Dat      --Дата наказу про проведення атестації робочого місця
       ,0                                                           UST7_SSN          --Ознака сезон		      
   from PersCard (NOLOCK)
   inner join (select CardSpecExp_PersCard_Id, RefSpecExp.RefSpecExp_C_PID C_Pid, MAX(coalesce(RefSpecExp.RefSpecExp_Cd, 0)) Cd
                 From CardSpecExp (NOLOCK)
                inner join RefSpecExp (NOLOCK) on RefSpecExp.RefSpecExp_Id = CardSpecExp.CardSpecExp_RefSpecExp_Id
                where dateadd(dd, -1, dateadd(mm, 1, @date_ust)) between coalesce(CardSpecExp_PerBeg, {d'1900-01-01'}) and coalesce(CardSpecExp_PerEnd,{d'2500-01-01'})
                group by CardSpecExp_PersCard_Id, RefSpecExp_C_PID ) cardspec on cardspec.CardSpecExp_PersCard_Id = PersCard.PersCard_Id 
  where coalesce(cardspec.Cd, 0) > 0)
END;   
