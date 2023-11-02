if DB_ID ('Municipalite') IS NULL
	CREATE DATABASE Municipalite;
GO

USE Municipalite;
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE [name]='Municipalite' AND xtype='U')
	create table Municipalite (
		MunicipaliteId			UNIQUEIDENTIFIER PRIMARY KEY,
		NomMunicipalite			VARCHAR(50) NOT NULL,
		AdresseCourriel			Varchar(50),
		AdresseWeb				Varchar(50),
		DateProchaineElection	DateTime,
);
GO