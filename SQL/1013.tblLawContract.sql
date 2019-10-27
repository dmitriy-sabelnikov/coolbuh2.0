/****** Object:  Table [dbo].[LawContract]    Script Date: 19.03.2018 8:58:01 ******/
--Договора ГПХ
IF OBJECT_ID(N'[LawContract]','U') IS NULL
begin
CREATE TABLE [dbo].[LawContract]
(
	LawContract_Id             int IDENTITY(1,1)      NOT NULL,
	LawContract_PersCard_Id    int                    NOT NULL,  --Ссылка на карточку работника
	LawContract_RefDep_Id      int                    NOT NULL,  --Ссылка на справочник подразделений
	LawContract_Date           date                           ,  --Дата
	LawContract_Days           int 	                          ,  --Дни
	LawContract_Sm             numeric(10,2)                  ,  --Сумма
	LawContract_PayDate        date                              --Дата, за которую проводится начисления
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

