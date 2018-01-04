CREATE TABLE [dbo].[Accounts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AccountId] NCHAR(20) NOT NULL UNIQUE, 
    [AccountPassword] NCHAR(20) NOT NULL
)
