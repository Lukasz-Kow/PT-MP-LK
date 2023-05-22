CREATE TABLE [dbo].[Statuses]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BookId] INT NULL, 
    [Availability] BIT NULL, 
    CONSTRAINT [FK_Statuses_Books] FOREIGN KEY ([BookId]) REFERENCES [Books]([Id])
)
