/****** Object:  Table [dbo].[PersCard]    Script Date: 19.03.2018 8:58:01 ******/
--������ ��������
IF OBJECT_ID(N'[PersCard]','U') IS NULL
CREATE TABLE [dbo].[PersCard]
(
    PersCard_Id           int IDENTITY(1,1)      NOT NULL,
    PersCard_FName        nvarchar(35)	             ,  --���
    PersCard_MName        nvarchar(35)               ,  --��������
    PersCard_LName        nvarchar(35)	             ,  --�������
    PersCard_TIN          nvarchar(12)	     NOT NULL,  --���
    PersCard_Exp          int 	                     ,  --����(excperience)
    PersCard_Grade        int 	                     ,  --����������
    PersCard_DOB          Date	                     ,  --���� ��������(date of birth)
    PersCard_DOR          Date	                     ,  --���� �����������(date of receipt)
    PersCard_DOD          Date	                     ,  --���� ����������(date of dismissal)
    PersCard_DOP          Date	                     ,  --���� ������ �� ������ (date of pens)
    PersCard_SEX          int 			     ,  --���(0-�, 1 - �)
 CONSTRAINT [PK_PersCard.PersCard] PRIMARY KEY CLUSTERED 
 (
	[PersCard_Id] ASC
 )
)


