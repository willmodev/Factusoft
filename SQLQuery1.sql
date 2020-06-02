---------------------Se crea la Base De Datos---------------------------

CREATE DATABASE Factusoft;

---------------------Se crea la tabla Products--------------------------

CREATE TABLE Products(
ID NVARCHAR(3) NOT NULL,
Name NVARCHAR(30) NOT NULL,
UnitValue DECIMAL(10,2) NOT NULL,
UnitMeasure NVARCHAR(3) NOT NULL,
Quantity FLOAT NOT NULL,
IVA DECIMAL(4,1) NOT NULL

);

ALTER TABLE Productos ADD CONSTRAINT PK_Productos_ID PRIMARY KEY CLUSTERED (ID);

--------------------Se crea la tabla Clients------------------------------

CREATE TABLE Clients
(
	            FirstName NVARCHAR(15) NOT NULL,
                secondName NVARCHAR(15)NOT NULL,
                LastName NVARCHAR(15) NOT NULL,
                SecondLastName NVARCHAR(15) NOT NULL,
                Cedula NVARCHAR(11) NOT NULL,
                Sex CHAR(1) NOT NULL,
                DateOfBorn DATE NOT NULL,
                Age INT NOT NULL,
                Telephone NVARCHAR(11) NOT NULL,
                E_mail NVARCHAR(30) NOT NULL,
		Address_ID INT DEFAULT 0,
)


ALTER TABLE Clients ADD CONSTRAINT PK_Client_cedula PRIMARY KEY (Cedula);

------------------------Se cera la tabla Address--------------------------
CREATE TABLE Address
 (
	Address_ID INT NOT NULL,
	AddressHome NVARCHAR(10) NOT NULL,
	Neighborhood NVARCHAR(15) NOT NULL,
	City NVARCHAR(15) NOT NULL,
	Cedula NVARCHAR(11) NOT NULL
 
 )

-------------------------Se crea procedimiento para guardar un cliente----------------------------
CREATE PROC insert_client

	@FirstName NVARCHAR(15),
	@secondName NVARCHAR(15),
	@LastName NVARCHAR(15) ,
	@SecondLastName NVARCHAR(15),
	@Cedula NVARCHAR(11),
	@Sex CHAR(1),
	@DateOfBorn DATE ,
	@Age INT ,
	@Telephone NVARCHAR(11) ,
	@E_mail NVARCHAR(30)
AS
  INSERT INTO Clients VALUES(@FirstName,@secondName, @LastName, @SecondLastName,@Cedula, @Sex, @DateOfBorn,@Age,@Telephone, @E_mail,NULL );
GO

-------------------------Se crea una secuencia para el Address_ID de la tabal Address--------------------

 CREATE SEQUENCE sec_address  MINVALUE 1 START WITH 1 INCREMENT BY  1  NO CYCLE;


-------------------------Se crea procedimiento para guardar Address----------------------------
 CREATE PROC insert_address

 @AddressHome NVARCHAR(10),
 @Neighborhood NVARCHAR(15),
 @City NVARCHAR(15),
 @Cedula NVARCHAR(11)
 AS
    INSERT INTO Address VALUES(NEXT VALUE FOR sec_address,@AddressHome,@Neighborhood,@City,@Cedula)
 GO


-------------------------Se crea trigger(disparador) que inserta el Address_ID correspondiente en la tabla Clients----------------------------
CREATE OR ALTER  TRIGGER update_address_id_client
 ON Address
 AFTER INSERT
 AS
BEGIN
	DECLARE @NewAddress_ID INT, @NewCedula INT;

	SELECT @NewAddress_ID  = Address_ID  FROM INSERTED;
	SELECT @NewCedula  = Cedula  FROM INSERTED;

	
	UPDATE Clients SET Address_ID = @NewAddress_ID  WHERE Cedula = @NewCedula;

END;