USE [salesdb]
GO

/****** Object:  Table [dbo].[SalesPerson]    Script Date: 14-04-2023 15:13:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[CreateByUserId] [int] NULL,
	[UpdateByUserId] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SalesPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SalesPerson] ADD  DEFAULT (getutcdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[SalesPerson] ADD  DEFAULT (getutcdate()) FOR [UpdateDate]
GO

ALTER TABLE [dbo].[SalesPerson]  WITH CHECK ADD FOREIGN KEY([CreateByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[SalesPerson]  WITH CHECK ADD FOREIGN KEY([UpdateByUserId])
REFERENCES [dbo].[User] ([Id])
GO


