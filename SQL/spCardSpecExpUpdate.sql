/****** Script Date: 19.03.2018 9:00:22 ******/
/*���������� ������� CardSpecExp*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCardSpecExpUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spCardSpecExpUpdate];
GO
Create Procedure [dbo].[spCardSpecExpUpdate]
    @inCardSpecExp_Id              int,   --id ��������
    @inCardSpecExp_PersCard_Id     int,   --������ �� �������� ���������
    @inCardSpecExp_PerBeg          Date,  --������ ������
    @inCardSpecExp_PerEnd          Date,  --������ �����
    @inCardSpecExp_RefSpecExp_Id   int	  -- ������ �� ���������� ����������
AS                            
BEGIN
	UPDATE CardSpecExp SET
	  CardSpecExp_PersCard_Id       = @inCardSpecExp_PersCard_Id,
	  CardSpecExp_PerBeg	        = @inCardSpecExp_PerBeg, 
	  CardSpecExp_PerEnd	        = @inCardSpecExp_PerEnd,   
	  CardSpecExp_RefSpecExp_Id	    = @inCardSpecExp_RefSpecExp_Id   
    WHERE CardSpecExp_Id = @inCardSpecExp_Id;
END
