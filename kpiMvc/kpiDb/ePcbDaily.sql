CREATE TABLE [kpi].[ePcbDaily]
(
	[pcbDailyId] INT NOT NULL IDENTITY(1,1),
	[productionDay] DATE NOT NULL DEFAULT GETDATE(),
	[pcbQuantity] INT NOT NULL DEFAULT 0,
	[pcbSumPrice] MONEY NOT NULL DEFAULT 0,
	[pcbGenerationId] INT NOT NULL DEFAULT 0,
	[pcbClassId] INT NOT NULL DEFAULT 0,

	CONSTRAINT [pkPcbDailyId] PRIMARY KEY ([pcbDailyId])
)
