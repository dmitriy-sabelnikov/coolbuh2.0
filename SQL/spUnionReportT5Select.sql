/****** Script Date: 19.03.2018 9:00:22 ******/
/*������� �� ������� UnionReportT5*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT5Select]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spUnionReportT5Select];
GO
Create Procedure [dbo].[spUnionReportT5Select]
	@inUnionReportT5_CtId    int = 0           --id ��������
AS                            
BEGIN
    SET NOCOUNT ON

    SELECT *
      FROM UnionReportT5 (NOLOCK)
     WHERE (UnionReportT5_CtId = @inUnionReportT5_CtId or @inUnionReportT5_CtId = 0)
END
