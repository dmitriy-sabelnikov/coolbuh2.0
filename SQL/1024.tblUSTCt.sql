--/****** Object:  Table [dbo].[USTCt]    Script Date: 19.03.2018 8:58:01 ******/
--���. �������
IF OBJECT_ID(N'[USTCt]','U') IS NULL
CREATE TABLE [dbo].[USTCt]
(
	USTCt_Id             int IDENTITY(1,1)  NOT NULL,
	USTCt_Date           Date               NOT NULL,  --���� ���
	USTCt_Nmr            int                NOT NULL,  --�����
        USTCt_Nm             Varchar(100)	        ,  --������������
	USTCt_DateClc        DateTime	                ,  --���� �������
	USTCt_Flg            int	                   --�����
 CONSTRAINT [PK_USTCt.USTCt] PRIMARY KEY CLUSTERED 
 (
	[USTCt_Id] ASC
 )
)


