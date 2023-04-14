USE [salesdb]
GO

/****** Object:  StoredProcedure [dbo].[spSalesPerson_Get]    Script Date: 14-04-2023 15:16:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spSalesPerson_Get]
(
	@Id INT = NULL
)
AS
BEGIN
    SELECT  SalesPerson.[Id],
            SalesPerson.[FirstName],
            SalesPerson.[MiddleName],
            SalesPerson.[LastName],
			SalesPerson.CreateByUserId,
			CONCAT(UC.FirstName , ' ', UC.LastName) AS 'CreateByUser',
			[UpdateByUserId], 
			CONCAT(UU.FirstName , ' ', UU.LastName) AS 'UpdateByUser',
			SalesPerson.CreateDate, 
			SalesPerson.UpdateDate
    FROM    [dbo].[SalesPerson]
	INNER JOIN [dbo].[User] UC ON UC.Id = SalesPerson.CreateByUserId
	INNER JOIN [dbo].[User] UU ON UU.Id = SalesPerson.UpdateByUserId
	WHERE
	(SalesPerson.Id = @Id OR @Id IS NULL)

END
GO


