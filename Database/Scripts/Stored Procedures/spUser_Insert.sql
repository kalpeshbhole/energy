USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spUser_Insert]    Script Date: 14-04-2023 15:20:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spUser_Insert]
(
    @FirstName      [NVARCHAR](50),
    @LastName       [NVARCHAR](50),
    @UserName       [NVARCHAR](50),
    @PasswordHash   [VARBINARY](max),
    @PasswordSalt   [VARBINARY](max)
)
AS
BEGIN
    INSERT INTO [dbo].[User](FirstName, LastName, UserName, PasswordHash, PasswordSalt)
    VALUES(@FirstName, @LastName, @UserName, @PasswordHash, @PasswordSalt);

	SELECT SCOPE_IDENTITY();
END
GO


