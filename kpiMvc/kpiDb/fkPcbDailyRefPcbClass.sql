ALTER TABLE [kpi].[ePcbDaily]
	ADD CONSTRAINT [fkPcbDailyRefPcbClass]
	FOREIGN KEY ([pcbClassId])
	REFERENCES [kpi].[ePcbClass] ([pcbClassId]);