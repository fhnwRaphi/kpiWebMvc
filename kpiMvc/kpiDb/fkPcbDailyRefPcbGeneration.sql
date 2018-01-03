ALTER TABLE [kpi].[ePcbDaily]
	ADD CONSTRAINT [fkPcbDailyRefPcbGeneration]
	FOREIGN KEY ([pcbGenerationId])
	REFERENCES [kpi].[ePcbGEneration] ([pcbGenerationId]);