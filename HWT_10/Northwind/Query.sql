﻿--1.1 Выбрать в таблице Orders заказы, которые были доставлены после
  FROM Northwind.Customers AS A
       INNER JOIN Northwind.Customers AS B
	   ON A.City = B.City
	   AND A.City = 'London'
  FROM Northwind.Customers
 GROUP BY City
HAVING COUNT(*) > 2
  FROM Northwind.Employees AS Empl
       INNER JOIN Northwind.EmployeeTerritories AS EmplTerr
	   ON Empl.EmployeeID = EmplTerr.EmployeeID
	   INNER JOIN Northwind.Territories AS Terr
	   ON EmplTerr.TerritoryID = Terr.TerritoryID
	   INNER JOIN Northwind.Region
	   ON Terr.RegionID = Region.RegionID
	   WHERE Region.RegionDescription = 'Western'
  FROM
       (SELECT ContactName, CustomerID
          FROM Northwind.Customers
         GROUP BY CustomerID, ContactName) AS A
	   LEFT JOIN
	   (SELECT COUNT(CustomerID) AS Amount, CustomerID
	      FROM Northwind.Orders
		 GROUP BY CustomerID) AS B
	   ON A.CustomerID = B.CustomerID
   FROM Northwind.Suppliers
  WHERE SupplierID IN
		(SELECT SupplierID
		   FROM Northwind.Products
		   WHERE UnitsInStock = 0)

  FROM Northwind.Employees
 WHERE EmployeeID IN
	   (SELECT EmployeeID
	      FROM Northwind.Orders
		 WHERE EmployeeID IN
						(SELECT EmployeeID
						   FROM Northwind.Orders
							 GROUP BY EmployeeID
							 HAVING COUNT(EmployeeID) >= 150))
  FROM Northwind.Customers
 WHERE NOT EXISTS
	   (SELECT CustomerID
	      FROM Northwind.Orders
	     WHERE Customers.CustomerID = Orders.CustomerID)
  FROM Northwind.Employees
 ORDER BY LastName
EXEC Northwind.GreatestOrders 1998, 3
SELECT Emp.FirstName + ' ' + LastName AS EmployeeName, Orders.OrderID,
	   OrdDet.UnitPrice * (1 - OrdDet.Discount) AS Cost
  FROM Northwind.Employees AS Emp  
       INNER JOIN Northwind.Orders
	   ON Emp.EmployeeID = Orders.EmployeeID
	   INNER JOIN Northwind.[Order Details] AS OrdDet
	   ON Orders.OrderID = OrdDet.OrderID
 WHERE YEAR(Orders.OrderDate) = 1998
	   AND Emp.EmployeeID = 3
 ORDER BY Cost DESC
EXEC Northwind.ShippedOrdersDiff
(SELECT *
   FROM dbo.SYSOBJECTS
  WHERE NAME = 'Bosses'
        AND xType = 'U')

CREATE TABLE #Bosses
(EmployeeID int,
   HaveBoss BIT)

SELECT EmployeeID, Northwind.IsBoss(EmployeeID) AS HaveBoss
  FROM Northwind.Employees;

SELECT EmployeeID, HaveBoss
FROM #Bosses
DROP TABLE #Bosses