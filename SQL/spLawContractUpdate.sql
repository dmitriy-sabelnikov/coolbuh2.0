/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы LawContract*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spLawContractUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spLawContractUpdate];
GO
Create Procedure [dbo].[spLawContractUpdate]
    @inLawContract_Id             int,
    @inLawContract_PersCard_Id    int,
    @inLawContract_RefDep_Id      int,
    @inLawContract_Date           date,
    @inLawContract_Days           int,
    @inLawContract_Sm             numeric(10,2),
    @inLawContract_PayDate        date
AS                            
BEGIN
	UPDATE LawContract SET
           LawContract_PersCard_Id = @inLawContract_PersCard_Id,
           LawContract_RefDep_Id   = @inLawContract_RefDep_Id,
           LawContract_Date        = @inLawContract_Date,
           LawContract_Days        = @inLawContract_Days,
           LawContract_Sm          = @inLawContract_Sm,
           LawContract_PayDate     = @inLawContract_PayDate
    WHERE LawContract_Id = @inLawContract_Id;
END

