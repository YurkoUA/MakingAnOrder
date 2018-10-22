CREATE PROCEDURE [dbo].[USPGetOrders]
	@orderDateStart DATE = NULL,
	@orderDateEnd	DATE = NULL,

	@offset INT = 0,
	@take	INT = 20,

	@orderByColumn	NVARCHAR(MAX) = 'Id',
	@orderDirection BIT = 1,

	@totalCount INT OUTPUT
AS
	SELECT	-- Order
			o.[Id]									AS [Id],
			o.[Date]								AS [Date],
			SUM(op.[OriginalPrice] - op.[Discount]) AS [TotalPrice],
			SUM(op.[Quantity])						AS [ProductsQuantity],

			-- Product
			p.[Id],
			p.[Name],
			p.[Description],
			op.[OriginalPrice],
			op.[Discount],
			op.[Quantity]

	FROM [Order] AS [o]
	JOIN [OrderProduct] AS [op] ON op.[OrderId] = o.[Id]
	JOIN [Product] AS [p] ON p.[Id] = op.[ProductId]

	WHERE (@orderDateStart IS NULL OR o.[Date] >= @orderDateStart)
			AND (@orderDateEnd IS NULL OR o.[Date] <= @orderDateEnd)
	GROUP BY	o.[Id], 
				o.[Date], 
				op.[OriginalPrice] - op.[Discount], 
				op.[Quantity],

				p.[Id],
				p.[Name],
				p.[Description],
				op.[OriginalPrice],
				op.[Discount],
				op.[Quantity]

	ORDER BY
		CASE WHEN @orderByColumn = 'Id'					AND @orderDirection = 1 THEN o.[Id] END ASC,
		CASE WHEN @orderByColumn = 'Date'				AND @orderDirection = 1 THEN [Date] END ASC,
		CASE WHEN @orderByColumn = 'TotalPrice'			AND @orderDirection = 1 THEN SUM(op.[OriginalPrice] - op.[Discount]) END ASC,
		CASE WHEN @orderByColumn = 'ProductsQuantity'	AND @orderDirection = 1 THEN SUM(op.[Quantity]) END ASC,

		CASE WHEN @orderByColumn = 'Id'					AND @orderDirection = 0 THEN o.[Id] END DESC,
		CASE WHEN @orderByColumn = 'Date'				AND @orderDirection = 0 THEN [Date] END DESC,
		CASE WHEN @orderByColumn = 'TotalPrice'			AND @orderDirection = 0 THEN SUM(op.[OriginalPrice] - op.[Discount]) END DESC,
		CASE WHEN @orderByColumn = 'ProductsQuantity'	AND @orderDirection = 0 THEN SUM(op.[Quantity]) END DESC


	OFFSET @offset ROWS FETCH NEXT @take ROWS ONLY


	SELECT @totalCount = COUNT(*)
	FROM [Order]
	WHERE [Date] BETWEEN @orderDateStart AND @orderDateEnd

RETURN 0
