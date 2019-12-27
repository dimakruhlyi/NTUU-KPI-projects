CREATE DATABASE Laba4Database2
COLLATE Cyrillic_General_CI_AS



CREATE TABLE Viddil2
(
  Id int PRIMARY KEY IDENTITY,
  Name_department  NVARCHAR(30),
  Descript NVARCHAR(100)
)

CREATE TABLE Posada2
(
  Id int PRIMARY KEY IDENTITY,
  Name_position  NVARCHAR(30),
  Descript NVARCHAR(100),
  Min_salary int,
  Max_salary int
)


CREATE TABLE Employee2
(
  Id int primary key identity,
  FIO NVARCHAR(45),
  Department int REFERENCES Department (ID),
  Position int REFERENCES Position (ID),
  Birthaday Date,
  Manager_code int
)