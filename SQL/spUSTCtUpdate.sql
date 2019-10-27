/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы USTCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUSTCtUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUSTCtUpdate];
GO
Create Procedure [dbo].[spUSTCtUpdate]
	@inUSTCt_Id             int,
    @inUSTCt_Date           date,
    @inUSTCt_Nmr            int,
    @inUSTCt_Nm             varchar(100),
    @inUSTCt_DateClc        dateTime,
    @inUSTCt_Flg            int
AS                            
BEGIN
	UPDATE USTCt SET
    USTCt_Date            = @inUSTCt_Date,
    USTCt_Nmr             = @inUSTCt_Nmr,
    USTCt_Nm              = @inUSTCt_Nm,
    USTCt_DateClc         = @inUSTCt_DateClc,
    USTCt_Flg             = @inUSTCt_Flg
    WHERE USTCt_Id = @inUSTCt_Id;
END
