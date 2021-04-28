/****** Script Date: 19.03.2018 9:00:22 ******/
/*���������� ������� Child*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spChildUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spChildUpdate];
GO
Create Procedure [dbo].[spChildUpdate]
    @inChild_Id           int,   --id ��������
    @inChild_PersCard_Id  int,   --������ �� �������� ���������
    @inChild_PerBeg       Date,  --������ ������
    @inChild_PerEnd       Date,  --������ �����
    @inChild_Count        int    --����������
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE Child SET
	  Child_PersCard_Id     = @inChild_PersCard_Id,
	  Child_PerBeg	        = @inChild_PerBeg, 
	  Child_PerEnd	        = @inChild_PerEnd,   
	  Child_Count	        = @inChild_Count   
    WHERE Child_Id = @inChild_Id;
END
