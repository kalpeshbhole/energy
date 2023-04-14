USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spState_Get]    Script Date: 14-04-2023 15:18:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spState_Get]
(
	@CountryId [INT] = NULL
)
AS
BEGIN
    SELECT  [Id],
            [Name],
            [CountryId]
    FROM    [dbo].[State]
	WHERE (CountryId = @CountryId OR @CountryId IS NULL);
END
GO


