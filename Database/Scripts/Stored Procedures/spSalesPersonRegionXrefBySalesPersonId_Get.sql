USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spSalesPersonRegionXrefBySalesPersonId_Get]    Script Date: 14-04-2023 15:18:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spSalesPersonRegionXrefBySalesPersonId_Get]
	@SalesPersonId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT  SalesPersonRegionXref.Id,
			SalesPersonRegionXref.SalesPersonId,
			SalesPersonRegionXref.CityId,
			City.Name AS City, 
			SalesPersonRegionXref.StateId,
			State.Name AS State,
			SalesPersonRegionXref.CountryId,
			State.Name AS Country,
			SalesPersonRegionXref.IsPrimary,
			SalesPersonRegionXref.CreateByUserId,
			CONCAT(UC.FirstName , ' ', UC.LastName) AS 'CreateByUser',
			SalesPersonRegionXref.UpdateByUserId, 
			CONCAT(UU.FirstName , ' ', UU.LastName) AS 'UpdateByUser',
			SalesPersonRegionXref.CreateDate, 
			SalesPersonRegionXref.UpdateDate
	FROM [dbo].[SalesPersonRegionXref]
	LEFT JOIN [dbo].[City] ON City.Id = [SalesPersonRegionXref].CityId
	INNER JOIN [dbo].[State] ON State.Id = [SalesPersonRegionXref].StateId
	INNER JOIN [dbo].[Country] ON Country.Id = [SalesPersonRegionXref].CountryId
	INNER JOIN [dbo].[User] UC ON UC.Id = SalesPersonRegionXref.CreateByUserId
	INNER JOIN [dbo].[User] UU ON UU.Id = SalesPersonRegionXref.UpdateByUserId
	WHERE SalesPersonId = @SalesPersonId

END
GO


