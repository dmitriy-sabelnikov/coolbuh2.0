/****** Script Date: 19.03.2018 9:00:22 ******/
/*���������� ������� PersCard*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPersCardUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spPersCardUpdate];
GO
Create Procedure [dbo].[spPersCardUpdate]
	@inPersCard_Id           int,                --id ��������
	@inPersCard_FName        nvarchar(35),       --���  
	@inPersCard_MName        nvarchar(35),       --��������
	@inPersCard_LName        nvarchar(35),       --�������
	@inPersCard_TIN          nvarchar(12),       --���
	@inPersCard_Exp          int,                --����(excperience)
	@inPersCard_Grade        int,                --����������
	@inPersCard_DOB          Date,               --���� ��������(date of birth)
	@inPersCard_DOR          Date,               --���� �����������(date of receipt)
	@inPersCard_DOD          Date,               --���� ����������(date of dismissal)
	@inPersCard_DOP          Date,               --���� ������ �� ������(date of pens)
        @inPersCard_SEX          int                 --���
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE PersCard SET
	  PersCard_FName	        = @inPersCard_FName, 
	  PersCard_MName	        = @inPersCard_MName,   
	  PersCard_LName	        = @inPersCard_LName,   
	  PersCard_TIN		        = @inPersCard_TIN,     
	  PersCard_Exp		        = @inPersCard_Exp,     
	  PersCard_Grade	        = @inPersCard_Grade,   
	  PersCard_DOB		        = @inPersCard_DOB,     
	  PersCard_DOR		        = @inPersCard_DOR,     
	  PersCard_DOD		        = @inPersCard_DOD,
	  PersCard_DOP		        = @inPersCard_DOP,
          PersCard_SEX                  = @inPersCard_SEX
    WHERE PersCard_Id = @inPersCard_Id;
END
