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
		AddressHome NVARCHAR(10) NOT NULL,
		Neighborhood NVARCHAR(15) NOT NULL,
		City NVARCHAR(15) NOT NULL
)


ALTER TABLE Clients ADD CONSTRAINT PK_Client_cedula PRIMARY KEY (Cedula);

------------------------Se cera la tabla Address--------------------------


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
	@E_mail NVARCHAR(30),
	@AddressHome NVARCHAR(10),
	@Neighborhood NVARCHAR(15),
	@City NVARCHAR(15)
AS
  INSERT INTO Clients VALUES(@FirstName,@secondName, @LastName, @SecondLastName,@Cedula, 
			     @Sex, @DateOfBorn,@Age,@Telephone, @E_mail,@AddressHome,@Neighborhood,@City);
GO


--------------------------Se crea la tabla Administrator----------------------------
CREATE TABLE Administrator(userName NVARCHAR(15),passwordName NVARCHAR(15),Email NVARCHAR(30), passwordEmail NVARCHAR(30));


-----------------Se cera Procedimiento para validar los datos de acceso------------------
CREATE PROC validate_user

@userName NVARCHAR(15),
@passwordName NVARCHAR(15)

AS
		SELECT * FROM Administrator WHERE userName = @userName AND passwordName = @passwordName;
GO