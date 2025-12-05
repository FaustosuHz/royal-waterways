CREATE DATABASE EMPRESA

USE EMPRESA

--DDL

CREATE TABLE maquinas_especificas(
  tipoId CHAR(6) PRIMARY KEY CHECK (tipoId LIKE '[A-Z][A-Z][A-Z][0-9][0-9][0-9]'),
  maquinaDescripcion VARCHAR(30) NOT NULL
);

CREATE TABLE maquinas(
  maquinaId INT IDENTITY(100,1) PRIMARY KEY,
  marca VARCHAR(20) NOT NULL,
  modelo VARCHAR(20) NOT NULL,
  anioFabricacion INT NOT NULL CHECK (anioFabricacion BETWEEN 1900 AND 2025),
  maquinaDescripcion VARCHAR(30) NOT NULL,
  consumoCombustible_L FLOAT,
  tipoId CHAR(6) NOT NULL,
  FOREIGN KEY (tipoId) REFERENCES maquinas_especificas(tipoId)
);

CREATE TABLE mecanicos(
  idMecanico CHAR(6) PRIMARY KEY,
  ci CHAR(8) NOT NULL,
  nombre VARCHAR(20) NOT NULL,
  apellido VARCHAR(20),
  fechaNacimiento DATE,
  telefono VARCHAR(15)
);

CREATE TABLE mecGenerales(
  idMecanico CHAR(6) PRIMARY KEY,
  FOREIGN KEY (idMecanico) REFERENCES mecanicos(idMecanico)
);

CREATE TABLE mecEspecialista(
  idMecanico CHAR(6) PRIMARY KEY,
  FOREIGN KEY (idMecanico) REFERENCES mecanicos(idMecanico)
);

CREATE TABLE especialidades(
  idEspecialidad INT IDENTITY(200,1) PRIMARY KEY,
  especialidadDescripcion VARCHAR(20) NOT NULL
);

CREATE TABLE mecEspecialista_Especialidad (
  idEspecialidad INT,
  idMecanico CHAR(6),
  PRIMARY KEY (idEspecialidad, idMecanico),
  FOREIGN KEY (idEspecialidad) REFERENCES especialidades(idEspecialidad),
  FOREIGN KEY (idMecanico) REFERENCES mecEspecialista(idMecanico)
);

CREATE TABLE repuestos(
  repuestoId CHAR(5) PRIMARY KEY CHECK (repuestoId LIKE '[A-Z][A-Z][A-Z][A-Z][A-Z]'),
  stock INT CHECK (stock >= 0),
  descripcionRepuestos VARCHAR(20) NOT NULL
);

CREATE TABLE procedenciaRepuestos(
  repuestoId CHAR(5),
  pais VARCHAR(25) NOT NULL,
  PRIMARY KEY (repuestoId, pais),
  FOREIGN KEY (repuestoId) REFERENCES repuestos(repuestoId)
);

CREATE TABLE repuestoCompatible (
  repuestoId1 CHAR(5),
  repuestoId2 CHAR(5),
  PRIMARY KEY (repuestoId1, repuestoId2),
  FOREIGN KEY (repuestoId1) REFERENCES repuestos(repuestoId),
  FOREIGN KEY (repuestoId2) REFERENCES repuestos(repuestoId)
);

CREATE TABLE mantenimientos(
  idMecanico CHAR(6),
  maquinaId INT,
  fechaInicio DATE,
  fechaFinalizacion DATE,
  horaInicio TIME,
  horaFinalizacion TIME,
  PRIMARY KEY (idMecanico, maquinaId, fechaInicio),
  FOREIGN KEY (idMecanico) REFERENCES mecanicos(idMecanico),
  FOREIGN KEY (maquinaId) REFERENCES maquinas(maquinaId)
);

CREATE TABLE mantenimientoRepuestos(
  idMecanico CHAR(6),
  maquinaId INT,
  repuestoId CHAR(5),
  cantidad INT,
  PRIMARY KEY (idMecanico, maquinaId, repuestoId),
  FOREIGN KEY (idMecanico) REFERENCES mecanicos(idMecanico),
  FOREIGN KEY (maquinaId) REFERENCES maquinas(maquinaId),
  FOREIGN KEY (repuestoId) REFERENCES repuestos(repuestoId)
);

CREATE TABLE registros (
  idMecanico CHAR(6),
  maquinaId INT,
  fechaInicio DATE,
  nroRenglon INT,
  detalle VARCHAR(100) NOT NULL,
  PRIMARY KEY (idMecanico, maquinaId, fechaInicio, nroRenglon),
  FOREIGN KEY (idMecanico, maquinaId, fechaInicio) REFERENCES mantenimientos(idMecanico, maquinaId, fechaInicio)
);