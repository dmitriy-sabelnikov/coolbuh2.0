/****** Script Date: 27.04.2021 9:00:22 ******/
/*Обновление таблицы UnionReportCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportCtUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUnionReportCtUpdate];
GO
Create Procedure [dbo].[spUnionReportCtUpdate]
    @inUnionReportCt_Id             int,
    @inUnionReportCt_Year           int,
    @inUnionReportCt_Qrt            int,
    @inUnionReportCt_Nmr            int,
    @inUnionReportCt_Nm             varchar(100),
    @inUnionReportCt_DateClc        dateTime,
    @inUnionReportCt_Flg            int
AS                            
BEGIN
    SET NOCOUNT ON 

    UPDATE UnionReportCt SET
    UnionReportCt_Qrt             = @inUnionReportCt_Qrt,
    UnionReportCt_Year            = @inUnionReportCt_Year,
    UnionReportCt_Nmr             = @inUnionReportCt_Nmr,
    UnionReportCt_Nm              = @inUnionReportCt_Nm,
    UnionReportCt_DateClc         = @inUnionReportCt_DateClc,
    UnionReportCt_Flg             = @inUnionReportCt_Flg
    WHERE UnionReportCt_Id = @inUnionReportCt_Id;
END
