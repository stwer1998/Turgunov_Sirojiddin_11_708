--USE MASTER;
--GO
CREATE DATABASE Test
ON
---- Описать базу данных, состоящую из четырех файловых групп
----В первичной группе описать 2 файла, разбросанные по различным дискам 
----(один из них имеет размер 200 МБ, рост до 300 МБ, с шагом 20 МБ).
PRIMARY(
NAME=Firsthojurnal,
FILENAME='d:\dbcourse\Firsthojurnal.mdf',
SIZE = 200 MB,
MAXSIZE=300 MB,
FILEGROWTH=20 MB),(
NAME=Secondjurnal,
FILENAME='C:\Users\Администратор\Documents\Secondjurnal.mdf'),
--вторичные группы: каждая состоит из одного файла (в первой группе файл растет с шагом 
--10 МБ, размер не ограничен, а во второй имеет постоянный размер)
FILEGROUP File_group1
(NAME = TestGroup1_dat,
FILENAME = 'C:\Users\Администратор\Documents\TestGroup1_dat.ndf',
FILEGROWTH = 10 MB),
FILEGROUP File_group
(NAME = TestGroup2_dat,
FILENAME = 'C:\Users\Администратор\Documents\TestGroup2_dat.ndf',
SIZE=10 MB)
--Файл журнала растет на 15%.
LOG ON
( NAME = Test_log,
    FILENAME = 'D:\TestLog\testlog.ldf',
    FILEGROWTH = 15% ) ;
GO

