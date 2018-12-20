--create database Db_Commpressor


--CREATE TABLE Doctype(
--ID INT NOT NULL IDENTITY PRIMARY KEY,
--Doctype NVARCHAR(20) NOT NULL);

--CREATE TABLE Mytype(
--ID INT NOT NULL IDENTITY PRIMARY KEY,
--Mytype NVARCHAR(20) NOT NULL)

--CREATE TABLE Converter(
--ID INT NOT NULL IDENTITY,
--Doctype_ID INT NOT NULL FOREIGN KEY REFERENCES Doctype(ID),
--Mytype_ID INT NOT NULL FOREIGN KEY REFERENCES Mytype(ID))


--CREATE TABLE History_Convert(
--ID INT NOT NULL IDENTITY,
--DateConvert DATE,NameDocument NVARCHAR(50),SizeBefore INT,SizeAfter INT)

--INSERT INTO Doctype(Doctype)
--VALUES ('txt');

--INSERT INTO Mytype(Mytype)
--VALUES ('text');

--INSERT INTO Converter(Doctype_ID,Mytype_ID)
--VALUES (1,1);

INSERT INTO History_Convert(DateConvert,NameDocument,SizeBefore,SizeAfter)
values('2017-03-05 08:03:03','sasa',2,3);





















