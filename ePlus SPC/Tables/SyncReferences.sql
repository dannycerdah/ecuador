CREATE TABLE [dbo].[Table]
(
	[TableName] NCHAR(30) NOT NULL PRIMARY KEY, 
    [TableVersion] BIGINT NOT NULL, 
    [LastUpdate] DATETIME NOT NULL, 
    [SyncEnable] BIT NOT NULL
)
