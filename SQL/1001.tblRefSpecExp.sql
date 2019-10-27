/****** Object:  Table [dbo].[RefSpecExp]    Script Date: 19.03.2018 8:43:50 ******/
--Справочник спецстажей
IF OBJECT_ID(N'[RefSpecExp]','U') IS NULL
CREATE TABLE [dbo].[RefSpecExp]
(
	RefSpecExp_Id          int IDENTITY(1,1) NOT NULL,
	RefSpecExp_Cd          nvarchar(25)      NOT NULL,
	RefSpecExp_C_PID       nvarchar(25),      
	RefSpecExp_Name        nvarchar(250)     
 CONSTRAINT [PK_RefSpecExp.RefSpecExp] PRIMARY KEY CLUSTERED 
 (
	[RefSpecExp_Id] ASC
 )
)


