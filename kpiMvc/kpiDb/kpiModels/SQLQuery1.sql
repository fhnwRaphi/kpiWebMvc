CREATE TABLE [kpi].[rDatacollection]
(
	DatacollectionId INT NOT NULL,
	diagramId INT NOT NULL,
	datasetId INT NOT NULL,
	CONSTRAINT [pkDatacollectionId] PRIMARY KEY ([DatacollectionId])
);

