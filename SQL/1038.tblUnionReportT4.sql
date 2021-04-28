--/****** Object:  Table [dbo].[UnionReportT4]    Script Date: 19.03.2018 8:58:01 ******/
--������������ ����������. ������� 4
IF OBJECT_ID(N'[UnionReportT4]','U') IS NULL
CREATE TABLE [dbo].[UnionReportT4]
(
        UnionReportT4_Id             int IDENTITY(1,1)  NOT NULL,
        UnionReportT4_CtId           int                NOT NULL,  --������ �� ������� 
        UnionReportT4_Date           Date               NOT NULL,  --�������� ������
	UnionReportT4_ExportFile     int                        ,  --����� �����(1, 2, 3). ��� ��������
        UnionReportT4_ISUKR          int                        ,  --����������� �������(1 - ��) 
        UnionReportT4_TIN            nvarchar(12)               ,  --���
        UnionReportT4_LName          nvarchar(35)               ,  --�������
        UnionReportT4_FName          nvarchar(35)               ,  --���
        UnionReportT4_MName          nvarchar(35)               ,  --��������     
        UnionReportT4_C_Pid          nvarchar(25)               ,  --��� �������� ��� ����� ���������
        UnionReportT4_Start_Days     int                        ,  --������ ������
        UnionReportT4_Stop_Days      int                        ,  --������ �����              
        UnionReportT4_Days           int                        ,  --���              
        UnionReportT4_Hours          int                        ,  --����              
        UnionReportT4_Minutes        int                        ,  --������                 
        UnionReportT4_DaysNorm       int                        ,  --����� ������������ ������ ��� �� ���������� �� ������ ����� ���������, ���, 
        UnionReportT4_HoursNorm      int                        ,  --����� ������������ ������ ��� �� ���������� �� ������ ����� ���������, ����
        UnionReportT4_MinutesNorm    int                        ,  --����� ������������ ������ ��� �� ���������� �� ������ ����� ���������, ������
        UnionReportT4_Ord_Num        nvarchar(8)                ,  --����� ������� � ���������� ���������� �������� �����
        UnionReportT4_Ord_Dat        int                        ,  --���� ������� � ���������� ���������� �������� �����
        UnionReportT4_SSN            int                           --������� ����������

 CONSTRAINT [PK_UnionReportT4.UnionReportT4] PRIMARY KEY CLUSTERED 
 (
	[UnionReportT4_Id] ASC
 ),
  CONSTRAINT FK_UnionReportT4_CtId_UnionReportCt_Id FOREIGN KEY (UnionReportT4_CtId)     
    REFERENCES dbo.UnionReportCt (UnionReportCt_Id)

)


