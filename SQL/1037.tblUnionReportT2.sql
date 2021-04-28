--/****** Object:  Table [dbo].[UnionReportT2]    Script Date: 19.03.2018 8:58:01 ******/
--������������ ����������. ������� 2
IF OBJECT_ID(N'[UnionReportT2]','U') IS NULL
CREATE TABLE [dbo].[UnionReportT2]
(
        UnionReportT2_Id             int IDENTITY(1,1)  NOT NULL,
        UnionReportT2_CtId           int                NOT NULL,  --������ �� ������� 
        UnionReportT2_USREOU         varchar(10)                ,  --��� ������   
	UnionReportT2_Type           int                        ,  --���
        UnionReportT2_TIN            nvarchar(12)	        ,  --���
	UnionReportT2_LName          nvarchar(35)               ,  --�������
	UnionReportT2_FName          nvarchar(35)               ,  --���
	UnionReportT2_MName          nvarchar(35)               ,  --��������     
	UnionReportT2_AccrIncSm      numeric(16,2)              ,  --����� ������������ ������
	UnionReportT2_PaidIncSm      numeric(16,2)              ,  --����� ������������ ������
	UnionReportT2_AccrTaxSm      numeric(16,2)              ,  --����� ����������� ������, ������������
	UnionReportT2_TransfTaxSm    numeric(16,2)              ,  --����� ����������� ������, ��������������
	UnionReportT2_IncFlg         int                        ,  --������� ������
	UnionReportT2_DOR            Date	                ,  --���� �����������(date of receipt)
	UnionReportT2_DOD            Date	                ,  --���� ����������(date of dismissal)
	UnionReportT2_SocBenefitFlg  int                        ,  --������� ���. ������
	UnionReportT2_AccrWarTaxSm   numeric(16,2)              ,  --����� �������� �����, ������������
	UnionReportT2_TransWarTaxSm  numeric(16,2)              ,  --����� �������� �����, ��������������

 CONSTRAINT [PK_UnionReportT2.UnionReportT2] PRIMARY KEY CLUSTERED 
 (
	[UnionReportT2_Id] ASC
 ),
  CONSTRAINT FK_UnionReportT2_CtId_UnionReportCt_Id FOREIGN KEY (UnionReportT2_CtId)     
    REFERENCES dbo.UnionReportCt (UnionReportCt_Id)

)


