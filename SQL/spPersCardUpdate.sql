/****** Script Date: 19.03.2018 9:00:22 ******/
/*Обновление таблицы PersCard*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPersCardUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[spPersCardUpdate];
GO
Create Procedure [dbo].[spPersCardUpdate]
	@inPersCard_Id           int,                --id карточки
	@inPersCard_FName        nvarchar(35),       --Имя  
	@inPersCard_MName        nvarchar(35),       --Отчество
	@inPersCard_LName        nvarchar(35),       --Фамилия
	@inPersCard_TIN          nvarchar(12),       --ИНН
	@inPersCard_Exp          int,                --Стаж(excperience)
	@inPersCard_Grade        int,                --Классность
	@inPersCard_DOB          Date,               --Дата рождения(date of birth)
	@inPersCard_DOR          Date,               --Дата поступления(date of receipt)
	@inPersCard_DOD          Date,               --Дата увольнения(date of dismissal)
	@inPersCard_DOP          Date,               --Дата выхода на пенсию(date of pens)
        @inPersCard_SEX          int                 --Пол
AS                            
BEGIN
    SET NOCOUNT ON 

	UPDATE PersCard SET
	  PersCard_FName	        = @inPersCard_FName, 
	  PersCard_MName	        = @inPersCard_MName,   
	  PersCard_LName	        = @inPersCard_LName,   
	  PersCard_TIN		        = @inPersCard_TIN,     
	  PersCard_Exp		        = @inPersCard_Exp,     
	  PersCard_Grade	        = @inPersCard_Grade,   
	  PersCard_DOB		        = @inPersCard_DOB,     
	  PersCard_DOR		        = @inPersCard_DOR,     
	  PersCard_DOD		        = @inPersCard_DOD,
	  PersCard_DOP		        = @inPersCard_DOP,
          PersCard_SEX                  = @inPersCard_SEX
    WHERE PersCard_Id = @inPersCard_Id;
END
