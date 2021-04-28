/****** Script Date: 27.04.2021 9:00:22 ******/
/*Вставка в таблицу UnionReportCt*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportCtInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUnionReportCtInsert];
GO
Create Procedure [dbo].[spUnionReportCtInsert] 
    @inUnionReportCt_Qrt            int,
    @inUnionReportCt_Year           int,
    @inUnionReportCt_Nmr            int,
    @inUnionReportCt_Nm             varchar(100),
    @inUnionReportCt_DateClc        dateTime,
    @inUnionReportCt_Flg            int,
    @outId                  int output
AS                            
BEGIN
    SET NOCOUNT ON 

    insert into UnionReportCt (UnionReportCt_Qrt, UnionReportCt_Year, UnionReportCt_Nmr, UnionReportCt_Nm, UnionReportCt_DateClc, UnionReportCt_Flg) 
	      values (@inUnionReportCt_Qrt, @inUnionReportCt_Year, @inUnionReportCt_Nmr, @inUnionReportCt_Nm, @inUnionReportCt_DateClc, @inUnionReportCt_Flg);
    select @outId=coalesce(IDENT_CURRENT ('UnionReportCt'),0);
END