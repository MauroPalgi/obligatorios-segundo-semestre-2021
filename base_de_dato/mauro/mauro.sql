Create database METRO

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
				   codigoColor varchar(10))

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
				   fechaHora date)
alter table PASAN
add constraint pk_PASAN primary key(idTren, idEstacion, idLinea);
alter table PASAN
add constraint fk_idTren foreign key(idTren) references TREN(idTren);
alter table PASAN
add constraint fk_idLinea_pasan foreign key(idLinea) references LINEA(idLinea);
alter table PASAN
add constraint fk_idEstacion_pasan foreign key(idEstacion) references ESTACION(idEstacion);

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

/*
2.	Utilizando el lenguaje SQL realizar las siguientes consultas:
*/
/* 
a.	Mostrar numero de línea, descripción, nombre de la estación inicio, nombre de la estación destino y cantidad de estaciones que la componen.
*/
select l.idLinea, l.descripcion, (select ESTACION.nombre from ESTACION where e.idEstacion = ei.idEstacion) as nom_estacion_ini, (select ESTACION.nombre from ESTACION where ESTACION.idEstacion = ef.idEstacion) as nom_estacion_fin, count(lies.idEstacion) as cant_estaciones
from LINEA l,ES_INICIO ei,ES_FINAL ef,ESTACION e, LINEA_ESTACION lies
where l.idLinea = ei.idLinea and
		l.idLinea = ef.idLinea and 
		l.idLinea = lies.idLinea and
		lies.idEstacion = e.idEstacion
group by l.idLinea, l.descripcion, ei.idEstacion, e.idEstacion, ei.idEstacion, ef.idEstacion

/*
b.	Mostrar los datos de la línea que recorre la distancia más larga
*/

select *
from LINEA
where idLinea = (select max(l.longitudTotal)
					from LINEA l)				


/*
3.	Crear procedimientos y/o funciones para poder realizar las siguientes operaciones:
b.	Mediante una función, dado un rango de fechas, retornar el nombre de la estación por la que pasaron más trenes en dicho rango.
*/
go
create function obligatorio_funcion_b
(@desde varchar(10), @hasta varchar(10))
returns varchar(50)
as
begin
	declare @return varchar(50);
	select top 1 @return = e.nombre
	from PASAN p, ESTACION e
	where p.idEstacion = e.idEstacion and
			p.fechaHora > @desde and
			p.fechaHora < @hasta
	group by e.nombre
	order by count(p.idTren) asc
	return @return;
end

go
declare @retornFN varchar(50)
exec @retornFN = dbo.obligatorio_funcion_b '01-01-2021','31-12-2022' 




go
select top 1 e.nombre
from PASAN p, ESTACION e
where p.idEstacion = e.idEstacion and
		p.fechaHora > '01-01-2021' and
		p.fechaHora < '31-12-2022'
group by e.nombre
order by count(p.idTren) asc
	
