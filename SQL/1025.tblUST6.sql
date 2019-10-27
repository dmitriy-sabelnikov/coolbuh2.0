/****** Object:  Table [dbo].[UST6]    Script Date: 19.03.2018 8:58:01 ******/
--���. ������� 6
IF OBJECT_ID(N'[UST6]','U') IS NULL
CREATE TABLE [dbo].[UST6]
(
    UST6_Id                    int IDENTITY(1,1)  NOT NULL,
    UST6_USTCt_Id              int                NOT NULL,  --������ �� ������� ���
    UST6_ISUKR                 int                        ,  --����������� �������(1 - ��) 
    UST6_SEX                   int                        ,  --���(0-�, 1-�)                                    
    UST6_TIN                   nvarchar(12)               ,  --���
    UST6_LName                 nvarchar(35)               ,  --�������
    UST6_FName                 nvarchar(35)               ,  --���
    UST6_MName                 nvarchar(35)               ,  --��������     
    UST6_Category_Cd           int                        ,  --��� ��������� ��������������� ���� 
    UST6_Accr_Cd               int                        ,  --��� ���� ����������
    UST6_Month                 int                        ,  --�����, �� ������� ���������� ����������
    UST6_Year                  int                        ,  --���, �� ������� ���������� ����������
    UST6_DisabDays             int                        ,  --���������� ����������� ���� ��������� ������������������
    UST6_NoSalDays             int                        ,  --���������� ����������� ���� ��� ���������� ��������
    UST6_EmplDays              int                        ,  --���������� ���� ���������� � �������� ����������
    UST6_VocDays               int                        ,  --���������� ���� ����������� ���� ������� � ����� � ������������� � ������
    UST6_TotalSm               numeric(16,2)              ,  --����� ����� ����������� ��������/������ (����� � ������ ��������� ������)
    UST6_MaxSm                 numeric(16,2)              ,  --C���� ����������� ��������/������ � �������� ����. ��������, �� ������� ����������� �����
    UST6_DiffSm                numeric(16,2)              ,  --����� ������� ����� �������� ����������� �������� � ���������� ����������� ���������
    UST6_WithHeldUSTSm         numeric(16,2)              ,  --C���� ����������� ������� ������
    UST6_AccrUSTSm             numeric(16,2)              ,  --C���� ������������ ������� ������
    UST6_WB                    int                        ,  --������� ������� �������� ������(1 - ��, 0 - ���)
    UST6_SpecExp               int                        ,  --������� ������� ���������(1 - ��, 0 - ���)
    UST6_PWT                   int                        ,  --������� ��������� �������� �������(1 - ��, 0 - ���)
    UST6_NWP                   int                           --������� ������ �������� �����(1 - ��, 0 - ���)
 CONSTRAINT [PK_UST6.UST6] PRIMARY KEY CLUSTERED 
 (
	[UST6_Id] ASC
 ),
 CONSTRAINT FK_UST6_USTCt_Id_USTCt_USTCt_Id FOREIGN KEY (UST6_USTCt_Id)     
    REFERENCES dbo.USTCt (USTCt_Id)
)


