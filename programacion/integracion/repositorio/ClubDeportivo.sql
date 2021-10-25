CREATE DATABASE CLUBDEPORTIVO


USE CLUBDEPORTIVO

CREATE TABLE SOCIO(idSocio numeric(6) identity(1,1) not null,
				   nombre varchar(30) not null,
				   cedula varchar(20) primary key not null,
				   fechaNac dateTime not null,
				   fechaIngreso dateTime not null,
				   activo bit)
				   
CREATE TABLE FUNCIONARIO(idFuncionario numeric(6) identity(1,1) not null,
						 email varchar(30) primary key not null,
						 contrasena varchar(64) not null)

CREATE TABLE PAGOS(idPagos numeric(6) identity(1,1) not null,
				   vigencia dateTime not null,
				   cedula varchar(20),
				   monto money not null)

CREATE TABLE CONFIGURACIONES(CuotaPaseLibre money not null,
							 DescPrefijado decimal(3,2) not null,
							 MaxActivSinDesc int not null,
							 MontoUnitActiv int not null,
							 CantActividades int not null)

DROP TABLE SOCIO
delete  SOCIO
DROP TABLE FUNCIONARIO
DROP TABLE PAGOS
DROP TABLE CONFIGURACIONES

alter table PAGOS
add constraint fk_idCedula foreign key(cedula) references SOCIO(cedula); 


insert into PAGOS values('12/10/2020', '111111', 2200),
			            ('12/11/2021', '222222', 1540);

SET DATEFORMAT DMY

insert into SOCIO values('Mauro','111111','12/02/1999','12/02/2015',1),
						('Lucas','222222','12/02/1998','13/02/2010',0),
						('Lucas','2345678','12/02/1998','13/02/2010',1),
						('Elias','87654332','12/02/1998','13/02/2010',1),
						('Leandro','10101010','12/02/1998','13/02/2010',0),
						('Mauro','555666777','12/02/1998','13/02/2010',0)

insert into FUNCIONARIO values('Leandro','123456'),
							   ('Fernando','789'),
							   ('a@a', '1');

select * from SOCIO



	'mauro@hotmail.com',	'0548b8b464faaa573bd34fe92788b48520a16647b70d3be2e9b76fc16b88206c'
	'maurolink@gmail.com',	'932a1eecf2dbb41da3505f94ca0859028804f88315cbbdff4009a71c16e6b61e'
	'maurolink@hotmail.com',	'ee3475397d1857e7167b893835de44e038a0f989a2da943e60254f318e477c94'
	'TEST@GMAIL.COM',	'0548b8b464faaa573bd34fe92788b48520a16647b70d3be2e9b76fc16b88206c'


