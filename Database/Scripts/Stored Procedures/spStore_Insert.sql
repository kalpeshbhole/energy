USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spStore_Insert]    Script Date: 14-04-2023 15:19:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spStore_Insert]
(
	@Name VARCHAR(100), 
	@Address1 VARCHAR(100), 
	@Address2 VARCHAR(100), 
	@Address3 VARCHAR(100), 
	@CityId INT, 
	@StateId INT,
	@CountryId INT,
	@ZipCode VARCHAR(6),
	@UserId INT
)
AS
BEGIN
    
	INSERT INTO [dbo].[Address](Address1, Address2, Address3, CityId, StateId, CountryId, ZipCode, CreateByUserId, UpdateByUserId, CreateDate, UpdateDate)
	VALUES(@Address1, @Address2, @Address3, @CityId, @StateId, @CountryId, @ZipCode, @UserId, @UserId, GETUTCDATE(), GETUTCDATE());

	DECLARE @AddressId AS INT = SCOPE_IDENTITY();
	
	INSERT INTO [dbo].[Store](Name, AddressId, CreateByUserId, UpdateByUserId, CreateDate, UpdateDate)
    VALUES(@Name, @AddressId, @UserId, @UserId, GETUTCDATE(), GETUTCDATE());

	SELECT SCOPE_IDENTITY();
END

GO


