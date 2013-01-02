CREATE TABLE [dbo].[UserStory] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Text]      NVARCHAR (2000) NOT NULL,
    [Effort]    FLOAT (53)      NULL,
    [IsDone]    BIT             CONSTRAINT [DF_UserStory_IsDone] DEFAULT ((0)) NOT NULL,
    [SprintId]  INT             NULL,
    [ProjectId] INT             NOT NULL,
    CONSTRAINT [PK__UserStory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserStory_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]),
    CONSTRAINT [FK_UserStory_Sprint] FOREIGN KEY ([SprintId]) REFERENCES [dbo].[Sprint] ([Id])
);

