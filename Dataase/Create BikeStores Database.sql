/*
--------------------------------------------------------------------
© 2017 sqlservertutorial.net All Rights Reserved
--------------------------------------------------------------------
Name   : BikeStores
Link   : http://www.sqlservertutorial.net/load-sample-database/
Version: 1.0
--------------------------------------------------------------------
*/
-- create schemas

CREATE DATABASE	BikeStores;
GO

USE BikeStores;
GO

CREATE SCHEMA Production;
GO

CREATE SCHEMA Sales;
GO

-- create tables
CREATE TABLE Production.Categories (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] VARCHAR (255) NOT NULL
);

CREATE TABLE Production.Brands (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] VARCHAR (255) NOT NULL
);

CREATE TABLE Production.Products (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] VARCHAR (255) NOT NULL,
	BrandId INT NOT NULL,
	CategoryId INT NOT NULL,
	ModelYear SMALLINT NOT NULL,
	Price DECIMAL (10, 2) NOT NULL,
	FOREIGN KEY (CategoryId) REFERENCES Production.Categories (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (BrandId) REFERENCES Production.Brands (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Sales.Customers (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	FirstName VARCHAR (255) NOT NULL,
	LastName VARCHAR (255) NOT NULL,
	Phone VARCHAR (25),
	Email VARCHAR (255) NOT NULL,
	Street VARCHAR (255),
	City VARCHAR (50),
	[State] VARCHAR (25),
	ZipCode VARCHAR (5)
);

CREATE TABLE Sales.Stores (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	[Name] VARCHAR (255) NOT NULL,
	Phone VARCHAR (25),
	Email VARCHAR (255),
	Street VARCHAR (255),
	City VARCHAR (255),
	[State] VARCHAR (10),
	ZipCode VARCHAR (5)
);

CREATE TABLE Sales.Staffs (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	FirstName VARCHAR (50) NOT NULL,
	LastName VARCHAR (50) NOT NULL,
	Email VARCHAR (255) NOT NULL UNIQUE,
	Phone VARCHAR (25),
	IsActive BIT NOT NULL,
	StoreId INT NOT NULL,
	ManagerId INT,
	FOREIGN KEY (StoreId) REFERENCES Sales.Stores (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (ManagerId) REFERENCES Sales.Staffs (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE Sales.Orders (
	Id INT IDENTITY (1, 1) PRIMARY KEY,
	CustomerId INT,
	OrderStatus tinyint NOT NULL,
	-- Order status: 1 = Pending; 2 = Processing; 3 = Rejected; 4 = Completed
	OrderDate DATE NOT NULL,
	RequiredDate DATE NOT NULL,
	ShippedDate DATE,
	StoreId INT NOT NULL,
	StaffId INT NOT NULL,
	FOREIGN KEY (CustomerId) REFERENCES Sales.Customers (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (StoreId) REFERENCES Sales.Stores (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (StaffId) REFERENCES Sales.Staffs (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE Sales.OrderItems (
  Id INT,
	OrderId INT,
	ProductId INT NOT NULL,
	Quantity INT NOT NULL,
	Price DECIMAL (10, 2) NOT NULL,
	Discount DECIMAL (4, 2) NOT NULL DEFAULT 0,
	PRIMARY KEY (OrderId, Id),
	FOREIGN KEY (OrderId) REFERENCES Sales.Orders (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (ProductId) REFERENCES Production.Products (Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Production.Stocks (
	StoreId INT,
	ProductId INT,
	Quantity INT,
	PRIMARY KEY (StoreId, ProductId),
	FOREIGN KEY (StoreId) REFERENCES Sales.Stores (Id) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (ProductId) REFERENCES Production.Products (Id) ON DELETE CASCADE ON UPDATE CASCADE
);