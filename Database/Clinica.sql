USE master;
GO

CREATE DATABASE ClinicaPOO2018;
GO
USE ClinicaPOO2018;
GO

CREATE TABLE Especialidad(
esp_idEspecialidad INT IDENTITY(1,1) PRIMARY KEY,
esp_Especialidad VARCHAR(30) NOT NULL
);

CREATE TABLE Rol(
rol_idRol INT IDENTITY(1,1) PRIMARY KEY,
rol_rol VARCHAR(30) NOT NULL
);

CREATE TABLE Ruta(
rut_idRuta INT IDENTITY(1,1) PRIMARY KEY,
rut_nombre VARCHAR(30) NOT NULL,
rut_ruta VARCHAR(255) NOT NULL
);

CREATE TABLE RutaRol(
rxr_idrxr INT IDENTITY(1,1) PRIMARY KEY,
rxr_idRol INT NOT NULL,
rxr_idRuta INT NOT NULL
FOREIGN KEY(rxr_idRol) REFERENCES Rol(rol_idRol),
FOREIGN KEY(rxr_idRuta) REFERENCES Ruta(rut_idRuta)
);

CREATE TABLE Usuario(
usu_idUsuario INT IDENTITY(1,1) PRIMARY KEY,
usu_usuario VARCHAR(30) NOT NULL,
usu_contrasena VARCHAR(30) NOT NULL,
usu_idRol INT,
FOREIGN KEY(usu_idRol) REFERENCES Rol(rol_idRol)
);

CREATE TABLE Secretaria(
sec_idSecretaria INT IDENTITY(1,1) PRIMARY KEY,
sec_nombre VARCHAR(50) NOT NULL,
sec_apellido VARCHAR (50) NOT NULL,
sec_idUsuario INT,
sec_telefono VARCHAR(30),
sec_direccion VARCHAR(250),
sec_FechaNacimiento DATE,
FOREIGN KEY(sec_idUsuario) REFERENCES Usuario(usu_idUsuario)
);

CREATE TABLE TipoPaciente(
tpa_idTipoPaciente INT IDENTITY(1,1) PRIMARY KEY,
tpa_tipo VARCHAR(30) NOT NULL
);

CREATE TABLE TipoEmpleado(
tem_idTipoEmpleado INT IDENTITY(1,1) PRIMARY KEY,
tem_tipo VARCHAR(30) NOT NULL
);

CREATE TABLE Cargo(
car_idCargo INT IDENTITY(1,1) PRIMARY KEY,
car_cargo VARCHAR(30) NOT NULL
);

CREATE TABLE Resultado(
res_idResultado INT IDENTITY(1,1) PRIMARY KEY,
res_resultado VARCHAR(250) NOT NULL
);

CREATE TABLE Medico(
med_idMedico INT IDENTITY(1,1) PRIMARY KEY,
med_idSecretaria INT,
med_nombre VARCHAR(30) NOT NULL,
med_apellido VARCHAR(30) NOT NULL,
med_idUsuario INT,
med_telefono VARCHAR(30) NOT NULL,
med_direccion VARCHAR(250) NOT NULL,
med_jvpm CHAR(5) NOT NULL,
med_precioConsulta DECIMAL(9,2) NOT NULL,
FOREIGN KEY(med_idSecretaria) REFERENCES Secretaria(sec_idSecretaria),
FOREIGN KEY(med_idUsuario) REFERENCES Usuario(usu_idUsuario)
);

CREATE TABLE Paciente(
pac_idPaciente INT IDENTITY(1,1) PRIMARY KEY,
pac_idTipoPaciente INT NOT NULL,
pac_nombre VARCHAR(30) NOT NULL,
pac_apellido VARCHAR(30) NOT NULL,
pac_idUsuario INT,
pac_DUI VARCHAR(20),
pac_sexo CHAR(1) NOT NULL,
pac_telefono VARCHAR(30),
pac_direccion VARCHAR(250),
pac_fechaNacimiento DATE,
pac_visible BIT NOT NULL,
FOREIGN KEY(pac_idTipoPaciente) REFERENCES TipoPaciente(tpa_idTipoPaciente),
FOREIGN KEY(pac_idUsuario) REFERENCES Usuario(usu_idUsuario)
);

