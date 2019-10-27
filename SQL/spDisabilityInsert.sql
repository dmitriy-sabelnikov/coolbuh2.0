/****** Script Date: 19.03.2018 9:00:22 ******/
/*������� � ������� Disability*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDisabilityInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spDisabilityInsert];
GO
Create Procedure [dbo].[spDisabilityInsert] 
    @inDisability_PersCard_Id  int               ,  --������ �� �������� ���������
    @inDisability_PerBeg       Date	            ,  --������ ������
    @inDisability_PerEnd       Date              ,  --������ �����
    @inDisability_Attr         int	               --�������
AS                            
BEGIN
    insert into Disability (Disability_PersCard_Id, Disability_PerBeg, Disability_PerEnd, Disability_Attr) 
	 values (@inDisability_PersCard_Id, @inDisability_PerBeg, @inDisability_PerEnd, @inDisability_Attr);
END