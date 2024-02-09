--Task1
SELECT ProductName
FROM Products
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);

--Task2
SELECT ShippedDate, Count(*) as orderNumber
FROM Orders
WHERE ShippedDate is not NULL
GROUP BY ShippedDate
Order BY ShippedDate;

--Task3
SELECT Country
FROM Suppliers
Group By Country
Having Count(SupplierID) >= 2;

--Task4
SELECT MONTH(ShippedDate) as [Month Number], COUNT(*) as [Orders Delayed]
FROM Orders
WHERE ShippedDate > RequiredDate
Group By Month(ShippedDate)
Order BY [Month Number];

--Task5
SELECT OrderID as [Order ID], SUM(Discount) as Discount
FROM [Order Details]
WHERE Discount > 0
GROUP BY OrderID
Order BY [Order ID];

--Task6
SELECT ShipCity as [Ship City], COUNT(ShippedDate) as [Number of Orders]
FROM Orders
WHERE ShipCountry = 'USA' and YEAR(ShippedDate) = 1997
GROUP BY ShipCity
Order By [Number of Orders];

--Task7
SELECT ShipCountry as Country, COUNT(*) as [Orders Delayed]
FROM Orders
WHERE ShippedDate > RequiredDate
GROUP BY ShipCountry
Order BY [Orders Delayed] DESC;

--Task8
SELECT OrderID, Sum(Discount) as Discount, SUM(UnitPrice * Quantity) as [Total Price]
FROM [Order Details]
WHERE Discount > 0
GROUP BY OrderID
Order BY OrderID;

--Task9
SELECT ShipRegion,ShipCity, Count(ShippedDate) as Orders
FROM Orders
WHERE YEAR(ShippedDate) = 1997 and ShipRegion is not NULL
Group BY ShipRegion, ShipCity
Order BY ShipRegion;
