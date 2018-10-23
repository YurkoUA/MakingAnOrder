CREATE VIEW [dbo].[VW_Orders]
AS

SELECT	[o].[Id],
		[o].[Date],
		SUM(op.[OriginalPrice] - op.[Discount]) AS [TotalPrice],
		SUM(op.[Quantity])						AS [ProductsQuantity]
FROM [Order] AS [o]
JOIN [OrderProduct] AS [op] ON [op].[OrderId] = [o].[Id]
GROUP BY	[o].[Id], 
			[o].[Date]