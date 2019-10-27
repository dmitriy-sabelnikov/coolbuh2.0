/****** Object:  Table [dbo].[SetupApp]    Script Date: 19.03.2018 9:00:22 ******/
IF OBJECT_ID(N'[SetupApp]','U') IS NULL
CREATE TABLE [dbo].[SetupApp](
	SetupApp_Type		int           NOT NULL DEFAULT (0),
	SetupApp_ValueDigit	int           NOT NULL DEFAULT (0),
	SetupApp_ValueString	nvarchar(250) NULL,
 CONSTRAINT [PK_SetupApp.SetupApp] PRIMARY KEY CLUSTERED 
 (
	[SetupApp_Type] ASC
 )
)


