/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу USTCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUSTCtInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUSTCtInsert];
GO
Create Procedure [dbo].[spUSTCtInsert] 
    @inUSTCt_Date           date,
    @inUSTCt_Nmr            int,
    @inUSTCt_Nm             varchar(100),
    @inUSTCt_DateClc        dateTime,
    @inUSTCt_Flg            int,
    @outId                  int output
AS                            
BEGIN
    insert into USTCt (USTCt_Date, USTCt_Nmr, USTCt_Nm, USTCt_DateClc, USTCt_Flg) 
	      values (@inUSTCt_Date, @inUSTCt_Nmr, @inUSTCt_Nm, @inUSTCt_DateClc, @inUSTCt_Flg);
    select @outId=coalesce(IDENT_CURRENT ('USTCt'),0);
END