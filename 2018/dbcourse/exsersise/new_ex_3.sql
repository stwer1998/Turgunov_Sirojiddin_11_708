--�������� �����
CREATE LOGIN new_user WITH PASSWORD='new_user';
GO
--������� ������������ ���� ������ ��� �����, ���������� ����.
CREATE USER new_user FOR LOGIN new_user;
GO
--���� ����� �� �������� ��
GRANT CREATE DATABASE TO new_user;
GO
--�������� ��
CREATE DATABASE Filmography;
GO
--������� �������
CREATE TABLE Movies(
Name NVARCHAR(25) NOT NULL,
Description NTEXT,
Year DATE NOT NULL,
Genres NVARCHAR(50),
Country NVARCHAR(30),
Budget MONEY);
GO
CREATE TABLE Actors(
 Surname NVARCHAR(30) NOT NULL,
 Name NVARCHAR(30) NOT NULL,
 Birthday DATE,
 Motherland NVARCHAR(30),
 Number_of_Movie SMALLINT);
GO
CREATE TABLE Producer(
Surname NVARCHAR(30) NOT NULL,
 Name NVARCHAR(30) NOT NULL,
 Birthday DATE,
 Motherland NVARCHAR(30));
 GO
 --��� ������� ���������� ��������� ������ ������������ � ���
 ALTER TABLE Movies ADD PRIMARY KEY(Name,Year);
 GO
 --��� ������� ������� ����� �������, ������� ����� ����������� � ������� ������������������
ALTER TABLE Actors ADD ID INT NOT NULL IDENTITY;
GO 
ALTER TABLE Actors ADD PRIMARY KEY(ID);
GO 
--��� ���������� ��������� ����������
ALTER TABLE Producer ADD ID INT NOT NULL IDENTITY;
GO 
ALTER TABLE Producer ADD PRIMARY KEY(ID);
GO
--����������� ����������� check:
--�� ���� ��� � ������� �����, ��� �� ������ ���� ������ 1900 � ������ ��������
ALTER TABLE Movies 
ADD CONSTRAINT ck_movies_check_date_berween_1974_and_current
CHECK (GETDATE()>"YEAR"AND"Year">'1900-01-01');
GO
--������� ��� � ���� �������� ������ ���� ��� ������ �����������
ALTER TABLE Actors
ADD CONSTRAINT AK_PASSWORD UNIQUE(Name,Surname,Birthday);
GO
--���� ������ �� ������ ���� < 10000
ALTER TABLE Movies
ADD CONSTRAINT ck_movies_check_budget_less_1000
CHECK ("Budget"<1000);
GO
--���� ����� ������� ������ ����� �������� ����� 5
ALTER TABLE Actors
ADD CONSTRAINT ck_actors_check_number_of_Movie_less_5
CHECK("Number_of_Movie">5);
GO
--��� ������� ������� ���� ������ �������� ������ ����� �������� �� ��������� USA.
ALTER TABLE Producer
ADD CONSTRAINT col_birth_def
DEFAULT 'USA' FOR Motherland
GO
	