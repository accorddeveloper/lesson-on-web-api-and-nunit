CREATE DATABASE UnitService;

GO

CREATE LOGIN UnitServiceUser WITH PASSWORD = 'Password1';

GO

USE UnitService;

GO

CREATE USER UnitServiceUser FOR LOGIN UnitServiceUser

GO

EXEC sp_addrolemember N'db_owner', N'UnitServiceUser'

GO

GRANT EXEC TO UnitServiceUser;

GO

CREATE TABLE [dbo].[Units] (
	[Id] uniqueidentifier NOT NULL DEFAULT NEWID(),
	[Name] NVARCHAR(200) NOT NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[Units](Name) VALUES('Unit 01A');
INSERT INTO [dbo].[Units](Name) VALUES('Unit 01B');
INSERT INTO [dbo].[Units](Name) VALUES('Unit 02A');

GO

CREATE TABLE [dbo].[People](
	[Id] uniqueidentifier NOT NULL DEFAULT NEWID(),
	[FirstName] NVARCHAR(200) NOT NULL,
	[LastName] NVARCHAR(200) NOT NULL,
	[DateOfBirth] datetime2 NOT NULL,
	[UnitId] uniqueidentifier NOT NULL
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Units] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([Id]);

ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Units];

GO

DECLARE @UnitId UNIQUEIDENTIFIER;

SELECT TOP 1 @UnitId = [Id] FROM dbo.Units WHERE Name = 'Unit 01B';

INSERT INTO [dbo].[People]([FirstName],[LastName],[DateOfBirth],[UnitId]) VALUES('John', 'Tester', '1982-01-05', @UnitId);

GO
