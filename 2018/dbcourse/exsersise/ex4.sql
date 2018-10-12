USE Filmography;
GO
--�������� ��� ������� ������ ��������� ����: �������� ����� ����(movie_id)
-- � ��������������� ����� ������������������ ��� ����� ����.
ALTER TABLE Movies DROP CONSTRAINT PK__Movies__3E3E52F29D898EAA
ALTER TABLE Movies ADD Movie_id INT NOT NULL IDENTITY;
ALTER TABLE Movies ADD PRIMARY KEY(Movie_id);
GO
-- �������� �������� �� ��������� ��� ���� ������ �� "UK"
ALTER TABLE Producer DROP CONSTRAINT col_birth_def;
GO
ALTER TABLE Producer
ADD CONSTRAINT col_birth_defalt
DEFAULT 'UK' FOR Motherland
GO
--O����������� ����� ����� ���������, ������� ����������� ���� 
--� ������� (�� ���� ����� ����� ���������� ��������� ������� � ����������).
ALTER TABLE Movies
ADD FOREIGN KEY (Movie_id) REFERENCES Actors (ID)
ON DELETE CASCADE;
GO
ALTER TABLE Movies
ADD FOREIGN KEY (Movie_id) REFERENCES Producer (ID)
ON DELETE CASCADE;
GO
-- �������� � ������� ��������� ����� � �� ������ ������� � ������� ������. 
--ALTER TABLE Producer ADD producer_best_movie INTEGER REFERENCES movies(movie_id);
-- ������� ����������� �� ����� ������ ��� �������.
ALTER TABLE Actors DROP CONSTRAINT ck_actors_check_number_of_Movie_less_5;
GO
--�������� ����������� �� ������ ������: ���� ������ �� ������ ���� < 1000
ALTER TABLE Movies DROP CONSTRAINT ck_movies_check_budget_less_1000;
ALTER TABLE Movies
ADD CONSTRAINT ck_movies_check_budget_more_1000
CHECK ("Budget">1000);
GO
-- �������� ����� � ��������� �������, ������������ ������������ �����.
ALTER TABLE Movies DROP COLUMN Genres;
CREATE TABLE Genres(
Genres NVARCHAR(50),
Genres_ID INT NOT NULL);
GO
ALTER TABLE Genres ADD PRIMARY KEY (Genres_ID)
ALTER TABLE Movies
ADD FOREIGN KEY (Movie_id) REFERENCES Genres(Genres_ID);
GO


