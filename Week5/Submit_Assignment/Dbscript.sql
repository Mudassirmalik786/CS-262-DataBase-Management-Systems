--Task1
SELECT C.CustomerID, O.OrderID, O.OrderDate
FROM Customers as C
Left Join Orders as O
On C.CustomerID = O.CustomerID;

--Task2
SELECT C.CustomerID, O.OrderID, O.OrderDate
FROM Customers as C
LEFT JOIN Orders as O
ON C.CustomerID = O.CustomerID
WHERE O.OrderID is NULL
GROUP BY O.OrderID, C.CustomerID, O.OrderDate;

--Task3
SELECT C.CustomerID, O.OrderID, O.OrderDate
FROM Customers as C
LEFT JOIN Orders as O
ON C.CustomerID = O.CustomerID
WHERE Year(O.OrderDate) = 1997 and MONTH(O.OrderDate) = 7 
GROUP BY C.CustomerID, O.OrderID, O.OrderDate;

--Task4
SELECT C.CustomerID, COUNT(O.OrderID) as totalorder
FROM Customers as C
Left Join Orders as O
On C.CustomerID = O.CustomerID
Group By C.CustomerID

--Task5
SELECT E.EmployeeID, E.FirstName, E.LastName
FROM Employees as E
CROSS JOIN (SELECT 1 as n UNION all SELECT 2 UNION ALL SELECT 3 UNION all SELECT 3 UNION all SELECT 4) as Numbers


--Task6
SELECT E.EmployeeID,E.BirthDate
FROM Employees E
WHERE E.BirthDate BETWEEN  '1996-07-04 00:00:00.000' AND '1997-08-04 00:00:00.000'


--Task7
SELECT C.CustomerID, COUNT(O.OrderID) as TotalOrders, SUM(OD.Quantity) as totalquantity
FROM Customers as C
Join [Orders] as O
ON C.CustomerID = O.CustomerID
Join [Order Details] as OD
ON OD.OrderID = O.OrderID
WHERE C.Country = 'USA'
Group By C.CustomerID;

--Task8
SELECT C.CustomerID, C.CompanyName, O.OrderID, O.OrderDate
FROM Customers as C
Join Orders as O
ON C.CustomerID = O.CustomerID
WHERE Day(O.OrderDate) = 4 and MONTH(O.OrderDate) = 7 and YEAR(O.OrderDate) = 1997
Group By C.CustomerID, C.CompanyName, O.OrderID, O.OrderDate
Order BY C.CustomerID;

--Task9
--Yes two Employees named Andrew Fuller and Margaret Peacock is less age than Employee
DECLARE @ManagerAge as DateTime=(SELECT E.BirthDate FROM Employees E WHERE E.Title LIKE'%Manager%')
SELECT CONCAT(E.FirstName,' ',E.LastName) AS FullName
FROM Employees E
WHERE E.BirthDate < @ManagerAge;


--Task10
SELECT CONCAT(E.FirstName,' ',E.LastName) AS EmployeeName,YEAR(GETDATE())-YEAR(E.BirthDate) as Age, YEAR(GETDATE())-YEAR(@ManagerAge) as [Manager Age]
FROM Employees E
WHERE E.BirthDate < @ManagerAge;

--Task11
SELECT P.ProductName, O.OrderDate
FROM Products as P
JOIN [Order Details] as OD
ON P.ProductID = OD.ProductID
JOIN Orders as O
ON O.OrderID = OD.OrderID
WHERE YEAR(O.OrderDate) = 1997 and MONTH(O.OrderDate) = 8 and DAY(O.OrderDate) = 8;

--Task 12
SELECT O.ShipAddress as Address, O.ShipCity as City, O.ShipCountry as Country
FROM Orders as O
JOIN Employees as E
On E.EmployeeID = O.EmployeeID
Where E.FirstName = 'Anne' and O.ShippedDate > O.RequiredDate;

--Task13 
SELECT DISTINCT O.ShipCountry
FROM Orders as O
Where O.ShipName like '%beverages%';