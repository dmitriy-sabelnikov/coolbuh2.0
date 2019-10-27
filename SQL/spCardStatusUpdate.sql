/****** Script Date: 19.03.2018 9:00:22 ******/
/*���������� ������� CardStatus*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCardStatusUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spCardStatusUpdate];
GO
Create Procedure [dbo].[spCardStatusUpdate]
    @inCardStatus_Id           int,   --id ��������
    @inCardStatus_PersCard_Id  int,   --������ �� �������� ���������
    @inCardStatus_PerBeg       Date,  --������ ������
    @inCardStatus_PerEnd       Date,  --������ �����
    @inCardStatus_Type         int    --��� �������
AS                            
BEGIN
	UPDATE CardStatus SET
	  CardStatus_PersCard_Id     = @inCardStatus_PersCard_Id,
	  CardStatus_PerBeg	        = @inCardStatus_PerBeg, 
	  CardStatus_PerEnd	        = @inCardStatus_PerEnd,   
	  CardStatus_Type	        = @inCardStatus_Type   
    WHERE CardStatus_Id = @inCardStatus_Id;
END
