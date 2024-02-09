-- Task1
SELECT RequiredDate, ShippedDate
FROM Orders
WHERE RequiredDate<ShippedDate;
--Task2
SELECT Distinct EmployeeID, Country
FROM Employees;
--Task3
SELECT CONCAT(FirstName,' ',LastName) as FullName
FROM Employees
WHERE ReportsTo is NULL;
--Task4
SELECT ProductName
FROM Products
WHERE Discontinued = 'True';
--Task5
SELECT OrderID, ProductID
FROM [Order Details]
WHERE Discount = 0;
--Task6
SELECT ContactName
FROM Customers
WHERE Region is NULL;
--Task7
SELECT ContactName, Phone
FROM Customers
WHERE Country = 'USA' or Country = 'UK';

--Task8
SELECT CompanyName
FROM Suppliers
WHERE HomePage is not NULL;
--Task9
SELECT Distinct ShipCountry
FROM Orders
WHERE OrderDate like '%1997%';
--Task10
SELECT CustomerID
FROM Orders
WHERE ShippedDate is NULL;
--Task11
SELECT SupplierID, CompanyName, City
FROM Suppliers;

--Task12
SELECT COUNT(Distinct Country) as TotalCount
From Employees;

SELECT *
FROM Employees
WHERE City = 'London';

--Task13
SELECT ProductName
FROM Products
WHERE Discontinued = 'False';

--Task14
SELECT OrderID, ProductID
FROM [Order Details]
WHERE Discount <= 0.1;

--Task15
SELECT EmployeeID, CONCAT(FirstName,' ', LastName) as FullName, CONCAT(Extension, ' ', HomePhone) as ContactNumber
FROM Employees
WHERE Region is Null;