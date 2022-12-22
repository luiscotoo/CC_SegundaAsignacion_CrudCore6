create database crud_mvc;
go
use crud_mvc;
go
create table ingenieros (
id int identity(1,1) primary key,
nombre varchar(50),
edad int,
fecha_nac datetime,
altura decimal(10,2)
)