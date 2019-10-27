/****** Object:  Table [dbo].[PersCard]    Script Date: 19.03.2018 8:58:01 ******/
--Личные карточки
IF OBJECT_ID(N'[PersCard]','U') IS NULL
CREATE TABLE [dbo].[PersCard]
(
    PersCard_Id           int IDENTITY(1,1)      NOT NULL,
    PersCard_FName        nvarchar(35)	             ,  --Имя
    PersCard_MName        nvarchar(35)               ,  --Отчество
    PersCard_LName        nvarchar(35)	             ,  --Фамилия
    PersCard_TIN          nvarchar(12)	     NOT NULL,  --ИНН
    PersCard_Exp          int 	                     ,  --Стаж(excperience)
    PersCard_Grade        int 	                     ,  --Классность
    PersCard_DOB          Date	                     ,  --Дата рождения(date of birth)
    PersCard_DOR          Date	                     ,  --Дата поступления(date of receipt)
    PersCard_DOD          Date	                     ,  --Дата увольнения(date of dismissal)
    PersCard_DOP          Date	                     ,  --Дата выхода на пенсию (date of pens)
    PersCard_SEX          int 			     ,  --пол(0-Ж, 1 - м)
 CONSTRAINT [PK_PersCard.PersCard] PRIMARY KEY CLUSTERED 
 (
	[PersCard_Id] ASC
 )
)


