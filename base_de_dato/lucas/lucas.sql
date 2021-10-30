Create database METRO
/*DROP DATABASE METRO*/
use METRO

drop table ES_FINAL
drop table ES_INICIO
drop table LINEA_ESTACION
drop table PASAN
drop table LINEA
drop table ESTACION
drop table TREN
drop table VAGON

/*RNE 
-ES_INICIO, ES_FINAL -> Cada linea tiene dos estaciones como inicio y final que no se pueden
repetir.
- VAGON ->cantidadAsientos en cada vagos es max40

- TREN -> letraIdentificadora es una letra unica, que nose repite

- ESTACION -> el atributo nombreBarrio no puede ser null

- LINEA -> longitudTotal no puede ser menor a 1

- LINEA -> codigoColor puede ser solamente de los colores (rojo, azul, amarillo, naranja, verde y negro)

*/


/*TABLA LINEA*/
Create Table LINEA(idLinea numeric(2) not null, 
			       descripcion varchar(50), 
				   longitudTotal numeric(4), 
				   codigoColor varchar(10),
				   PC varchar(20) not null,
				   fecha dateTime not null,
				   usuario varchar(20) not null)

alter table LINEA
add constraint pk_LINEA primary key(idLinea);

/*TABLA TREN*/
Create Table TREN(idTren numeric(5) not null,
				  descripcion varchar(50), 
				  letraIdentificadora varchar(1))

alter table TREN
add constraint pk_TREN primary key(idTren);

/*TABLA VAGON*/
Create Table VAGON(idTren numeric(5) not null,
				   cantidadAsientos numeric(2),
				   cantidadVagones numeric(2))
alter table VAGON
add constraint pk_VAGON primary key(idTren);

/*TABLA ESTACION*/				   
Create Table ESTACION(idEstacion numeric(5) not null, 
					  nombre varchar(50) not null,
                      descripcion varchar(50), 
					  nombreBarrio varchar(20) not null)
alter table ESTACION
add constraint pk_ESTACION primary key(idEstacion);

/*TABLA PASAN*/
Create Table PASAN(idTren numeric(5) not null, 
				   idLinea numeric(2) not null,
				   idEstacion numeric(5) not null,
				   fechaHora date not null)
alter table PASAN
add constraint pk_PASAN primary key(idTren, idEstacion, idLinea, fechaHora);
alter table PASAN
add constraint fk_idTren foreign key(idTren) references TREN(idTren);
alter table PASAN
add constraint fk_idLinea_pasan foreign key(idLinea) references LINEA(idLinea);
alter table PASAN
add constraint fk_idEstacion_pasan foreign key(idEstacion) references ESTACION(idEstacion);
drop table PASAN
/*TABLA LINEA_ESTACION*/
Create Table LINEA_ESTACION(idLinea numeric(2) not null, 
                            idEstacion numeric(5) not null)
alter table LINEA_ESTACION
add constraint pk_LINEA_ESTACION primary key(idEstacion, idLinea);
alter table LINEA_ESTACION
add constraint fk_idLinea_linea_estacion foreign key(idLinea) references LINEA(idLinea);
alter table LINEA_ESTACION
add constraint fk_idEstacion_linea_estacion foreign key(idEstacion) references ESTACION(idEstacion);

/*TABLA ES_INICIO*/
Create Table ES_INICIO(idLinea numeric(2) not null, 
                       idEstacion numeric(5) not null)
alter table ES_INICIO
add constraint pk_ES_INICIO primary key(idEstacion, idLinea);
alter table ES_INICIO
add constraint fk_idLinea_inicio foreign key(idLinea) references LINEA(idLinea);
alter table ES_INICIO
add constraint fk_idEstacion_inicio foreign key(idEstacion) references ESTACION(idEstacion);

/*TABLA ES_FINAL*/
Create Table ES_FINAL(idLinea numeric(2) not null, 
                      idEstacion numeric(5) not null)
alter table ES_FINAL
add constraint pk_ES_FINAL primary key(idEstacion, idLinea);
alter table ES_FINAL
add constraint fk_idLinea_final foreign key(idLinea) references LINEA(idLinea);
alter table ES_FINAL
add constraint fk_idEstacion_final foreign key(idEstacion) references ESTACION(idEstacion)


