CREATE TYPE [dbo].[MakeOrderProductType] AS TABLE
(
	[Id]		INT NOT NULL,
	[Discount]	MONEY NOT NULL,
	[Quantity]	INT NOT NULL
)
