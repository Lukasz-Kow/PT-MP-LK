CREATE TABLE [dbo].[Books]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NCHAR(100) NULL, 
    [Author] NCHAR(100) NULL, 
    [Pages] NUMERIC NULL, 
    [ISBN] NCHAR(100) NULL, 
    [Publisher] NCHAR(100) NULL, 
    [Language] NCHAR(100) NULL
)