/*DATOS PRUEBA LUCAS*/
INSERT INTO TREN VALUES(12,'TREN ROJO', 'L'),
					   (13,'TREN AZUL', 'M'),
					   (14,'TREN BLANCO', 'P');

INSERT INTO LINEA VALUES(1, 'LINEA CIUDAD1', 50, 'CODIGO1', 'PC1', '20/10/2021', 'USUARIO1');

INSERT INTO ESTACION VALUES(3, 'ESTACION PARIS', 'ESTACION GRANDE', 'BARRIO1', 0),
                           (4, 'ESTACION MADRID', 'ESTACION PEQUEÑA', 'BARRIO3', 0),
					       (2, 'ESTACION BERLIN', 'ESTACION MEDIA', 'BARRIO2', 0);

INSERT INTO PASAN VALUES(13, 1, 4, '14/06/2020'),/*ESTACION-4 4 TRENES EN 2020*/
						(12, 1, 4, '13/05/2020'),
						(13, 1, 4, '14/05/2020'),
						(14, 1, 4, '10/05/2020'),
						(13, 1, 2, '14/08/2020'),/*ESTACION-2 6 TRENES EN 2020*/
						(12, 1, 2, '13/09/2020'),
						(13, 1, 2, '14/10/2020'),
						(14, 1, 2, '10/01/2020'),
						(13, 1, 2, '14/11/2020'),
						(14, 1, 2, '14/09/2020'),
						(12, 1, 3, '13/07/2020'),/*ESTACION-3 4 TRENES EN 2020*/
						(13, 1, 3, '14/08/2020'),
						(14, 1, 3, '10/09/2020'),
						(12, 1, 3, '13/05/2021'),/*ESTACION-3 3 TRENES EN 2021*/
						(13, 1, 3, '14/05/2021'),
						(14, 1, 3, '10/05/2021'),
						(13, 1, 2, '14/05/2021'),/*ESTACION-2 2 TRENES EN 2021*/
						(14, 1, 2, '14/05/2021'),
						(12, 1, 4, '13/05/2021'),/*ESTACION-4 11 TRENES EN 2021*/
						(13, 1, 4, '09/05/2021'),
						(14, 1, 4, '08/05/2021'),
						(13, 1, 4, '01/05/2021'),
						(14, 1, 4, '05/05/2021'),
						(13, 1, 4, '20/05/2021'),
						(14, 1, 4, '21/05/2021'),
						(13, 1, 4, '21/06/2021'),
						(12, 1, 4, '13/02/2021'),
						(13, 1, 4, '14/04/2021'),
						(12, 1, 4, '13/04/2021'),
						(12, 1, 4, '13/10/2021'),
						(13, 1, 4, '14/11/2021'),
						(12, 1, 4, '13/12/2021');

/*2.A 
Mostrar los datos del/los trene/s que pasaron por última vez por una línea-estación*/

SELECT T.idTren, T.letraIdentificadora, T.descripcion 
FROM TREN T, PASAN P 
where T.idTren = P.idTren AND P.fechaHora = (SELECT MAX(fechaHora) from PASAN)

--------------------------------------------------
/*2.B 
Mostrar los datos de las estaciones por las que pasaron más trenes este año que la cantidad promedio de 
trenes que pasaron en el año anterior.*/

SELECT E.idEstacion, E.nombre, E.descripcion, E.nombreBarrio
FROM ESTACION E, PASAN P
WHERE E.idEstacion = P.idEstacion AND YEAR(P.fechaHora) = 2021
GROUP BY E.idEstacion, E.nombre, E.descripcion, E.nombreBarrio
HAVING COUNT(P.idTren) > (select AVG(TABLA.PROM) as promedio 
						  FROM (select count(P.idTren) as PROM
								FROM ESTACION E, PASAN P
								WHERE E.idEstacion = P.idEstacion
								AND YEAR(P.fechaHora) = 2020)TABLA)

SELECT TOP 1 count(P.idTren)
FROM ESTACION E, PASAN P
WHERE E.idEstacion = P.idEstacion AND YEAR(P.fechaHora) = 2021
group by E.idEstacion
order by count(P.idTren) DESC

Select T.idTren
from TREN T, PASAN P, ESTACION E
where T.idTren = P.idTren AND YEAR(P.fechaHora) = 2020
/*muestra los datos de todas las estaciones por las que pasaron mas trenes este año que la cantidad promedio de
trenes que pasaron en todas las estaciones el año anterior.
si intento sacar el from para que use la referencia del from de arriba me dice que necesito group by*/

