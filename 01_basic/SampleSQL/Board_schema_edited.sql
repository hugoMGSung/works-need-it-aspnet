CREATE TABLE [dbo].[TblNotes](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserId] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Title] [nvarchar](150) NOT NULL,
	[ReadCount] [int] NULL,
	[PostDate] [datetime] NULL,
	[Contents] [ntext] NULL
)
GO

CREATE TABLE [dbo].[TblUser](
	[Num] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](20) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](4) NULL,
	[Birthday] [date] NULL,
	[Email] [varchar](150) NOT NULL,
	[Phone] [varchar](13) NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_TblUser] PRIMARY KEY CLUSTERED 
(
	[Num] ASC
),
 CONSTRAINT [UK_TblUser] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)
)
GO
ALTER TABLE [dbo].[TblNotes]  WITH CHECK ADD  CONSTRAINT [FK_TblNotes_TblUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[TblUser] ([UserId])
GO
ALTER TABLE [dbo].[TblNotes] CHECK CONSTRAINT [FK_TblNotes_TblUser]
GO