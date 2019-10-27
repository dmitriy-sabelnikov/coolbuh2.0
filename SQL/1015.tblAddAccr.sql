/****** Object:  Table [dbo].[AddAccr]    Script Date: 19.03.2018 8:58:01 ******/
--Дополнительные начисления зарплаты
IF OBJECT_ID(N'[AddAccr]','U') IS NULL
begin
CREATE TABLE [dbo].[AddAccr]
(
	AddAccr_Id                int IDENTITY(1,1)      NOT NULL,
	AddAccr_PersCard_Id       int                    NOT NULL,  --Ссылка на карточку работника
	AddAccr_RefDep_Id         int                    NOT NULL,  --Ссылка на справочник подразделений
        AddAccr_RefTypeAddAccr_Id int                    NOT NULL,  --Ссылка на справочник типов доп начислений
	AddAccr_Date              date                           ,  --Дата
        AddAccr_Sm                numeric(10,2)                     --Сумма доп. начислений
 CONSTRAINT [PK_AddAccr.AddAccr_Id] PRIMARY KEY CLUSTERED 
 (
	[AddAccr_Id] ASC
 ),
 CONSTRAINT FK_AddAccr_RefDep_Id FOREIGN KEY (AddAccr_RefDep_Id)     
    REFERENCES RefDep (RefDep_Id), 
 CONSTRAINT FK_AddAccr_PersCard_Id FOREIGN KEY (AddAccr_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 

 CONSTRAINT FK_AddAccr_RefTypeAddAccr_Id FOREIGN KEY (AddAccr_RefTypeAddAccr_Id)     
    REFERENCES RefTypeAddAccr (RefTypeAddAccr_Id) 
)
create index ind_AddAccr_1_1 on AddAccr (AddAccr_PersCard_Id);
create index ind_AddAccr_1_2 on AddAccr (AddAccr_RefDep_Id);
create index ind_AddAccr_1_3 on AddAccr (AddAccr_RefTypeAddAccr_Id);
create index ind_AddAccr_1_4 on AddAccr (AddAccr_RefDep_Id,AddAccr_Date);
end; 

