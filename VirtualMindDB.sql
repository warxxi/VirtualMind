use master
go

if exists(select 1 from sys.databases db where db.name='virtualmind') begin	drop database virtualmind end 
create database virtualmind

go

use virtualmind
go

if exists(select 1 from sys.tables t where t.name='User') begin	drop table "User" end 
create table "User"(
	id int identity(1,1) primary key,
    nombre varchar(100),
    apellido varchar(100),
    email varchar(100),
    password varchar(100)
)

insert into "User" (nombre,apellido,email,password) values
	('Walter','Rodriguez','war.dread@gmail.com','123456'),
	('Ana','Toro','atoro@mail.com','123456atoro'),
	('Carlos','Marin','cmarin@mail.com','123456cmarin'),
	('Ricardo','San Martin','rsanmartin@mail.com','123456rsanmartin'),
	('Paul','Fernandez','pfernandez@mail.com','123456pfernandez'),
	('Martin','Dominguez','mdominguez@mail.com','123456mdominguez'),
	('Pablo','Amurrio','pamurrio@mail.com','123456pamurrio'),
	('Nahuel','Ortelli','nortielli@mail.com','123456nortielli'),
	('Alejandro','Sessa','asessa@mail.com','123456asessa'),
	('Oscar','Lamas','olamas@mail.com','123456olamas')

go