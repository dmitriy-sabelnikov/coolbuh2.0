/****** Object:  Table [dbo].[SickList]    Script Date: 19.03.2018 8:58:01 ******/
--Больничные
IF OBJECT_ID(N'[SickList]','U') IS NULL
begin
CREATE TABLE [dbo].[SickList]
(
	SickList_Id             int IDENTITY(1,1)      NOT NULL,
	SickList_PersCard_Id    int                    NOT NULL,  --Ссылка на карточку работника
	SickList_RefDep_Id      int                    NOT NULL,  --Ссылка на справочник подразделений
	SickList_Date           date                           ,  --Дата
	SickList_DaysEntprs     int                            ,  --Дни, оплачиваемые предприятием
	SickList_SmEntprs       numeric(10,2)                  ,  --Сумма, оплачиваемая предприятием
	SickList_DaysSocInsrnc  int                            ,  --Дни, оплачиваемые соцстахом
	SickList_SmSocInsrnc    numeric(10,2)                  ,  --Сумма, оплачиваемая соцстахом
	SickList_PayDate        date                           ,  --Дата, за которую проводится начисления
	SickList_DaysTmpDis     int                            ,  --Дни, временной нетрудоспособности
	SickList_ResSm          numeric(10,2)                     --Итоговая сумма
 CONSTRAINT [PK_SickList.SickList] PRIMARY KEY CLUSTERED 
 (
	[SickList_Id] ASC
 ),
 CONSTRAINT FK_SickList_RefDep_Id FOREIGN KEY (SickList_RefDep_Id)     
    REFERENCES RefDep (RefDep_Id), 
 CONSTRAINT FK_SickList_PersCard_Id FOREIGN KEY (SickList_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)

create index ind_SickList_1_1 on SickList (SickList_PersCard_Id);
create index ind_SickList_1_2 on SickList (SickList_RefDep_Id);
create index ind_SickList_1_3 on SickList (SickList_RefDep_Id,SickList_Date);
end; 

