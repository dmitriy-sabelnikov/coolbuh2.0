/****** Script Date: 19.03.2018 9:00:22 ******/
/*�������� ������ �� ������� UnionReportT4*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUnionReportT4Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spUnionReportT4Delete];
GO
Create Procedure [dbo].[spUnionReportT4Delete]
	@inUnionReportT4_CtId      int = 0      --id ��������

AS                            
BEGIN
  SET NOCOUNT ON

  DELETE 
    FROM UnionReportT4
   WHERE UnionReportT4_CtId = @inUnionReportT4_CtId or @inUnionReportT4_CtId = 0;
END
