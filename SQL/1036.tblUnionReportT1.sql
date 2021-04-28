--/****** Object:  Table [dbo].[UnionReportT1]    Script Date: 19.03.2018 8:58:01 ******/
--������������ ����������. ������� 1
IF OBJECT_ID(N'[UnionReportT1]','U') IS NULL
CREATE TABLE [dbo].[UnionReportT1]
(
	UnionReportT1_Id             int IDENTITY(1,1)  NOT NULL,
	UnionReportT1_CtId           int                NOT NULL,  --������ �� ������� 
	UnionReportT1_Date           Date               NOT NULL,  --�������� ������
	UnionReportT1_ExportFile     int                        ,  --����� �����(1, 2, 3). ��� ��������
        UnionReportT1_ISUKR          int                        ,  --����������� �������(1 - ��) 
	UnionReportT1_SEX            int                        ,  --���(0-�, 1-�)                                    
	UnionReportT1_TIN            nvarchar(12)               ,  --���
	UnionReportT1_LName          nvarchar(35)               ,  --�������
	UnionReportT1_FName          nvarchar(35)               ,  --���
	UnionReportT1_MName          nvarchar(35)               ,  --��������     
	UnionReportT1_Category_Cd    int                        ,  --��� ��������� ��������������� ���� 
	UnionReportT1_Accr_Cd        int                        ,  --��� ���� ����������
	UnionReportT1_Month          int                        ,  --�����, �� ������� ���������� ����������
	UnionReportT1_Year           int                        ,  --���, �� ������� ���������� ����������
	UnionReportT1_DisabDays      int                        ,  --���������� ����������� ���� ��������� ������������������
	UnionReportT1_NoSalDays      int                        ,  --���������� ����������� ���� ��� ���������� ��������
	UnionReportT1_EmplDays       int                        ,  --���������� ���� ���������� � �������� ����������
	UnionReportT1_VocDays        int                        ,  --���������� ���� ����������� ���� ������� � ����� � ������������� � ������
	UnionReportT1_TotalSm        numeric(16,2)              ,  --����� ����� ����������� ��������/������ (����� � ������ ��������� ������)
	UnionReportT1_MaxSm          numeric(16,2)              ,  --C���� ����������� ��������/������ � �������� ����. ��������, �� ������� ����������� �����
	UnionReportT1_DiffSm         numeric(16,2)              ,  --����� ������� ����� �������� ����������� �������� � ���������� ����������� ���������
	UnionReportT1_WithHeldUSTSm  numeric(16,2)              ,  --C���� ����������� ������� ������
	UnionReportT1_AccrUSTSm      numeric(16,2)              ,  --C���� ������������ ������� ������
	UnionReportT1_WB             int                        ,  --������� ������� �������� ������(1 - ��, 0 - ���)
	UnionReportT1_SpecExp        int                        ,  --������� ������� ���������(1 - ��, 0 - ���)
	UnionReportT1_PWT            int                        ,  --������� ��������� �������� �������(1 - ��, 0 - ���)
	UnionReportT1_NWP            int                           --������� ������ �������� �����(1 - ��, 0 - ���)

 CONSTRAINT [PK_UnionReportT1.UnionReportT1] PRIMARY KEY CLUSTERED 
 (
	[UnionReportT1_Id] ASC
 ),
  CONSTRAINT FK_UnionReportT1_CtId_UnionReportCt_Id FOREIGN KEY (UnionReportT1_CtId)     
    REFERENCES dbo.UnionReportCt (UnionReportCt_Id)

)


