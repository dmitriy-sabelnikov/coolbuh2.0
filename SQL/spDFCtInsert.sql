/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу 1DfCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDfCtInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spDfCtInsert];
GO
Create Procedure [dbo].[spDfCtInsert] 
    @inDfCt_Date           date,
    @inDfCt_Nmr            int,
    @inDfCt_Nm             varchar(100),
    @inDfCt_DateClc        dateTime,
    @inDfCt_Flg            int,
    @outId                  int output
AS                            
BEGIN
    insert into DfCt (DfCt_Date, DfCt_Nmr, DfCt_Nm, DfCt_DateClc, DfCt_Flg) 
	      values (@inDfCt_Date, @inDfCt_Nmr, @inDfCt_Nm, @inDfCt_DateClc, @inDfCt_Flg);
    select @outId=coalesce(IDENT_CURRENT ('DfCt'),0);
END