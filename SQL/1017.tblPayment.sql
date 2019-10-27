/****** Object:  Table [dbo].[Payment]    Script Date: 19.03.2018 8:58:01 ******/
--Выплаты
IF OBJECT_ID(N'[Payment]','U') IS NULL
begin
CREATE TABLE [dbo].[Payment]
(
	Payment_Id                int IDENTITY(1,1)      NOT NULL,
	Payment_PersCard_Id       int                    NOT NULL,  --Ссылка на карточку работника
	Payment_Date              date                           ,  --Дата
	Payment_Type              int                    NOT NULL,  --Тип выплаты(1-касса, 2-выписка, 3-список, 4-натуроплата)
	Payment_Amt               numeric(10,2)                  ,  --Количество
	Payment_Price             numeric(10,2)                  ,  --Цена
  Payment_Sm                numeric(10,2)                     --Сумма
 CONSTRAINT [PK_Payment.Payment_Id] PRIMARY KEY CLUSTERED 
 (
	[Payment_Id] ASC
 ),
 CONSTRAINT FK_Payment_PersCard_Id FOREIGN KEY (Payment_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
)
create index ind_Payment_1_1 on Payment (Payment_PersCard_Id);
create index ind_Payment_1_2 on Payment (Payment_Date);
end; 

