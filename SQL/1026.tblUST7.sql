/****** Object:  Table [dbo].[UST7]    Script Date: 19.03.2018 8:58:01 ******/
--���. ������� 7
IF OBJECT_ID(N'[UST7]','U') IS NULL
CREATE TABLE [dbo].[UST7]
(
    UST7_Id                    int IDENTITY(1,1)  NOT NULL,
    UST7_USTCt_Id              int                NOT NULL,  --������ �� ������� ���
    UST7_ISUKR                 int                        ,  --����������� �������(1 - ��) 
    UST7_TIN                   nvarchar(12)               ,  --���
    UST7_LName                 nvarchar(35)               ,  --�������
    UST7_FName                 nvarchar(35)               ,  --���
    UST7_MName                 nvarchar(35)               ,  --��������     
    UST7_C_Pid                 nvarchar(25)               ,  --��� �������� ��� ����� ���������
    UST7_Start_Days            int                        ,  --������ ������
    UST7_Stop_Days             int                        ,  --������ �����              
    UST7_Days                  int                        ,  --���              
    UST7_Hours                 int                        ,  --����              
    UST7_Minutes               int                        ,  --������                 
    UST7_Norm                  int                        ,  --����� ������������ ������ ��� �� ���������� �� ������ ����� ���������
    UST7_Ord_Num               nvarchar(8)                ,  --����� ������� � ���������� ���������� �������� �����
    UST7_Ord_Dat               int                        ,  --���� ������� � ���������� ���������� �������� �����
    UST7_SSN                   int                           --������� ����������
 CONSTRAINT [PK_UST7.UST7] PRIMARY KEY CLUSTERED 
 (
	[UST7_Id] ASC
 ),
 CONSTRAINT FK_UST7_USTCt_Id_USTCt_USTCt_Id FOREIGN KEY (UST7_USTCt_Id)     
    REFERENCES dbo.USTCt (USTCt_Id)
)


