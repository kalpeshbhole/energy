USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spUser_Get]    Script Date: 14-04-2023 15:19:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spUser_Get]
(
	@UserId    INT = NULL,
    @UserName  [NVARCHAR](50) = NULL
)
AS
BEGIN
    SELECT  [Id],
            [FirstName],
            [LastName],
            [UserName],
            [PasswordHash],
            [PasswordSalt]
    FROM    [dbo].[User]
    WHERE   
	(Id = @UserId OR @UserId IS NULL)
	AND
	(UserName = @UserName OR @UserName IS NULL);
END
GO


