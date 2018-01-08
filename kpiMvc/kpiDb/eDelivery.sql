CREATE TABLE [kpi].[eDelivery]
(
	[deliveryId] INT NOT NULL IDENTITY(1,1),
	[orderDate] DATE NOT NULL DEFAULT GETDATE(),
	[orderedPc] INT NOT NULL DEFAULT 0,
	[deliveredPc] INT NOT NULL DEFAULT 0,
	[notdeliveredPc] AS [orderedPc] - [deliveredPc],
	[notdeliveredRel] AS  (100.0 / CAST([orderedPc] AS FLOAT(4))) * CAST([deliveredPc] AS FLOAT(4)),
	[countryId] INT NOT NULL DEFAULT 0,
	CONSTRAINT pkDeliveryId PRIMARY KEY (deliveryId)
)
