CREATE TABLE [dbo].[Project] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
	[Code]	 NVARCHAR(255)   NOT NULL, 
    [Name]   NVARCHAR (255)  NOT NULL,
    [Vision] NVARCHAR (2000) NULL,
    [TeamId] INT             NULL,    
    CONSTRAINT [PK__Project] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Project_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

