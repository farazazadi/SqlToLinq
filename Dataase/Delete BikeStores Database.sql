/*
--------------------------------------------------------------------
© 2017 sqlservertutorial.net All Rights Reserved
--------------------------------------------------------------------
Name   : BikeStores
Link   : http://www.sqlservertutorial.net/load-sample-database/
Version: 1.0
--------------------------------------------------------------------
*/

USE BikeStores;

-- drop tables
DROP TABLE IF EXISTS Sales.OrderItems;
DROP TABLE IF EXISTS Sales.Orders;
DROP TABLE IF EXISTS Production.Stocks;
DROP TABLE IF EXISTS Production.Products;
DROP TABLE IF EXISTS Production.Categories;
DROP TABLE IF EXISTS Production.Brands;
DROP TABLE IF EXISTS Sales.Customers;
DROP TABLE IF EXISTS Sales.Staffs;
DROP TABLE IF EXISTS Sales.Stores;

-- drop the schemas

DROP SCHEMA IF EXISTS Sales;
DROP SCHEMA IF EXISTS Production;
GO
-- drop the DATABASE

USE master;  
GO  
DROP DATABASE BikeStores;  
GO  