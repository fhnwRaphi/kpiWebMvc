ALTER TABLE [kpi].[eKvp]
	ADD CONSTRAINT [fkKvpRefKvpClass]
	FOREIGN KEY ([kvpClassId])
	REFERENCES [kpi].[eKvpClass] ([kvpClassId]);