Create database METRO
use METRO

/*RNE 
-ES_INICIO, ES_FINAL -> Cada linea tiene dos estaciones como inicio y final que no se pueden
repetir.
- VAGON ->cantidadAsientos en cada vagos es max40

- TREN -> letraIdentificadora es una letra unica, que nose repite

- ESTACION -> el atributo nombreBarrio no puede ser null

- LINEA -> longitudTotal no puede ser menor a 1

- LINEA -> codigoColor puede ser solamente de los colores (rojo, azul, amarillo, naranja, verde y negro)

*/


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
