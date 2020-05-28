
CREATE DATABASE Factusoft;

CREATE TABLE Productos(
ID NVARCHAR(3) NOT NULL,
Nombre NVARCHAR(30) NOT NULL,
ValorUnitario DECIMAL(10,2) NOT NULL,
UnidadMedida NVARCHAR(3) NOT NULL,
CantidadBodega FLOAT NOT NULL,
IVA DECIMAL(4,1) NOT NULL

);

ALTER TABLE Productos ADD CONSTRAINT PK_Productos_ID PRIMARY KEY CLUSTERED (ID);


select * from Productos;

drop table Productos ;

commit;