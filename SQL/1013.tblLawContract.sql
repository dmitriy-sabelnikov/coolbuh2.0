/****** Object:  Table [dbo].[LawContract]    Script Date: 19.03.2018 8:58:01 ******/
--�������� ���
IF OBJECT_ID(N'[LawContract]','U') IS NULL
begin
CREATE TABLE [dbo].[LawContract]
(
	LawContract_Id             int IDENTITY(1,1)      NOT NULL,
	LawContract_PersCard_Id    int                    NOT NULL,  --������ �� �������� ���������
	LawContract_RefDep_Id      int                    NOT NULL,  --������ �� ���������� �������������
	LawContract_Date           date                           ,  --����
	LawContract_Days           int 	                          ,  --���
	LawContract_Sm             numeric(10,2)                  ,  --�����
	LawContract_PayDate        date                              --����, �� ������� ���������� ����������
 CONSTRAINT [PK_LawContract.LawContract] PRIMARY KEY CLUSTERED 
 (
	[LawContract_Id] ASC
 ),
 CONSTRAINT FK_LawContract_RefDep_Id FOREIGN KEY (LawContract_RefDep_Id)     
    REFERENCES RefDep (RefDep_Id), 
 CONSTRAINT FK_LawContract_PersCard_Id FOREIGN KEY (LawContract_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)

create index ind_LawContract_1_1 on LawContract (LawContract_PersCard_Id);
create index ind_LawContract_1_2 on LawContract (LawContract_RefDep_Id);
create index ind_LawContract_1_3 on LawContract (LawContract_RefDep_Id,LawContract_Date);
end; 

