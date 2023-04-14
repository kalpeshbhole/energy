USE [salesdb]
GO

/****** Object:  Table [dbo].[Store]    Script Date: 14-04-2023 15:14:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[AddressId] [int] NULL,
	[CreateByUserId] [int] NULL,
	[UpdateByUserId] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Store] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[Store] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO

ALTER TABLE [dbo].[Store]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[Address] ([Id])
GO

ALTER TABLE [dbo].[Store]  WITH CHECK ADD FOREIGN KEY([CreateByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Store]  WITH CHECK ADD FOREIGN KEY([UpdateByUserId])
REFERENCES [dbo].[User] ([Id])
GO


