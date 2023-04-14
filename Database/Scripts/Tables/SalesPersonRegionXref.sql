USE [salesdb]
GO

/****** Object:  Table [dbo].[SalesPersonRegionXref]    Script Date: 14-04-2023 15:13:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesPersonRegionXref](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalesPersonId] [int] NOT NULL,
	[CityId] [int] NULL,
	[StateId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[CreateByUserId] [int] NULL,
	[UpdateByUserId] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SalesPersonRegionXref] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_SalesPersonId_StateId] UNIQUE NONCLUSTERED 
(
	[SalesPersonId] ASC,
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_StateId_IsPrimary] UNIQUE NONCLUSTERED 
(
	[StateId] ASC,
	[IsPrimary] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SalesPersonRegionXref] ADD  DEFAULT (getutcdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[SalesPersonRegionXref] ADD  DEFAULT (getutcdate()) FOR [UpdateDate]
GO

ALTER TABLE [dbo].[SalesPersonRegionXref]  WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([Id])
GO

ALTER TABLE [dbo].[SalesPersonRegionXref]  WITH CHECK ADD FOREIGN KEY([CreateByUserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[SalesPersonRegionXref]  WITH CHECK ADD FOREIGN KEY([SalesPersonId])
REFERENCES [dbo].[SalesPerson] ([Id])
GO

ALTER TABLE [dbo].[SalesPersonRegionXref]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO

ALTER TABLE [dbo].[SalesPersonRegionXref]  WITH CHECK ADD FOREIGN KEY([UpdateByUserId])
REFERENCES [dbo].[User] ([Id])
GO


