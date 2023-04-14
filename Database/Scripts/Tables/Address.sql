USE [salesdb]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 14-04-2023 15:11:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address1] [varchar](100) NULL,
	[Address2] [varchar](100) NULL,
	[Address3] [varchar](100) NULL,
	[CityId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[ZipCode] [varchar](6) NULL,
	[CreateByUserId] [int] NULL,
	[UpdateByUserId] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Address] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[Address] ADD  DEFAULT (getdate()) FOR [UpdateDate]
GO

ALTER TABLE [dbo].[Address]  WITH CHECK ADD FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO

ALTER TABLE [dbo].[Address]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO

ALTER TABLE [dbo].[Address]  WITH CHECK ADD FOREIGN KEY([CreateByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Address]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO

ALTER TABLE [dbo].[Address]  WITH CHECK ADD FOREIGN KEY([UpdateByUserId])
REFERENCES [dbo].[User] ([Id])
GO


