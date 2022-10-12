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
	Nombre VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(200),
	Link VARCHAR(250),
	PRIMARY KEY (Nombre)
);

CREATE TABLE pregunta(
	Nombre VARCHAR(100) NOT NULL,
	Titulo VARCHAR(50) NOT NULL,
	Tipo VARCHAR(25),
	Requerido CHAR,
	Nombre_Encuesta VARCHAR (100) NOT NULL,
	FOREIGN KEY (Nombre_Encuesta) REFERENCES encuesta(Nombre) ON DELETE CASCADE,
	PRIMARY KEY (Nombre, Nombre_Encuesta)
);

CREATE TABLE respuesta(
	Nombre_Pregunta VARCHAR(100) NOT NULL,
	Nombre_Encuesta VARCHAR(100) NOT NULL,
	Respuesta VARCHAR(100) NOT NULL,
	FOREIGN KEY (Nombre_Pregunta, Nombre_Encuesta) REFERENCES pregunta(Nombre, Nombre_Encuesta) ON DELETE CASCADE,
	PRIMARY KEY (Nombre_Pregunta, Nombre_Encuesta)
);