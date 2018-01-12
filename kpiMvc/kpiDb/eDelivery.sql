CREATE TABLE [kpi].[eDelivery]
(
	[deliveryId] INT NOT NULL IDENTITY(1,1),
	[orderDate] DATE NOT NULL DEFAULT GETDATE(),
	[orderedPc] INT NOT NULL DEFAULT 0,
	[deliveredPc] INT NOT NULL DEFAULT 0,
	[countryId] INT NOT NULL DEFAULT 0,
	CONSTRAINT pkDeliveryId PRIMARY KEY (deliveryId)
)
