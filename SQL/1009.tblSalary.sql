/****** Object:  Table [dbo].[Salary]    Script Date: 19.03.2018 8:58:01 ******/
--Зарплата
IF OBJECT_ID(N'[Salary]','U') IS NULL
begin
CREATE TABLE [dbo].[Salary]
(
	Salary_Id             int IDENTITY(1,1)      NOT NULL,
	Salary_PersCard_Id    int                    NOT NULL,  --Ссылка на карточку работника
	Salary_RefDep_Id      int                    NOT NULL,  --Ссылка на справочник подразделений
	Salary_Date           date                           ,  --Дата
	Salary_Days           int DEFAULT (0)                ,  --Отработанные дни
	Salary_Hours          numeric(5,2)                   ,  --Отработанные часы
	Salary_BaseSm         numeric(10,2)                  ,  --Основная зарплата
	Salary_PensId         int                            ,  --Доплата пенсионеру(id доплаты из Allowance)
	Salary_PensPct        numeric(5,2)                   ,  --Доплата пенсионеру(процент)
	Salary_PensSm         numeric(10,2)                  ,  --Доплата пенсионеру(сумма) 
	Salary_ExpId          int                            ,  --Доплата за стаж(id доплаты из Allowance)
	Salary_ExpPct         numeric(5,2)                   ,  --Доплата за стаж(процент)
	Salary_ExpSm          numeric(10,2)                  ,  --Доплата за стаж(сумма)
	Salary_GradeId        int                            ,  --Доплата за класность(id доплаты из Allowance)
	Salary_GradePct       numeric(5,2)                   ,  --Доплата за класность(процент)
	Salary_GradeSm        numeric(10,2)                  ,  --Доплата за класность(сумма)
	Salary_OthId          int                            ,  --Другие доплаты(id доплаты из Allowance)
	Salary_OthPct         numeric(5,2)                   ,  --Другие доплаты(процент)
	Salary_OthSm          numeric(10,2)                  ,  --Другие доплаты(сумма)
	Salary_KTU            numeric(5,2)                   ,  --КТУ
	Salary_KTUSm          numeric(10,2)                  ,  --Доплата за КТУ
	Salary_ResSm          numeric(10,2)                    --Итоговая сумма
 CONSTRAINT [PK_Salary.Salary] PRIMARY KEY CLUSTERED 
 (
	[Salary_Id] ASC
 ),
 CONSTRAINT FK_Salary_RefDep_Id FOREIGN KEY (Salary_RefDep_Id)     
    REFERENCES RefDep (RefDep_Id), 
 CONSTRAINT FK_Salary_PersCard_Id FOREIGN KEY (Salary_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
 CONSTRAINT FK_Salary_PensId FOREIGN KEY (Salary_PensId)     
    REFERENCES RefPensAllwnc (RefPensAllwnc_Id), 
 CONSTRAINT FK_Salary_ExpId FOREIGN KEY (Salary_ExpId)     
    REFERENCES RefExpAllwnc (RefExpAllwnc_Id),
 CONSTRAINT FK_Salary_GradeId FOREIGN KEY (Salary_GradeId)     
    REFERENCES RefGradeAllwnc (RefGradeAllwnc_Id), 
 CONSTRAINT FK_Salary_OthId FOREIGN KEY (Salary_OthId)     
    REFERENCES RefOthAllwnc (RefOthAllwnc_Id) 
)

create index ind_Salary_1_1 on Salary (Salary_PersCard_Id);
create index ind_Salary_1_2 on Salary (Salary_RefDep_Id);
create index ind_Salary_1_3 on Salary (Salary_RefDep_Id,Salary_Date);
end; 

