CREATE DATABASE Condominium;

USE Condominium;

CREATE TABLE User (	Id Int not null auto_increment PRIMARY KEY,	UserName VARCHAR(20),	Password VARCHAR(20));

CREATE TABLE Apartment (
	Id Int not null auto_increment PRIMARY KEY,
	Number INT not null,
	Block VARCHAR(5) null	
);

CREATE TABLE Dweller (
	Id Int not null auto_increment PRIMARY KEY,
	Name VARCHAR(40) NOT NULL,
	BirthDate DateTime NULL,
	Telephone VARCHAR(15) NULL,
	CPF VARCHAR(15) NOT NULL,
	Email VARCHAR(40) NULL,
	ApartmentId int NOT NULL,
	CONSTRAINT FK_Dweller_Apartment FOREIGN KEY(ApartmentId) REFERENCES Apartment(Id)
);

INSERT INTO User(UserName,Password) VALUES ('admin','password');