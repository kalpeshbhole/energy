USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spCountry_Get]    Script Date: 14-04-2023 15:16:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spCountry_Get]
AS
BEGIN
    SELECT  [Id],
            [Name],
			[CountryCode]
    FROM    [dbo].[Country];
END
GO


