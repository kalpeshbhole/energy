USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spSalesPersonRegionXref_Insert]    Script Date: 14-04-2023 15:18:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSalesPersonRegionXref_Insert] 
	@SalesPersonId INT,
	@CityId INT = NULL,
	@StateId INT,
	@CountryId INT,
	@IsPrimary BIT,
	@UserId INT
AS
BEGIN
	INSERT INTO [dbo].[SalesPersonRegionXref](SalesPersonId, CityId, StateId, CountryId, IsPrimary, CreateByUserId, UpdateByUserId, CreateDate, UpdateDate)
	VALUES(@SalesPersonId, @CityId, @StateId, @CountryId, @IsPrimary, @UserId, @UserId, GETUTCDATE(), GETUTCDATE());

	SELECT SCOPE_IDENTITY();
END
GO


