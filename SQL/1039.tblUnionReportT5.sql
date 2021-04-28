--/****** Object:  Table [dbo].[UnionReportT5]    Script Date: 19.03.2018 8:58:01 ******/
--������������ ����������. ������� 5
IF OBJECT_ID(N'[UnionReportT5]','U') IS NULL
CREATE TABLE [dbo].[UnionReportT5]
(
       UnionReportT5_Id                int IDENTITY(1,1)  NOT NULL,
       UnionReportT5_CtId              int                NOT NULL,  --������ �� ������� 
       UnionReportT5_Date              Date               NOT NULL,  --�������� ������
       UnionReportT5_ExportFile        int                        ,  --����� �����(1, 2, 3). ��� ��������
       UnionReportT5_ISUKR             int                        ,  --����������� �������(1 - ��) 
       UnionReportT5_TIN               nvarchar(12)               ,  --���
       UnionReportT5_LName             nvarchar(35)               ,  --�������
       UnionReportT5_FName             nvarchar(35)               ,  --���
       UnionReportT5_MName             nvarchar(35)               ,  --��������     
       UnionReportT5_Category_Cd       int                        ,  --��� ��������� ��������������� ���� 
       UnionReportT5_MaterialAidStart  int                        ,  --���� ������ ��������� ���������
       UnionReportT5_MaterialAidEnd    int                        ,  --���� ��������� ��������� ���������
       UnionReportT5_Accr_Cd           int                        ,  --��� ���� ����������
       UnionReportT5_Month             int                        ,  --�����, �� ������� ���������� ����������
       UnionReportT5_Year              int                        ,  --���, �� ������� ���������� ����������
       UnionReportT5_TotalSm           numeric(16,2)              ,  --����� ����� ����������� ���������/�����������/����������� ��, ������������� ����������������� (����� � ������ ��������� ������)
       UnionReportT5_MaxSm             numeric(16,2)              ,  --C���� ������������ ���������/�����������/����������� �� � �������� ����. ��������, �� ������� ����������� ���
       UnionReportT1_AccrUSTSm      numeric(16,2)                 ,  --C���� ������������ ������� ������
 CONSTRAINT [PK_UnionReportT5.UnionReportT5] PRIMARY KEY CLUSTERED 
 (
	[UnionReportT5_Id] ASC
 ),
  CONSTRAINT FK_UnionReportT5_CtId_UnionReportCt_Id FOREIGN KEY (UnionReportT5_CtId)     
    REFERENCES dbo.UnionReportCt (UnionReportCt_Id)

)


