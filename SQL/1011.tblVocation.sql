/****** Object:  Table [dbo].[Vocation]    Script Date: 19.03.2018 8:58:01 ******/
--Отпускные
IF OBJECT_ID(N'[Vocation]','U') IS NULL
begin
CREATE TABLE [dbo].[Vocation]
(
	Vocation_Id             int IDENTITY(1,1)      NOT NULL,
	Vocation_PersCard_Id    int                    NOT NULL,  --Ссылка на карточку работника
	Vocation_RefDep_Id      int                    NOT NULL,  --Ссылка на справочник подразделений
	Vocation_Date           date                           ,  --Дата
	Vocation_Days           int 	                       ,  --Дни отпуска
	Vocation_Sm             numeric(10,2) 		       ,  --Сумма отпускных
	Vocation_PayDate        date                              --Дата, за которую проводится начисления
 CONSTRAINT [PK_Vocation.Vocation] PRIMARY KEY CLUSTERED 
 (
	[Vocation_Id] ASC
 ),
 CONSTRAINT FK_Vocation_RefDep_Id FOREIGN KEY (Vocation_RefDep_Id)     
    REFERENCES RefDep (RefDep_Id), 
 CONSTRAINT FK_Vocation_PersCard_Id FOREIGN KEY (Vocation_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)

create index ind_Vocation_1_1 on Vocation (Vocation_PersCard_Id);
create index ind_Vocation_1_2 on Vocation (Vocation_RefDep_Id);
create index ind_Vocation_1_3 on Vocation (Vocation_RefDep_Id,Vocation_Date);
end; 

