USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spSalesPersonById_Get]    Script Date: 14-04-2023 15:17:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spSalesPersonById_Get]
	@SalesPersonId INT
AS
BEGIN

	SET NOCOUNT ON;

    SELECT	SalesPerson.[Id],
            SalesPerson.[FirstName],
            SalesPerson.[MiddleName],
            SalesPerson.[LastName],
			SalesPerson.[CreateByUserId],
			CONCAT(UC.FirstName , ' ', UC.LastName) AS 'CreateByUser',
			SalesPerson.[UpdateByUserId], 
			CONCAT(UU.FirstName , ' ', UU.LastName) AS 'UpdateByUser',
			SalesPerson.CreateDate, 
			SalesPerson.UpdateDate
    FROM    [dbo].[SalesPerson]
	INNER JOIN [dbo].[User] UC ON UC.Id = SalesPerson.CreateByUserId
	INNER JOIN [dbo].[User] UU ON UU.Id = SalesPerson.UpdateByUserId
    WHERE   
	(SalesPerson.Id = @SalesPersonId OR @SalesPersonId IS NULL);

	SELECT  SalesPersonRegionXref.SalesPersonId,
			SalesPersonRegionXref.CityId,
			City.Name AS City, 
			SalesPersonRegionXref.StateId,
			State.Name AS State,
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
	INNER JOIN [dbo].[User] UC ON UC.Id = SalesPersonRegionXref.CreateByUserId
	INNER JOIN [dbo].[User] UU ON UU.Id = SalesPersonRegionXref.UpdateByUserId
	WHERE SalesPersonId = @SalesPersonId


END
GO


