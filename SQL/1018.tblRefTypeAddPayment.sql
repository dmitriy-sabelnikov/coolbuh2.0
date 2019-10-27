/****** Object:  Table [dbo].[RefTypeAddPayment]    Script Date: 19.03.2018 8:58:01 ******/
--Справочник. Тип доп. выплат
IF OBJECT_ID(N'[RefTypeAddPayment]','U') IS NULL
begin
CREATE TABLE [dbo].[RefTypeAddPayment]
(
	RefTypeAddPayment_Id       int IDENTITY(1,1)      NOT NULL,
	RefTypeAddPayment_Cd       nvarchar(25)                   ,  --Код
	RefTypeAddPayment_Nm       nvarchar(255)                  ,  --Наименование
 CONSTRAINT [PK_RefTypeAddPayment.RefTypeAddPayment_Id] PRIMARY KEY CLUSTERED 
 (
	[RefTypeAddPayment_Id] ASC
 )
)
end; 

