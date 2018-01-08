ALTER TABLE [kpi].[eDelivery]
	ADD CONSTRAINT [fkDeliveryRefCountry]
	FOREIGN KEY ([deliveryId])
	REFERENCES [kpi].[eCountry] (countryId);