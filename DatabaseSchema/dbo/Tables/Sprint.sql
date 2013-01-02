CREATE TABLE [dbo].[Sprint] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [StartsAt]  DATETIME NOT NULL,
    [EndsAt]    DATETIME NOT NULL,
    [ProjectId] INT      NOT NULL,
    CONSTRAINT [PK__Sprint] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sprint_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id])
);