---------------------------------------------

/*4.A 
Auditar cualquier movimiento que exista en las Lineas, se debe llevar un registro detallado de las inserciones,
modificaciones y borrados, en todos los casos registrar desde que PC se hacen los movimientos, la fecha y la hora, el usuario y 
todos los datos que permitan una correcta auditoria (si son modificaciones que datos se modificaron, que datos había antes, que datos hay 
ahora, etc). La/s estructura/s necesaria para este punto es libre y queda a criterio del alumno.*/
--drop table AUDITORIA_LINEA
Create Table AUDITORIA_LINEA(idAuditoria numeric (5) identity(1,1) not null,
							 idLinea numeric(2) not null,
						     PC varchar(20) not null,
							 fecha dateTime not null,
							 usuario varchar(20) not null,
							 descripcionInsert varchar(50) null,  
							 longTotalInsert numeric(4) null, 
				             codColorInsert varchar(10) null,
							 descDelete varchar(50) null, 
							 longTotalDelete numeric(4) null, 
				             codColorDelete varchar(10) null)
alter table AUDITORIA_LINEA
add constraint PK_idAuditoria primary key(idAuditoria);
alter table AUDITORIA_LINEA
add constraint fk_idLinea foreign key(idLinea) references LINEA(idLinea);
/*AFTER INSERT LINEA*/
--drop trigger ej1A
CREATE TRIGGER ej1A
on LINEA
AFTER INSERT
AS
BEGIN
	insert into AUDITORIA_LINEA (idLinea, PC, fecha, usuario, descripcionInsert, longTotalInsert, codColorInsert)
	select i.idLinea, i.pc, GETDATE(), i.usuario, i.descripcion, i.longitudTotal, i.codigoColor 
	from inserted i, LINEA L
	where i.idLinea = L.idLinea
END
/*AFTER DELETE LINEA*/
--drop trigger ej2A
CREATE TRIGGER ej2A
on LINEA
AFTER DELETE
AS
BEGIN
	insert into AUDITORIA_LINEA (idLinea, PC, fecha, usuario, descDelete, longTotalDelete, codColorDelete)
	select D.idLinea, D.pc, GETDATE(), D.usuario, D.descripcion, D.longitudTotal, D.codigoColor 
	from deleted D
END
/*
prueba funciona DETALLE A VER: no puedo poner idlinea como FK en AUDITORIA_LINEA porque no me deja insertar 

delete from LINEA where idLinea = 5

select * from LINEA
select * from AUDITORIA_LINEA

INSERT INTO LINEA VALUES(5, 'LINEA CIUDAD1', 30, 'CODIGO1', 'PC1', '20/10/2021', 'USUARIO1');
*/

/*AFTER UPDATE LINEA*/
--drop trigger ej3A
CREATE TRIGGER ej3A
on LINEA
AFTER UPDATE
AS
BEGIN
	insert into AUDITORIA_LINEA (idLinea, PC, fecha, usuario, descripcionInsert, longTotalInsert, codColorInsert, descDelete, longTotalDelete, codColorDelete)
	select i.idLinea, i.pc, GETDATE(), i.usuario, i.descripcion, i.longitudTotal, i.codigoColor, D.descripcion, D.longitudTotal, D.codigoColor 
	from inserted i, deleted D
	where i.idLinea = D.idLinea
END
/* PRUEBA FUNCIONA
    update LINEA
	set LINEA.descripcion = 'cambiado'
	where LINEA.idLinea = 2

select * from LINEA
select * from AUDITORIA_LINEA*/
--------------------------------------------
/*4.B
Cada vez que un tren pasa por una estación se debe llevar un registro del acumulado de trenes que pasaron por dicha estación, 
quizá deba crear un campo acumulado para que este punto pueda ser realizado.*/

alter table ESTACION
add acumulado numeric(10);

CREATE TRIGGER ejB
on PASAN
AFTER INSERT
AS
BEGIN
	update ESTACION
	set ESTACION.acumulado = ESTACION.acumulado + 1
	where ESTACION.idEstacion = (SELECT idEstacion from inserted)
END
/* prueba funciona
INSERT INTO PASAN VALUES(13, 1, 2, '18/01/2020');

select * from ESTACION*/