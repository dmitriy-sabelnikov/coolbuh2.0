/****** Script Date: 19.03.2018 9:00:22 ******/
/*���������� ������� Disability*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDisabilityUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spDisabilityUpdate];
GO
Create Procedure [dbo].[spDisabilityUpdate]
    @inDisability_Id           int,   --id ��������
    @inDisability_PersCard_Id  int,   --������ �� �������� ���������
    @inDisability_PerBeg       Date,  --������ ������
    @inDisability_PerEnd       Date,  --������ �����
    @inDisability_Attr         int    --�������
AS                            
BEGIN
	UPDATE Disability SET
	  Disability_PersCard_Id     = @inDisability_PersCard_Id,
	  Disability_PerBeg	        = @inDisability_PerBeg, 
	  Disability_PerEnd	        = @inDisability_PerEnd,   
	  Disability_Attr	        = @inDisability_Attr   
    WHERE Disability_Id = @inDisability_Id;
END
