﻿CREATE TABLE [dbo].[Product]
(
	[Id]			INT				NOT NULL IDENTITY,
	[Name]			NVARCHAR(MAX)	NOT NULL,
	[Description]	NVARCHAR(MAX)	NULL,
	[Price]			MONEY			NOT NULL

	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
)
