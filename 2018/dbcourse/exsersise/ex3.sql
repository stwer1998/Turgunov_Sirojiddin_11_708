USE Filmography;
GO
CREATE TABLE Movies(
Name NVARCHAR(25) NOT NULL,
Description NTEXT,
Year DATE NOT NULL,
Genres NVARCHAR(50),
Country NVARCHAR(30),
Budget MONEY);
GO
CREATE TABLE dbo_Actors(
 Surname NVARCHAR(30) NOT NULL,
 Name NVARCHAR(30) NOT NULL,
 Birthday DATE,
 Motherland NVARCHAR(30),
 Number_of_Movie SMALLINT);
GO
CREATE TABLE dbo_Producer(
Surname NVARCHAR(30) NOT NULL,
 Name NVARCHAR(30) NOT NULL,
 Birthday DATE,
 Motherland NVARCHAR(30))
ALTER TABLE Movies ADD PRIMARY KEY(Name,Year);
GO
ALTER TABLE dbo.dbo_Actors ADD ID INT NOT NULL IDENTITY;
GO 
ALTER TABLE dbo.dbo_Actors ADD PRIMARY KEY(ID);
GO 
ALTER TABLE dbo.dbo_Producer ADD ID INT NOT NULL IDENTITY;
GO 
ALTER TABLE dbo.dbo_Producer ADD PRIMARY KEY(ID);
GO
ALTER TABLE dbo.dbo_Actors
ADD CONSTRAINT AK_PASSWORD UNIQUE(Name,Surname,Birthday);
GO
ALTER TABLE dbo.dbo_Producer
ADD CONSTRAINT col_birth_def
DEFAULT 'USA' FOR Motherland
GO
USE Filmography;
GO
INSERT dbo.Movies(Name,description,Year,genres,country,budget)
VALUES('Titanic5','good film','1998-05-12','value','USA',230)
ALTER TABLE dbo.Movies 
ADD CONSTRAINT ck_movies_check_date_berween_1974_and_current
CHECK (GETDATE()>"YEAR"AND"Year">'1900-01-01');
GO
ALTER TABLE dbo.Movies
ADD CONSTRAINT ck_movies_check_budget_less_1000
CHECK ("Budget"<1000);
GO
SELECT * FROM dbo.Movies
INSERT dbo.Movies(Name,description,Year,genres,country,budget)
VALUES('Titanic5','good film','1998-06-12','value','USA',1230)
GO