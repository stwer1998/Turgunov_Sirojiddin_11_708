--USE MASTER;
--GO
CREATE DATABASE Test
ON
---- ������� ���� ������, ��������� �� ������� �������� �����
----� ��������� ������ ������� 2 �����, ������������ �� ��������� ������ 
----(���� �� ��� ����� ������ 200 ��, ���� �� 300 ��, � ����� 20 ��).
PRIMARY(
NAME=Firsthojurnal,
FILENAME='d:\dbcourse\Firsthojurnal.mdf',
SIZE = 200 MB,
MAXSIZE=300 MB,
FILEGROWTH=20 MB),(
NAME=Secondjurnal,
FILENAME='C:\Users\�������������\Documents\Secondjurnal.mdf'),
--��������� ������: ������ ������� �� ������ ����� (� ������ ������ ���� ������ � ����� 
--10 ��, ������ �� ���������, � �� ������ ����� ���������� ������)
FILEGROUP File_group1
(NAME = TestGroup1_dat,
FILENAME = 'C:\Users\�������������\Documents\TestGroup1_dat.ndf',
FILEGROWTH = 10 MB),
FILEGROUP File_group
(NAME = TestGroup2_dat,
FILENAME = 'C:\Users\�������������\Documents\TestGroup2_dat.ndf',
SIZE=10 MB)
--���� ������� ������ �� 15%.
LOG ON
( NAME = Test_log,
    FILENAME = 'D:\TestLog\testlog.ldf',
    FILEGROWTH = 15% ) ;
GO

