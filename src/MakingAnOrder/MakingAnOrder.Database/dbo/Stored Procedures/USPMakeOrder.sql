CREATE PROCEDURE [dbo].[USPMakeOrder]
	@products	[MakeOrderProductType] READONLY,
	@orderId	INT OUTPUT
AS
	DECLARE @transactionName NVARCHAR(MAX) = 'USPMakeOrder'

	BEGIN TRANSACTION @transactionName;

	BEGIN TRY
		DECLARE @orderProducts TABLE (
			[ProductId] INT,
			[OriginalPrice] MONEY,
			[Discount] MONEY,
			[Quantity] INT
		)

		INSERT INTO @orderProducts ([ProductId], [Discount], [Quantity])
		SELECT p.[Id], p.[Discount], p.[Quantity]
		FROM @products AS [p]

		INSERT INTO [Order]([Date]) VALUES(GETUTCDATE())
		SET @orderId = SCOPE_IDENTITY()

		UPDATE @orderProducts SET 
			[OriginalPrice] = (SELECT [Price] FROM [Product] WHERE [Id] = [ProductId])
		
		INSERT INTO [OrderProduct]([OrderId], [ProductId], [OriginalPrice], [Discount], [Quantity])
		SELECT @orderId, [ProductId], [OriginalPrice], [Discount], [Quantity]
		FROM @orderProducts

	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION @transactionName;
		END;
		THROW;
	END CATCH;

	IF @@TRANCOUNT > 0
	BEGIN
		COMMIT TRANSACTION @TransactionName;
	END;
RETURN 0
