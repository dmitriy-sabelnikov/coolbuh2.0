/****** Object:  Table [dbo].[AddPayment]    Script Date: 19.03.2018 8:58:01 ******/
--Дополнительные выплаты
IF OBJECT_ID(N'[AddPayment]','U') IS NULL
begin
CREATE TABLE [dbo].[AddPayment]
(
	AddPayment_Id                 int IDENTITY(1,1)      NOT NULL,
	AddPayment_PersCard_Id        int                    NOT NULL,  --Ссылка на карточку работника
	AddPayment_Date               date                   NOT NULL,  --Дата
	AddPayment_TypeAddPayment_Id  int                    NOT NULL,  --Тип доп. выплаты
        AddPayment_Sm                 numeric(10,2)                     --Сумма
CONSTRAINT [PK_AddPayment.AddPayment_Id] PRIMARY KEY CLUSTERED 
 (
	[AddPayment_Id] ASC
 ),
  CONSTRAINT FK_AddPayment_PersCard_Id FOREIGN KEY (AddPayment_PersCard_Id)     
    REFERENCES PersCard (PersCard_Id), 
  CONSTRAINT FK_AddPayment_TypeAddPayment_Id FOREIGN KEY (AddPayment_TypeAddPayment_Id)     
    REFERENCES RefTypeAddPayment (RefTypeAddPayment_Id)
)
create index ind_AddPayment_1_1 on AddPayment (AddPayment_PersCard_Id);
create index ind_AddPayment_1_2 on AddPayment (AddPayment_Date);
end; 


