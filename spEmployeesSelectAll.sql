USE [AdventureWorks2014]
GO
/****** Object:  StoredProcedure [dbo].[spEmployeesSelectAll]    Script Date: 27/10/2022 9:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- Test:		EXEC [dbo].[spEmployeesSelectAll]
-- =============================================
ALTER PROCEDURE [dbo].[spEmployeesSelectAll] 
	-- Add the parameters for the stored procedure here
	
AS

	SELECT 
		LastName,
		FirstName,
		Title,
		BirthDate,
		HireDate,
		[Address],
		City,
		Region,
		PostalCode,
		Country,
		HomePhone
	FROM Employees
	ORDER BY LastName,FirstName

