/****** Object:  Table [dbo].[RefDep]    Script Date: 19.03.2018 8:43:50 ******/
--Справочник подразделений
IF OBJECT_ID(N'[RefDep]','U') IS NULL
CREATE TABLE [dbo].[RefDep]
(
	RefDep_Id   int IDENTITY(1,1) NOT NULL,
	RefDep_Cd   nvarchar(25)      NOT NULL,
	RefDep_Nm   nvarchar(250)     NOT NULL,
 CONSTRAINT [PK_RefDep.RefDep] PRIMARY KEY CLUSTERED 
 (
	[RefDep_Id] ASC
 )
)


