USE Master
GO

CREATE DATABASE Scrumboard
GO

USE [Scrumboard]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 12/26/2012 17:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 12/26/2012 17:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Vision] [nvarchar](2000) NULL,
	[TeamId] [int] NULL,
 CONSTRAINT [PK__Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sprint]    Script Date: 12/26/2012 17:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sprint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartsAt] [datetime] NOT NULL,
	[EndsAt] [datetime] NOT NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK__Sprint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStory]    Script Date: 12/26/2012 17:23:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](2000) NOT NULL,
	[Effort] [float] NULL,
	[IsDone] [bit] NOT NULL,
	[SprintId] [int] NULL,
	[ProjectId] [int] NOT NULL,
 CONSTRAINT [PK__UserStory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_UserStory_IsDone]    Script Date: 12/26/2012 17:23:44 ******/
ALTER TABLE [dbo].[UserStory] ADD  CONSTRAINT [DF_UserStory_IsDone]  DEFAULT ((0)) FOR [IsDone]
GO
/****** Object:  ForeignKey [FK_Project_Team]    Script Date: 12/26/2012 17:23:44 ******/
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Team]
GO
/****** Object:  ForeignKey [FK_Sprint_Project]    Script Date: 12/26/2012 17:23:44 ******/
ALTER TABLE [dbo].[Sprint]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Sprint] CHECK CONSTRAINT [FK_Sprint_Project]
GO
/****** Object:  ForeignKey [FK_UserStory_Project]    Script Date: 12/26/2012 17:23:44 ******/
ALTER TABLE [dbo].[UserStory]  WITH CHECK ADD  CONSTRAINT [FK_UserStory_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[UserStory] CHECK CONSTRAINT [FK_UserStory_Project]
GO
/****** Object:  ForeignKey [FK_UserStory_Sprint]    Script Date: 12/26/2012 17:23:44 ******/
ALTER TABLE [dbo].[UserStory]  WITH CHECK ADD  CONSTRAINT [FK_UserStory_Sprint] FOREIGN KEY([SprintId])
REFERENCES [dbo].[Sprint] ([Id])
GO
ALTER TABLE [dbo].[UserStory] CHECK CONSTRAINT [FK_UserStory_Sprint]
GO
