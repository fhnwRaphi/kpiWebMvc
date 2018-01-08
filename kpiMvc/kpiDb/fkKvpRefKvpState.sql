ALTER TABLE [kpi].[eKvp]
	ADD CONSTRAINT [fkKvpRefKvpState]
	FOREIGN KEY ([kvpStateId])
	REFERENCES [kpi].[eKvpState] ([kvpStateId]);