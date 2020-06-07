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
		AddressHome NVARCHAR(20) NOT NULL,
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

---------------------------------------------------------------------


CREATE TABLE Invoice
(
	Invoice_ID INT NOT NULL, 
	SaleDate DATE NOT NULL, 
	DueDate DATE NOT NULL,
	InvoiceType NVARCHAR(7) NULL,
	Cedula NVARCHAR(11) NOT NULL,
	SubTotal DECIMAL DEFAULT 0,
	Total_IVA DECIMAL DEFAULT 0, 
	Total Decimal DEFAULT 0
);


CREATE PROC insert_invoice

	@Invoice_ID INT,
	@SaleDate DATE, 
	@DueDate DATE,
	@InvoiceType NVARCHAR(7),
	@Cedula NVARCHAR(11),
	@SubTotal DECIMAL,
	@Total_IVA DECIMAL, 
	@Total DECIMAL
	
AS
	INSERT INTO Invoice(Invoice_ID, SaleDate, DueDate,InvoiceType, Cedula, SubTotal, Total_IVA, Total) 
				VALUES (@Invoice_ID, @SaleDate, @DueDate,@InvoiceType, @Cedula, @SubTotal, @Total_IVA, @Total);
GO



CREATE TABLE InvoiceDetail
(
	Quantity FLOAT NOT NULL, 
	Discount FLOAT DEFAULT 0,
	IVA DECIMAL DEFAULT 0,
	product_ID NVARCHAR(3) NOT NULL,
	Invoice_ID INT NOT NULL,
	TolalDetail DECIMAL DEFAULT 0
);

CREATE PROC insert_InvoiceDetail

	@Quantity FLOAT,
	@Discount FLOAT,
	@IVA DECIMAL,
	@product_ID NVARCHAR(3),
	@Invoice_ID INT,
	@TolalDetail DECIMAL

	
AS

 DECLARE @InvoiceType NVARCHAR(7)

	INSERT INTO InvoiceDetail(Quantity,Discount,IVA,product_ID,Invoice_ID,TolalDetail)
				  VALUES(@Quantity, @Discount, @IVA, @product_ID, @Invoice_ID, @TolalDetail);

  EXEC @InvoiceType = returnInvoiceType @Invoice_ID

  EXEC modify_warehouse_quantity @Quantity,@InvoiceType,@product_ID
    
GO

DROP PROC insert_InvoiceDetail;

CREATE FUNCTION returnInvoiceType(@InvoiceID INT)
RETURNS NVARCHAR
AS
BEGIN
 DECLARE @invoiceType NVARCHAR(7)
 SET @invoiceType = (SELECT InvoiceType FROM Invoice WHERE Invoice_ID  = @InvoiceID)

RETURN @invoiceType
END;

CREATE PROC modify_warehouse_quantity
@Quantity FLOAT,
@InvoiceType NVARCHAR,
@product_ID	 NVARCHAR(3)
AS
  IF  @InvoiceType = 'Compra' 
	UPDATE Products SET Quantity = (Quantity + @Quantity) WHERE ID = @product_ID
	
 ELSE
	UPDATE Products SET Quantity = (Quantity -  @Quantity) WHERE ID = @product_ID
 
GO