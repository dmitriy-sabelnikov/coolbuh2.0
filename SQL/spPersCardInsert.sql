/****** Script Date: 19.03.2018 9:00:22 ******/
/*Вставка в таблицу PersCard*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPersCardInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spPersCardInsert];
GO
Create Procedure [dbo].[spPersCardInsert] 
	@inPersCard_FName        nvarchar(35),       --Имя  
	@inPersCard_MName        nvarchar(35),       --Отчество
	@inPersCard_LName        nvarchar(35),       --Фамилия
	@inPersCard_TIN          nvarchar(12),       --ИНН
	@inPersCard_Exp          int,                --Стаж(excperience)
	@inPersCard_Grade        int,                --Классность
	@inPersCard_DOB          Date,               --Дата рождения(date of birth)
	@inPersCard_DOR          Date,               --Дата поступления(date of receipt)
	@inPersCard_DOD          Date,               --Дата увольнения(date of dismissal)
	@inPersCard_DOP          Date,               --Дата віхода на пенсию
        @inPersCard_SEX          int,                --Пол
        @outId                        int output

AS                            
BEGIN
    SET NOCOUNT ON 

    insert into PersCard (PersCard_FName, PersCard_MName, PersCard_LName, PersCard_TIN, PersCard_Exp, 
      PersCard_Grade, PersCard_DOB, PersCard_DOR, PersCard_DOD, PersCard_DOP, PersCard_SEX) 
	 values (@inPersCard_FName, @inPersCard_MName, @inPersCard_LName, @inPersCard_TIN, @inPersCard_Exp, @inPersCard_Grade, @inPersCard_DOB, @inPersCard_DOR, 
	  @inPersCard_DOD, @inPersCard_DOP, @inPersCard_SEX);
    select @outId=coalesce(IDENT_CURRENT ('PersCard'),0);
END