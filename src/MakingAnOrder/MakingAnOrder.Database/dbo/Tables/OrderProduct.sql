CREATE TABLE [dbo].[OrderProduct]
(
	[OrderId]			INT		NOT NULL,
	[ProductId]			INT		NOT NULL,
	[OriginalPrice]		MONEY	NOT NULL,
	[Discount]			MONEY	NOT NULL DEFAULT(0),
	[Quantity]			INT		NOT NULL DEFAULT(1)

	CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED ([OrderId] ASC, [ProductId] ASC),
	CONSTRAINT [FK_OrderProduct_To_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id]),
	CONSTRAINT [FK_OrderProduct_To_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)

GO

CREATE NONCLUSTERED INDEX [IX_OrderProduct_OrderId]
	ON [OrderProduct]([OrderId] ASC)

GO

CREATE NONCLUSTERED INDEX [IX_OrderProduct_ProductId]
	ON [OrderProduct]([ProductId] ASC)
