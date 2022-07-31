CREATE TABLE [Todo] (
    [ID] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Todo] PRIMARY KEY ([ID])
);
GO