CREATE TABLE HorarioConsulta(
hor_idHorarioConsulta INT IDENTITY(1,1) PRIMARY KEY,
hor_idMedico INT NOT NULL,
hor_dia CHAR(2) NOT NULL,
hor_horario VARCHAR(100) NOT NULL,
FOREIGN KEY(hor_idMedico) REFERENCES Medico(med_idMedico)
);

CREATE TABLE Historial(
his_idHistorial INT IDENTITY(1,1) PRIMARY KEY,
his_idPaciente INT NOT NULL,
his_fecha DATE NOT NULL,
his_contenido INT NOT NULL,
FOREIGN KEY(his_idPaciente) REFERENCES Paciente(pac_idPaciente)
);

CREATE TABLE Cita(
cit_idCita INT IDENTITY(1,1) PRIMARY KEY,
cit_idMedico INT NOT NULL,
cit_idPaciente INT NOT NULL,
cit_fechaCreacion DATE NOT NULL,
cit_fechaCita DATE NOT NULL,
cit_horaCita TIME NOT NULL,
cit_consultaEfectuada BIT NOT NULL,
cit_examenprogramado BIT NOT NULL,
FOREIGN KEY(cit_idMedico) REFERENCES Medico(med_idMedico),
FOREIGN KEY(cit_idPaciente) REFERENCES Paciente(pac_idPaciente)
);

CREATE TABLE Receta(
rec_idReceta INT IDENTITY(1,1) PRIMARY KEY,
rec_idCita INT NOT NULL,
rec_datos VARCHAR(250) NOT NULL,
FOREIGN KEY(rec_idCita) REFERENCES Cita(cit_idCita)
);

CREATE TABLE Empleado(
emp_idEmpleado INT IDENTITY(1,1) PRIMARY KEY,
emp_idTipoEmpleado INT NOT NULL,
emp_nombre VARCHAR(30) NOT NULL,
emp_apellido VARCHAR(30) NOT NULL,
emp_idUsuario INT,
emp_fechaNacimiento DATE,
emp_telefono VARCHAR(30),
emp_idCargo INT,
emp_dui VARCHAR(30) NOT NULL,
FOREIGN KEY(emp_idTipoEmpleado) REFERENCES TipoEmpleado(tem_idTipoEmpleado),
FOREIGN KEY(emp_idCargo) REFERENCES Cargo(car_idCargo),
FOREIGN KEY(emp_idUsuario) REFERENCES Usuario(usu_idUsuario)
);

CREATE TABLE Examen(
exm_idExamen INT IDENTITY(1,1) PRIMARY KEY,
exm_idHistorial INT,
exm_idEmpleado INT,
exm_idResultado INT,
FOREIGN KEY(exm_idHistorial) REFERENCES Historial(his_idHistorial),
FOREIGN KEY(exm_idEmpleado) REFERENCES Empleado(emp_idEmpleado),
FOREIGN KEY(exm_idResultado) REFERENCES Resultado(res_idResultado)
);

CREATE TABLE MedicoEspecialidad(
mes_idMedicoEspecialidad INT IDENTITY(1,1) PRIMARY KEY,
mes_idMedico INT,
mes_idEspecialidad INT,
FOREIGN KEY(mes_idMedico) REFERENCES Medico(med_idMedico),
FOREIGN KEY(mes_idEspecialidad) REFERENCES Especialidad(esp_idEspecialidad)
);

/*INSERTE DATOS DE PRUEBA*/


INSERT INTO Especialidad
(esp_Especialidad)
VALUES
('Cardiólogo');

INSERT INTO Rol
(rol_rol)
VALUES
('Adiministrador General');

INSERT INTO Rol
(rol_rol)
VALUES
('Medico');

INSERT INTO Rol
(rol_rol)
VALUES
('Secretaria');

INSERT INTO Rol
(rol_rol)
VALUES
('Paciente');

INSERT INTO Rol
(rol_rol)
VALUES
('Laboratorista');

INSERT INTO Usuario
(usu_usuario,usu_contrasena,usu_idRol)
VALUES
('LE1','1234',1);

INSERT INTO Usuario
(usu_usuario,usu_contrasena,usu_idRol)
VALUES
('JP1','1234',3);

INSERT INTO Usuario
(usu_usuario,usu_contrasena,usu_idRol)
VALUES
('KM1','1234',2);

INSERT INTO Usuario
(usu_usuario,usu_contrasena,usu_idRol)
VALUES
('JM1','1234',4);

INSERT INTO Usuario
(usu_usuario,usu_contrasena,usu_idRol)
VALUES
('JH1','1234',5);

