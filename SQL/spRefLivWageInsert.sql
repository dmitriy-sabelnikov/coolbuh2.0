/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу RefLivWage*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spRefLivWageInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spRefLivWageInsert];
GO
Create Procedure [dbo].[spRefLivWageInsert] 
    @inRefLivWage_PerBeg           date,
    @inRefLivWage_PerEnd           date,
    @inRefLivWage_Sm               numeric(16,2),
    @outId                         int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into RefLivWage (RefLivWage_PerBeg, RefLivWage_PerEnd, RefLivWage_Sm) 
	      values (@inRefLivWage_PerBeg, @inRefLivWage_PerEnd, @inRefLivWage_Sm);
    select @outId=coalesce(IDENT_CURRENT ('RefLivWage'),0);
END
