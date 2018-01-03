CREATE TABLE [kpi].[eDiagram]
(
	DiagramId INT NOT NULL,
	DiagramclassId INT NOT NULL,
	Diagramname NVARCHAR(50) NOT NULL DEFAULT('Diagramname'),
	CONSTRAINT [pkDiagramId] PRIMARY KEY ([DiagramId])
);

