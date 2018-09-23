CREATE PROCEDURE [dbo].[USPProductDelete]
	@id INT
AS
	IF EXISTS (SELECT 1 FROM [OrderProduct] WHERE [ProductId] = @id)
	BEGIN;
		THROW 50001, 'Unable to delete the product, because it already has been sold.', 1;
	END

	DELETE FROM [Product] WHERE [Id] = @id
RETURN 0
