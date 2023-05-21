CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NCHAR(100) NULL, 
    [LastName] NCHAR(100) NULL, 
    [Age] INT NULL, 
    [Address] NCHAR(100) NULL, 
    [City] NCHAR(100) NULL
)
