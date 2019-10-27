--/****** Object:  Table [dbo].[DFRec]    Script Date: 19.03.2018 8:58:01 ******/
--1��. �������
IF OBJECT_ID(N'[DFRec]','U') IS NULL
CREATE TABLE [dbo].[DFRec]
(
	DFRec_Id             int IDENTITY(1,1)  NOT NULL,
	DFRec_DFCt_Id        int                NOT NULL,  --������ �� �������
	DFRec_USREOU         varchar(10)                ,  --��� ������   
	DFRec_Type           int                        ,  --���
	DFRec_FName          nvarchar(35)	              ,  --���
	DFRec_MName          nvarchar(35)               ,  --��������
	DFRec_LName          nvarchar(35)	              ,  --�������
	DFRec_TIN            nvarchar(12)	              ,  --���
	DFRec_AccrIncSm      numeric(16,2)              ,  --����� ������������ ������
	DFRec_PaidIncSm      numeric(16,2)              ,  --����� ������������ ������
	DFRec_AccrTaxSm      numeric(16,2)              ,  --����� ����������� ������, ������������
	DFRec_TransfTaxSm    numeric(16,2)              ,  --����� ����������� ������, ��������������
	DFRec_IncFlg         int                        ,  --������� ������
	DFRec_DOR            Date	                      ,  --���� �����������(date of receipt)
	DFRec_DOD            Date	                      ,  --���� ����������(date of dismissal)
	DFRec_SocBenefitFlg  int                        ,  --������� ���. ������
	DFRec_Flg            int                           --����
 CONSTRAINT [PK_DFRec.DFRec] PRIMARY KEY CLUSTERED 
 (
	[DFRec_Id] ASC
 ),
 CONSTRAINT FK_DFRec_DFRec_Id_DFRec_DFCt_Id FOREIGN KEY (DFRec_DFCt_Id)     
    REFERENCES dbo.DFCt (DFCt_Id)
)


