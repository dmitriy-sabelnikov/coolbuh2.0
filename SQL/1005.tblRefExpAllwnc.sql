/****** Object:  Table [dbo].[RefExpAllwnc]    Script Date: 19.03.2018 8:43:50 ******/
--Справочник надбавок за стаж
IF OBJECT_ID(N'[RefExpAllwnc]','U') IS NULL
CREATE TABLE [dbo].[RefExpAllwnc]
(
	RefExpAllwnc_Id              int IDENTITY(1,1) NOT NULL,
	RefExpAllwnc_Cd              varchar(25)               , --Код
        RefExpAllwnc_Nm              varchar(50)               , --Наименование
	RefExpAllwnc_Year            int               NOT NULL, --Год
	RefExpAllwnc_Mech            numeric(5,2)              , --Надбавка механикам
        RefExpAllwncMech_RefDep_Id   int 	               , --Условие применения для надбавки механикам. Подразделение
	RefExpAllwnc_Oth             numeric(5,2)              , --Надбавка другим работникам
        RefExpAllwnc_Flg             int 	               , --Флаг  
 CONSTRAINT [PK_RefExpAllwnc.RefExpAllwnc] PRIMARY KEY CLUSTERED 
 (
	[RefExpAllwnc_Id] ASC
 ),
  CONSTRAINT FK_RefExpAllwncMech_RefDep_Id FOREIGN KEY (RefExpAllwncMech_RefDep_Id)     
    REFERENCES RefDep (RefDep_Id) 

)