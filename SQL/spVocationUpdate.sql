/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы Vocation*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spVocationUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spVocationUpdate];
GO
Create Procedure [dbo].[spVocationUpdate]
	@inVocation_Id              int,           --id   
	@inVocation_PersCard_Id     int,
	@inVocation_RefDep_Id       int,
	@inVocation_Date            date,
	@inVocation_Days            int,
	@inVocation_Sm              numeric(10, 2),
        @inVocation_PayDate         date
AS                            
BEGIN
    SET NOCOUNT ON

	UPDATE Vocation SET
	    Vocation_PersCard_Id  = @inVocation_PersCard_Id,
	    Vocation_RefDep_Id    = @inVocation_RefDep_Id,
	    Vocation_Date         = @inVocation_Date,
	    Vocation_Days         = @inVocation_Days,
	    Vocation_Sm           = @inVocation_Sm,
            Vocation_PayDate      = @inVocation_PayDate
    WHERE Vocation_Id = @inVocation_Id;
END
