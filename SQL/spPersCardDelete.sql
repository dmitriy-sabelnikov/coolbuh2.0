/****** Script Date: 19.03.2018 9:00:22 ******/
/*Удаление строки из таблицы PersCard*/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spPersCardDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
  drop procedure [dbo].[spPersCardDelete];
GO
Create Procedure [dbo].[spPersCardDelete]
	@inPersCard_Id   int           --id карточки  
AS                            
BEGIN
    SET NOCOUNT ON 

  BEGIN TRANSACTION
    DELETE 
      FROM Child 
     WHERE Child_PersCard_Id = @inPersCard_Id;

    DELETE 
      FROM CardStatus 
     WHERE CardStatus_PersCard_Id = @inPersCard_Id;

    DELETE 
      FROM TaxRelief 
     WHERE TaxRelief_PersCard_Id = @inPersCard_Id;

    DELETE 
      FROM Disability 
     WHERE Disability_PersCard_Id = @inPersCard_Id;
 
    DELETE 
      FROM CardSpecExp 
     WHERE CardSpecExp_PersCard_Id = @inPersCard_Id;
    
    DELETE 
      FROM PersCard
     WHERE PersCard_Id = @inPersCard_Id;

  IF(@@error <> 0)
    ROLLBACK TRANSACTION
  ELSE 
    COMMIT TRANSACTION;
END
