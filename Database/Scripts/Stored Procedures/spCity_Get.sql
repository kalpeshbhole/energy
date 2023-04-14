USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spCity_Get]    Script Date: 14-04-2023 15:15:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spCity_Get]
(
	@StateId [INT] = NULL
)
AS
BEGIN
    SELECT  [Id],
            [Name],
            [StateId]
    FROM    [dbo].[City]
	WHERE (StateId = @StateId OR @StateId IS NULL);
END
GO


