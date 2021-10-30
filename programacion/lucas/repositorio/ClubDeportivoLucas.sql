/*SCRIPT CREACION DE TABLAS E INSERT
LUCAS 241668
LEANDRO 247916
MAURO */
CREATE DATABASE CLUBDEPORTIVO
USE CLUBDEPORTIVO
CREATE TABLE SOCIO(idSocio numeric(6) identity(1,1) not null,
				   nombre varchar(30) not null,
				   cedula varchar(20) primary key not null,
				   fechaNac dateTime not null,
				   fechaIngreso dateTime not null,
				   activo bit
				   )
				   
CREATE TABLE FUNCIONARIO(idFuncionario numeric(6) identity(1,1) not null,
						 email varchar(30) primary key not null,
						 contrasena varchar(64) not null)

CREATE TABLE PAGOS(idPagos numeric(6) identity(1,1) not null,
				   fchPago dateTime not null,
				   cedula varchar(20),
				   monto decimal(10,2) not null)

CREATE TABLE CONFIGURACIONES(CuotaPaseLibre decimal(5,2) not null ,
							 DescPrefijado decimal(3,2) not null,
							 MaxActivSinDesc int not null,
							 MontoUnitActiv decimal(5,2) not null)
CREATE TABLE ACTIVIDADES(CodigoAct numeric not null,
						 Nombre varchar(30) not null,
						 HoraComienzo DateTime not null,
						 CupoActual numeric(4) not null,
						 CupoTotal numeric(4) not null,
						 MinEdad numeric(2) not null,
						 MaxEdad numeric(2) not null)

CREATE TABLE INGRESOACT(CodigoAct numeric not null, 
						cedula varchar(20) not null,
						fecha DateTime not null)

alter table PAGOS
add constraint fk_idCedula foreign key(cedula) references SOCIO(cedula); 

alter table ACTIVIDADES
add constraint pk_CodigoAct primary key(CodigoAct); 

alter table INGRESOACT
add constraint fk_idCedula foreign key(Cedula) references SOCIO(cedula); 


SET DATEFORMAT DMY
------------INSERT
/*
insert into SOCIO values('Mauro','111111','12/02/1999','12/02/2015',1),
				        ('Lucas','222222','12/02/1994','13/02/2010',0),
						('Leandro','333333','12/02/1996','13/02/2010',1),
						('Fernando','444444','12/02/1996','13/02/2010',1);

insert into FUNCIONARIO values('Leandro','123456'),
							   ('Fernando','789');


insert into CONFIGURACIONES values(120.00, 0.15, 2, 100.00);

insert into ACTIVIDADES values(10, 'Funcional', '11-10-2021 14:00', 11, 20, 5, 40),
							  (20, 'Funcional', '11-10-2021 14:00', 11, 20, 5, 40),
							  (30, 'Funcional2', '11-11-2021 11:00', 11, 20, 5, 40);

insert into INGRESOACT values(20,'222222', '11-10-2021 14:00'),
						     (30,'111111', '10-10-2021 14:00'),
							 (10,'333333', '09-10-2021 14:00'),
							 (30,'444444', '08-10-2021 14:00');
insert into INGRESOACT values(20,'222222', GETDATE());
select CodigoAct from INGRESOACT where cedula=222222 AND DAY(fecha) <= 29 AND DAY(fecha) >= 27
*/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECT_ACTIVIDADESById]
	(
		@Id int
	)
	
AS
select * from ACTIVIDADES where CodigoAct=@Id
-------
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECT_ALL_ACTIVIDADES]
		
AS
select * from ACTIVIDADES

-----

select * from FUNCIONARIO

/*
	'mauro@hotmail.com',	'0548b8b464faaa573bd34fe92788b48520a16647b70d3be2e9b76fc16b88206c'
	'maurolink@gmail.com',	'932a1eecf2dbb41da3505f94ca0859028804f88315cbbdff4009a71c16e6b61e'
	'maurolink@hotmail.com',	'ee3475397d1857e7167b893835de44e038a0f989a2da943e60254f318e477c94'
	'TEST@GMAIL.COM',	'0548b8b464faaa573bd34fe92788b48520a16647b70d3be2e9b76fc16b88206c'


	*/
select * from SOCIO
/*datos prueba*/

insert into ACTIVIDADES values(20, 'FUNCIONAL', '29-10-2021 14:00', 11, 20, 10, 40),
							  (21, 'BOXEO', '29-10-2021 11:00', 18, 20, 15, 30),
							  (22, 'ACROBATICO', '29-10-2021 10:00', 25, 30, 5, 40),
							  (23, 'GIMANSIA AEROBICA', '29-10-2021 15:00', 02, 20, 5, 20),
							  (24, 'GIMANSIA ARTISTICA', '29-10-2021 16:00', 10, 20, 8, 30),
							  (25, 'GIMANSIA RITMICA', '29-10-2021 09:00', 20, 20, 15, 40),
							  (26, 'TRAMPOLIN', '29-10-2021 08:00', 20, 20, 15, 40),
							  (27, 'BASQUETBOL', '29-10-2021 17:00', 11, 15, 5, 35),
							  (27, 'BAILE', '29-10-2021 18:00', 08, 25, 5, 80),
							  (28, 'NATACION', '29-10-2021 19:00', 04, 15, 09, 25);

insert into SOCIO values('Mauro','12121212','12/02/1999','12/02/2015',1),
				        ('Lucas','34343434','12/02/2003','01/02/2019',0),
						('Leandro','56565656','12/02/2015','13/02/2010',1),
						('Fernando','78787878','12/02/1978','15/07/2020',1),
						('Mario','91919191','12/02/1999','13/02/2021',1);

insert into PAGOS values('12/10/2020', '12121212', 260.00),
					    ('12/11/2020', '12121212', 460.00),
			            ('12/12/2020', '12121212', 900.00),
						('15/08/2021', '34343434', 260.00),
					    ('15/09/2021', '34343434', 460.00),
			            ('15/10/2021', '34343434', 900.00),
						('03/05/2021', '78787878', 350.00),
					    ('03/06/2021', '78787878', 460.00),
			            ('03/07/2021', '78787878', 350.00),
						('03/08/2021', '78787878', 600.00);

insert into INGRESOACT values(20,'12121212', '11-10-2021 14:00'),
						     (30,'34343434', '10-10-2021 11:00'),
							 (10,'56565656', '01-10-2021 15:00'),
							 (30,'78787878', '11-10-2021 16:00'),
							 (30,'78787878', '08-09-2021 08:00'),
							 (30,'91919191', '08-02-2021 09:00');

insert into FUNCIONARIO values('Leandro@gmail.com','aefd843245aacf390df832f2d491dc0c199d20aef0cf53572ed106ff5082dd8e'),
							   ('Lucas@gmail.com','aefd843245aacf390df832f2d491dc0c199d20aef0cf53572ed106ff5082dd8e'),
							   ('Mauro@gmail.com','aefd843245aacf390df832f2d491dc0c199d20aef0cf53572ed106ff5082dd8e'); /*PASSWORD: Hola123*/

insert into CONFIGURACIONES values(120.00, 0.15, 2, 100.00);