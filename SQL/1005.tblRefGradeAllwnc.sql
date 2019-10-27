/****** Object:  Table [dbo].[RefGradeAllwnc]    Script Date: 19.03.2018 8:58:01 ******/
--Надбавка за классность
IF OBJECT_ID(N'[RefGradeAllwnc]','U') IS NULL
begin
CREATE TABLE [dbo].[RefGradeAllwnc]
(
    RefGradeAllwnc_Id             int IDENTITY(1,1)      NOT NULL,
    RefGradeAllwnc_Cd             varchar(25)                    , --Код
    RefGradeAllwnc_Nm             varchar(50)                    , --Наименование
    RefGradeAllwnc_Pct            numeric(5,2)                   , --процент
    RefGradeAllwnc_Grade          int 	                         , --Условие применения. Классность
    RefGradeAllwnc_RefDep_Id      int                            , --Условие применения. Подразделение
    RefGradeAllwnc_Flg            int                            , --Флаги
 CONSTRAINT [PK_RefGradeAllwnc.RefGradeAllwnc] PRIMARY KEY CLUSTERED 
 (
	[RefGradeAllwnc_Id] ASC
 ),
  CONSTRAINT FK_RefGradeAllwnc_RefDep_Id FOREIGN KEY (RefGradeAllwnc_RefDep_Id)     
    REFERENCES RefDep (RefDep_Id) 
)
end; 

