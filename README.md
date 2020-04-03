CREATE database TransTest1;
CREATE database TransTest2;
CREATE database TransTest3;


CREATE TABLE TransTest1.dbo.Names (
	Id int IDENTITY(1,1),
	Name nvarchar(100),
	CreatedAt datetime DEFAULT GETDATE(),
	CONSTRAINT Names_PK PRIMARY KEY (Id)
)

CREATE TABLE TransTest2.dbo.Names (
	Id int IDENTITY(1,1),
	Name nvarchar(100),
	CreatedAt datetime DEFAULT GETDATE(),
	CONSTRAINT Names_PK PRIMARY KEY (Id)
)

CREATE TABLE TransTest3.dbo.Names (
	Id int IDENTITY(1,1),
	Name nvarchar(100),
	CreatedAt datetime DEFAULT GETDATE(),
	CONSTRAINT Names_PK PRIMARY KEY (Id)
)
