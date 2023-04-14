USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spStore_Get]    Script Date: 14-04-2023 15:19:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spStore_Get]
(
	@StoreId  [INT] = NULL,
    @StateId  [INT] = NULL,
	@CityId   [INT] = NULL
)
AS
BEGIN
	SELECT  Store.Id, Store.Name, 
			Address1, Address2, Address3,
			[Address].CityId,
			City.Name AS City,
			[Address].StateId,
			State.Name AS State,
			[Address].CountryId,
			Country.Name AS Country,
			ZipCode,
			Store.CreateByUserId,
			CONCAT(UC.FirstName , ' ', UC.LastName) AS 'CreateByUser',
			Store.UpdateByUserId, 
			CONCAT(UU.FirstName , ' ', UU.LastName) AS 'UpdateByUser',
			Store.CreateDate, 
			Store.UpdateDate
	FROM    [dbo].[Store]
	INNER JOIN [dbo].[Address] ON Store.AddressId = [Address].Id
	INNER JOIN [dbo].[City] ON City.Id = [Address].CityId
	INNER JOIN [dbo].[State] ON State.Id = [Address].StateId
	INNER JOIN [dbo].[Country] ON Country.Id = [Address].CountryId
	INNER JOIN [dbo].[User] UC ON UC.Id = Store.CreateByUserId
	INNER JOIN [dbo].[User] UU ON UU.Id = Store.UpdateByUserId
	WHERE
	([Store].Id = @StoreId OR @StoreId IS NULL)
	AND
	([Address].StateId = @StateId OR @StateId IS NULL)
	AND
	([Address].CityId = @CityId OR @CityId IS NULL)
END
GO


