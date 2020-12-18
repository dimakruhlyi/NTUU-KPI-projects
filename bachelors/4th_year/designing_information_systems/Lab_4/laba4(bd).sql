CREATE DATABASE Laba4Database
COLLATE Cyrillic_General_CI_AS




CREATE TABLE Department
(
  Id int PRIMARY KEY IDENTITY,
  Name_department  NVARCHAR(30),
  
)

CREATE TABLE Position
(
  Id int PRIMARY KEY IDENTITY,
  Name_position  NVARCHAR(30),
  Salary int
)


CREATE TABLE Worker
(
  Id int primary key identity,
  FirstName NVARCHAR(20),
    LastName NVARCHAR(20),
  SurName NVARCHAR(20),
  Department int REFERENCES Department (ID),
  Position int REFERENCES Position (ID),
  Identification_number int,
  Series_passport NVARCHAR(20),
  Id_passport int,
)

use Laba4Database2;
select * from Worker;
select * from Position;
select * from Department;