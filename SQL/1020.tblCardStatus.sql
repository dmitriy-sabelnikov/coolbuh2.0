--/****** Object:  Table [dbo].[CardStatus]    Script Date: 19.03.2018 8:58:01 ******/
--Личные карточки. Статус
IF OBJECT_ID(N'[CardStatus]','U') IS NULL
CREATE TABLE [dbo].[CardStatus]
(
	CardStatus_Id           int IDENTITY(1,1)  NOT NULL,
	CardStatus_PersCard_Id  int                NOT NULL,  --Ссылка на карточку работника
	CardStatus_PerBeg       Date	                    ,  --Период начало
	CardStatus_PerEnd       Date	                    ,  --Период конец
	CardStatus_Type         int                            --Тип статуса(1-постоянный, 2-временный, 3-ассоциированный )
 CONSTRAINT [PK_CardStatus.CardStatus] PRIMARY KEY CLUSTERED 
 (
	[CardStatus_Id] ASC
 ),
 CONSTRAINT FK_CardStatus_PersCard_Id FOREIGN KEY (CardStatus_PersCard_Id)     
    REFERENCES dbo.PersCard (PersCard_Id)
)


