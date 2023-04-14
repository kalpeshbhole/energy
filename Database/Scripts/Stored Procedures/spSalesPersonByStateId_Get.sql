USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spSalesPersonByStateId_Get]    Script Date: 14-04-2023 15:17:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spSalesPersonByStateId_Get]
(
	@StateId    INT = NULL
)
AS
BEGIN
    SELECT	SalesPerson.[Id],
            SalesPerson.[FirstName],
            SalesPerson.[MiddleName],
            SalesPerson.[LastName],
			SalesPersonRegionXref.IsPrimary,
			SalesPerson.[CreateByUserId],
			CONCAT(UC.FirstName , ' ', UC.LastName) AS 'CreateByUser',
			SalesPerson.[UpdateByUserId], 
			CONCAT(UU.FirstName , ' ', UU.LastName) AS 'UpdateByUser',
			SalesPerson.CreateDate, 
			SalesPerson.UpdateDate
    FROM    [dbo].[SalesPerson]
	INNER JOIN [dbo].[SalesPersonRegionXref] ON SalesPersonRegionXref.SalesPersonId = SalesPerson.Id
	INNER JOIN [dbo].[User] UC ON UC.Id = SalesPerson.CreateByUserId
	INNER JOIN [dbo].[User] UU ON UU.Id = SalesPerson.UpdateByUserId
    WHERE   
	(SalesPersonRegionXref.StateId = @StateId OR @StateId IS NULL);
END
GO


