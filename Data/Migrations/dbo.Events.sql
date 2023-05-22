CREATE TABLE [dbo].[Events]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StatusId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [Time] DATETIME NOT NULL, 
    [Type] NCHAR(30) NULL, 
    [Reason] NCHAR(100) NULL, 
    [Description] NCHAR(100) NULL, 
    CONSTRAINT [FK_Events_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [Customers]([Id]), 
    CONSTRAINT [FK_Events_Statuses] FOREIGN KEY ([StatusId]) REFERENCES [Statuses]([Id])
)
