--/****** Object:  Table [dbo].[DFCt]    Script Date: 19.03.2018 8:58:01 ******/
--1��. �������
IF OBJECT_ID(N'[DFCt]','U') IS NULL
CREATE TABLE [dbo].[DFCt]
(
	DFCt_Id             int IDENTITY(1,1)  NOT NULL,
	DFCt_Date           Date               NOT NULL,  --���� ���
	DFCt_Nmr            int                NOT NULL,  --�����
  DFCt_Nm             Varchar(100)	            ,  --������������
	DFCt_DateClc        DateTime	                ,  --���� �������
	DFCt_Flg            int	                       --�����
 CONSTRAINT [PK_DFCt.DFCt] PRIMARY KEY CLUSTERED 
 (
	[DFCt_Id] ASC
 )
)


