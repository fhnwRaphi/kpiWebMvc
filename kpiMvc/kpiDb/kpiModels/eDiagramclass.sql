CREATE TABLE [kpi].[eDiagramclass]
(
	DiagramclassId INT NOT NULL,
	Diagramclass NVARCHAR(20) NOT NULL DEFAULT('Diagramclass'),
	Diagramclassname NVARCHAR(50) DEFAULT('Diagramclassname'),
	CONSTRAINT [pkDiagramclassId] PRIMARY KEY ([DiagramclassId])
);

