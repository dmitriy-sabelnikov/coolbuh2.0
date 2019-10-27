--/****** Object:  Table [dbo].[SalBalance]    Script Date: 19.03.2018 8:58:01 ******/
--Сальдо
IF OBJECT_ID(N'[SalBalance]','U') IS NULL
begin
CREATE TABLE [dbo].[SalBalance]
(
	SalBalance_Id                int IDENTITY(1,1)      NOT NULL,
	SalBalance_PersCard_Id       int                    NOT NULL,  --Ссылка на карточку работника
	SalBalance_Date              date                           ,  --Дата
        SalBalance_BegMonthSm        numeric(10,2)                  ,  --Сальдо на начало месяца
        SalBalance_EndMonthSm        numeric(10,2)                  ,  --Сальдо на Конец месяца
	SalBalance_Flg               int                               --Флаги

 CONSTRAINT [PK_SalBalance.SalBalance_Id] PRIMARY KEY CLUSTERED 
 (
	[SalBalance_Id] ASC
 ),
 CONSTRAINT FK_SalBalance_PersCard_Id FOREIGN KEY (SalBalance_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)
create index ind_SalBalance_1_1 on SalBalance (SalBalance_PersCard_Id);
create index ind_SalBalance_1_2 on SalBalance (SalBalance_Date);
end; 


