--/****** Object:  Table [dbo].[UnionReportCt]    Script Date: 19.03.2018 8:58:01 ******/
--������������ ����������. �������
IF OBJECT_ID(N'[UnionReportCt]','U') IS NULL
CREATE TABLE [dbo].[UnionReportCt]
(
	UnionReportCt_Id             int IDENTITY(1,1)  NOT NULL,
	UnionReportCt_Qrt            int                NOT NULL,  --�������
	UnionReportCt_Year           int                NOT NULL,  --���
	UnionReportCt_Nmr            int                NOT NULL,  --�����
	UnionReportCt_Nm             Varchar(100)	        ,  --������������
	UnionReportCt_DateClc        DateTime	                ,  --���� �������
	UnionReportCt_Flg            int	                   --�����
 CONSTRAINT [PK_UnionReportCt.UnionReportCt] PRIMARY KEY CLUSTERED 
 (
	[UnionReportCt_Id] ASC
 )
)


