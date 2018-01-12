ALTER TABLE [kpi].[eDelivery]
	ADD CONSTRAINT [fkDeliveryRefCountry]
	FOREIGN KEY ([countryId])
	REFERENCES [kpi].[eCountry] (countryId);