INSERT INTO Ruta
(rut_nombre,rut_ruta)
values
('Medicos','medicos/Index')

INSERT INTO RutaRol
(rxr_idRol,rxr_idRuta)
values
(1,1);

INSERT INTO Secretaria
(sec_nombre, sec_apellido, sec_idUsuario, sec_telefono, sec_direccion, sec_FechaNacimiento)
VALUES
('Juana','Pérez',2,'77777770','','12-18-1990');

INSERT INTO TipoPaciente
(tpa_tipo)
VALUES
('Interno');

INSERT INTO TipoEmpleado
(tem_tipo)
VALUES
('Administrador general');

INSERT INTO TipoEmpleado
(tem_tipo)
VALUES
('Laboratorista');

INSERT INTO Cargo
(car_cargo)
VALUES
('Supervisor de Laboratorio');

INSERT INTO Resultado
(res_resultado)
VALUES
('Se va a morir, no es cierto XD pH bajo en orina');

INSERT INTO Medico
(med_idSecretaria,med_nombre,med_apellido,med_idUsuario,med_telefono,med_direccion,med_jvpm,med_precioConsulta)
VALUES
(1,'El Kevin','Mata Lozano',3,'77777771','aquí','51254',15.00);

INSERT INTO Paciente
(pac_idtipoPaciente,pac_nombre,pac_apellido,pac_idUsuario,pac_DUI,pac_sexo,pac_telefono,pac_direccion,pac_fechaNacimiento,pac_visible)
VALUES
(1,'Juan','Martínez',4,'12345678-9','H','77777772','allá','08-30-1983',1);

INSERT INTO HorarioConsulta
(hor_idMedico,hor_dia,hor_horario)
VALUES
(1,'LU','De 8:30am a 12:00pm');

INSERT INTO Historial
(his_idPaciente,his_fecha,his_contenido)
VALUES
(1,GETDATE(),12542);

INSERT INTO Cita
(cit_idMedico,cit_idPaciente,cit_fechaCreacion,cit_fechaCita,cit_horaCita,cit_consultaEfectuada,cit_examenprogramado)
VALUES
(1,1,GETDATE(),'11-25-2019','10:30',0,1);

INSERT INTO Receta
(rec_idCita,rec_datos)
VALUES
(1,'Paracetamol 500mg/8h');

INSERT INTO Empleado
(emp_idTipoEmpleado,emp_nombre,emp_apellido,emp_idUsuario,emp_fechaNacimiento,emp_telefono,emp_idCargo,emp_dui)
VALUES
(1,'Adolfo','Enriquez',1,'02-17-1991','77777773',1,'12345679-8');

INSERT INTO Empleado
(emp_idTipoEmpleado,emp_nombre,emp_apellido,emp_idUsuario,emp_fechaNacimiento,emp_telefono,emp_idCargo,emp_dui)
VALUES
(2,'Jorge','Hernández',5,'02-17-1991','77777773',1,'12345679-8');

INSERT INTO Examen
(exm_idHistorial,exm_idEmpleado,exm_idResultado)
VALUES
(1,1,1);

INSERT INTO MedicoEspecialidad
(mes_idMedico,mes_idEspecialidad)
VALUES
(1,1);

/*SELECT TipoEmpleado.tem_idTipoEmpleado FROM TipoEmpleado INNER JOIN Empleado On Empleado.emp_idTipoEmpleado = TipoEmpleado.tem_idTipoEmpleado WHERE Empleado.emp_usuario = 'JH1' AND Empleado.emp_contrasena = '1234';

SELECT * FROM Medico WHERE med_idUsuario = 3;
*/


SELECT usu_idRol FROM Usuario Where usu_usuario = 'JP1' and usu_contrasena = '1234'; 

SELECT Ruta.rut_nombre, Ruta.rut_ruta FROM Ruta inner join RutaRol on RutaRol.rxr_idRuta = Ruta.rut_idRuta where rxr_idRol = 3;

/*CREATE VIEW rutasPorRol AS  SELECT RutaRol.id FROM Medicos;*/

use ClinicaPOO2018;

SELECT Empleado.emp_nombre FROM Usuario
INNER JOIN Empleado ON Empleado.emp_idUsuario = Usuario.usu_idUsuario
WHERE usu_usuario = 'LE1';

SELECT * FROM Usuario;
SELECT * FROM Paciente;
