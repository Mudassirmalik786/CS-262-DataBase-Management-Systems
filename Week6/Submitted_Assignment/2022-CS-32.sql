--Q1
SELECT C.CustomerID, O.OrderID, O.OrderDate
FROM Customers C
LEFT JOIN
    (
        SELECT CustomerID, OrderID, OrderDate FROM Orders
    ) O ON C.CustomerID = O.CustomerID;
--***


--Q2
SELECT C.CustomerID, O.OrderID, O.OrderDate
FROM Customers C
LEFT JOIN
    (
        SELECT CustomerID, OrderID, OrderDate FROM Orders
    ) O ON C.CustomerID = O.CustomerID
WHERE O.OrderID is NULL
GROUP BY O.OrderID, C.CustomerID, O.OrderDate;
--***


--Q3
SELECT C.CustomerID, O.OrderID, O.OrderDate
FROM Customers C
LEFT JOIN
    (
        SELECT CustomerID, OrderID, OrderDate FROM Orders
    ) O ON C.CustomerID = O.CustomerID
WHERE Year(O.OrderDate) = 1997 and MONTH(O.OrderDate) = 7 
GROUP BY C.CustomerID, O.OrderID, O.OrderDate;
--***

--Q4
SELECT C.CustomerId, COUNT(O.OrderDate) as TotalOrder
from Customers C
LEFT JOIN
	(
		SELECT CustomerID, OrderDate FROM Orders
	) O ON O.CustomerID = C.CustomerID

GROUP BY C.CustomerID;
--***

--Q5
SELECT E.EmployeeID, E.firstname, E.lastname
FROM Employees AS E
CROSS JOIN dbo.Products AS N
WHERE N.ProductID <= 5
ORDER BY EmployeeID asc;
--***


--Q6
SELECT * 
FROM Products
Where UnitPrice > (SELECT AVG(UnitPrice) FROM Products);
--***

--Q7
SELECT MAX(UnitPrice)as SecondHighestPrice
FROM Products
WHERE UnitPrice < (SELECT MAX(UnitPrice) FROM Products);
--***

--Q8
SELECT E.EmployeeID, D.OrderDate AS dt
FROM Employees AS E
CROSS JOIN 
	(
		SELECT EmployeeID, OrderDate FROM Orders
	) D
WHERE D.OrderDate <= '1997-08-04 00:00:00.000' and D.OrderDate >= '1996-07-04 00:00:00.000'
ORDER BY EmployeeID, OrderDate;
--***

--Q9
SELECT C.CustomerID, COUNT(O.OrderID) as TotalOrders, SUM(OD.Quantity) as totalquantity
FROM Customers as C
Join (SELECT CustomerID, OrderID FROM Orders) as O
ON C.CustomerID = O.CustomerID
Join (SELECT Quantity, OrderID FROM [Order Details]) as OD
ON OD.OrderID = O.OrderID
WHERE C.Country = 'USA'
Group By C.CustomerID;
--***


--Q10
SELECT C.CustomerID, C.CompanyName, O.OrderID, O.OrderDate
FROM Customers as C
Join (SELECT CustomerID, OrderID, OrderDate FROM Orders) as O
ON C.CustomerID = O.CustomerID
WHERE Day(O.OrderDate) = 4 and MONTH(O.OrderDate) = 7 and YEAR(O.OrderDate) = 1997
Group By C.CustomerID, C.CompanyName, O.OrderID, O.OrderDate
Order BY C.CustomerID;
--***


--Q11
DECLARE @ManagerAge as DateTime=(SELECT E.BirthDate FROM Employees E WHERE E.Title LIKE'%Manager%')
SELECT CONCAT(E.FirstName,' ',E.LastName) AS FullName
FROM Employees E
WHERE E.BirthDate < @ManagerAge;
--***


--Q12
SELECT CONCAT(E.FirstName,' ',E.LastName) AS EmployeeName,YEAR(GETDATE())-YEAR(E.BirthDate) as Age, YEAR(GETDATE())-YEAR(@ManagerAge) as [Manager Age]
FROM Employees E
WHERE E.BirthDate < @ManagerAge;
--***


--Q13
SELECT P.ProductName, O.OrderDate
FROM Products as P
JOIN (SELECT ProductID, OrderID FROM [Order Details]) as OD ON P.ProductID = OD.ProductID
JOIN (SELECT OrderID, OrderDate FROM Orders) as O ON O.OrderID = OD.OrderID
WHERE YEAR(O.OrderDate) = 1997 and MONTH(O.OrderDate) = 8 and DAY(O.OrderDate) = 8;
--***


--Q14
SELECT O.ShipAddress as Address, O.ShipCity as City, O.ShipCountry as Country
FROM Orders as O
JOIN (SELECT EmployeeID, FirstName FROM Employees) as E
On E.EmployeeID = O.EmployeeID
Where E.FirstName = 'Anne' and O.ShippedDate > O.RequiredDate;
--***


--Q15
select distinct(o.ShipCountry)
from [Order Details] od
join (SELECT OrderID, ShipCountry FROM Orders) o on o.OrderID=od.OrderID
join (SELECT ProductID, CategoryID FROM Products) p on p.ProductID=od.ProductID
join (SELECT CategoryID FROM Categories) c on c.CategoryID=p.CategoryID
where c.CategoryID=1;
--***


