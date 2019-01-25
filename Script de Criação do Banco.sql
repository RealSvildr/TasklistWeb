CREATE DATABASE Tasklist
GO

USE Tasklist
GO

CREATE TABLE Task (
	TaskID INT NOT NULL IDENTITY (1,1),
	PriorityID INT NOT NULL,
	StatusID INT NOT NULL,
	Name VARCHAR(MAX) NOT NULL,
	Description VARCHAR(MAX) NOT NULL,
	Deleted BIT NOT NULL,
	CreateDate DATETIME NOT NULL,
	DeleteDate DATETIME NULL
)

ALTER TABLE Task ADD CONSTRAINT PK_Task PRIMARY KEY CLUSTERED (TaskID);
GO

CREATE TABLE Status (
	StatusID INT NOT NULL,
	Name VARCHAR(MAX) NOT NULL,
	Description VARCHAR(MAX) NOT NULL
);

ALTER TABLE Status ADD CONSTRAINT PK_Status PRIMARY KEY CLUSTERED (StatusID);
GO

CREATE TABLE Priority (
	PriorityID INT NOT NULL IDENTITY (1,1),
	PriorityLevel INT NOT NULL,
	Name VARCHAR(MAX) NOT NULL,
	Description VARCHAR(MAX) NOT NULL
);

ALTER TABLE Priority ADD CONSTRAINT PK_Priority PRIMARY KEY CLUSTERED (PriorityID);
GO

ALTER TABLE Task ADD CONSTRAINT FK_Task_Priority FOREIGN KEY (PriorityID) REFERENCES Priority (PriorityID)
ALTER TABLE Task ADD CONSTRAINT FK_Task_Status FOREIGN KEY (StatusID) REFERENCES Status (StatusID)
GO

INSERT INTO Status
      SELECT 1, 'Novo', ''
UNION SELECT 2, 'Pendente Aprovação', ''
UNION SELECT 3, 'Aprovado', ''
UNION SELECT 4, 'Em Desenvolvimento', ''
UNION SELECT 5, 'Desenvolvido', ''
UNION SELECT 6, 'Em Teste', ''
UNION SELECT 7, 'Finalizado', ''
UNION SELECT 99, 'Recusado', ''
GO

