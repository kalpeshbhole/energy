USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spSalesPerson_Insert]    Script Date: 14-04-2023 15:16:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSalesPerson_Insert] 
	@FirstName      [NVARCHAR](50),
    @MiddleName     [NVARCHAR](50),
    @LastName       [NVARCHAR](50),
	@UserId         [INT]

AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [dbo].[SalesPerson](FirstName, MiddleName, LastName, CreateByUserId, UpdateByUserId, CreateDate, UpdateDate)
	VALUES(@FirstName,@MiddleName,@LastName, @UserId, @UserId, GETUTCDATE(), GETUTCDATE());

	SELECT SCOPE_IDENTITY();
END
GO


