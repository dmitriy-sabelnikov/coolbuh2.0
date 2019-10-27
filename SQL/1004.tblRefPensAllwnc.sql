/****** Object:  Table [dbo].[RefPensAllwnc]    Script Date: 19.03.2018 8:58:01 ******/
--Надбавки за пенсию
IF OBJECT_ID(N'[RefPensAllwnc]','U') IS NULL
CREATE TABLE [dbo].[RefPensAllwnc]
(
	RefPensAllwnc_Id             int IDENTITY(1,1) NOT NULL,
	RefPensAllwnc_Cd             varchar(25)               , --Код
        RefPensAllwnc_Nm             varchar(50)               , --Наименование
        RefPensAllwnc_Pct            numeric(5,2)              , --процент
        RefPensAllwnc_Flg            int 	               , --Флаги
 CONSTRAINT [PK_RefPensAllwnc.RefPensAllwnc] PRIMARY KEY CLUSTERED 
 (
	[RefPensAllwnc_Id] ASC
 )
)
