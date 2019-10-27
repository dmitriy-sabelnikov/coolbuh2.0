--/****** Object:  Table [dbo].[SpecExp]    Script Date: 19.03.2018 8:58:01 ******/
--Личные карточки. Спецстаж
IF OBJECT_ID(N'[CardSpecExp]','U') IS NULL
CREATE TABLE [dbo].[CardSpecExp]
(
	CardSpecExp_Id             int IDENTITY(1,1)  NOT NULL,
	CardSpecExp_PersCard_Id    int                NOT NULL,  --Ссылка на карточку работника
	CardSpecExp_PerBeg         Date	                      ,  --Период начало
	CardSpecExp_PerEnd         Date	                      ,  --Период конец
        CardSpecExp_RefSpecExp_Id  int                             --Тип спецстажа
 CONSTRAINT [PK_CardSpecExp.SpecExp] PRIMARY KEY CLUSTERED 
 (
	[CardSpecExp_Id] ASC
 ),
 CONSTRAINT FK_CardSpecExp_PersCard_Id FOREIGN KEY (CardSpecExp_PersCard_Id)     
    REFERENCES dbo.PersCard (PersCard_Id),
 CONSTRAINT FK_CardSpecExp_RefSpecPersCard_Id FOREIGN KEY (CardSpecExp_RefSpecExp_Id)     
    REFERENCES dbo.RefSpecExp (RefSpecExp_Id)
)


