/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы 1DfCt*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDfCtUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spDfCtUpdate];
GO
Create Procedure [dbo].[spDfCtUpdate]
	@inDfCt_Id             int,
    @inDfCt_Date           date,
    @inDfCt_Nmr            int,
    @inDfCt_Nm             varchar(100),
    @inDfCt_DateClc        dateTime,
    @inDfCt_Flg            int
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE DfCt SET
    DfCt_Date            = @inDfCt_Date,
    DfCt_Nmr             = @inDfCt_Nmr,
    DfCt_Nm              = @inDfCt_Nm,
    DfCt_DateClc         = @inDfCt_DateClc,
    DfCt_Flg             = @inDfCt_Flg
    WHERE DfCt_Id = @inDfCt_Id;
END
