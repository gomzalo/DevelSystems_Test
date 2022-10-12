-- ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
-- :::::::::::::::          CREAR BD            :::::::::::::::
-- ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
CREATE DATABASE ENCUESTAS_DS;
DROP DATABASE ENCUESTAS_DS;
USE ENCUESTAS_DS;
-- ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
-- :::::::::::::::          CREAR TABLAS        :::::::::::::::
-- ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
-- Drops
DROP TABLE respuesta;
DROP TABLE pregunta;
DROP TABLE encuesta;

CREATE TABLE encuesta(
	ID INT IDENTITY(1, 1) PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(200) NOT NULL,
	Link VARCHAR(250)
);

CREATE TABLE pregunta(
	ID INT IDENTITY(1, 1) PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Titulo VARCHAR(50) NOT NULL,
	Tipo VARCHAR(25),
	Requerido CHAR,
	ID_Encuesta INT,
	FOREIGN KEY (ID_Encuesta) REFERENCES encuesta(ID) ON DELETE CASCADE,
);

CREATE TABLE respuesta(
	ID INT IDENTITY(1, 1) PRIMARY KEY,
	ID_Pregunta INT,
	ID_Encuesta INT,
	Respuesta VARCHAR(100) NOT NULL,
	FOREIGN KEY (ID_Pregunta) REFERENCES pregunta(ID) ON DELETE NO ACTION,
	FOREIGN KEY (ID_Encuesta) REFERENCES encuesta(ID) ON DELETE NO ACTION
);