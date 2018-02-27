--13.1
CREATE PROCEDURE Northwind.GreatestOrders @year int, @countRecords int AS
SELECT TOP (@countRecords) Emp.FirstName + ' ' + Emp.LastName AS EmployeeName,
       Ord.OrderID, Ord.UnitPrice * (1 - Ord.Discount) AS Cost
  FROM Northwind.Employees AS Emp
 CROSS APPLY
       (SELECT TOP 1
			   Orders.OrderID, ordDet.UnitPrice, ordDet.Discount
		  FROM Northwind.Orders
			   INNER JOIN Northwind.[Order Details] AS OrdDet
			   ON Orders.OrderID = OrdDet.OrderID
			   WHERE Orders.EmployeeID = Emp.EmployeeID
					 AND YEAR(Orders.OrderDate) = @year
		 ORDER BY UnitPrice * (1 - Discount) DESC) AS Ord
 ORDER BY UnitPrice * (1 - Discount) DESC

 
--13.3
CREATE PROCEDURE  SubordinationInfo @EmployeeID int AS
  WITH Emp(LastName, ReportsTo) AS
       (SELECT EmployeeID, ReportsTo
          FROM Northwind.Employees
		  WHERE ReportsTo = @EmployeeID
          UNION ALL
        SELECT Worker.EmployeeID, Worker.ReportsTo
           FROM Northwind.Employees AS Boss
		        INNER JOIN Northwind.Employees AS Worker
				ON Boss.ReportsTo = Worker.EmployeeID)
SELECT LastName, ReportsTo
  FROM Northwind.Employees AS Emp


--13.4
CREATE FUNCTION Northwind.IsBoss (@EmployeeID int)
RETURNS BIT
 BEGIN
   DECLARE @haveBoss BIT
	SELECT @haveBoss = ReportsTo
	  FROM Northwind.Employees
	 WHERE EmployeeID = @EmployeeID
	RETURN @haveBoss
   END

   WITH Letters AS(
SELECT ASCII('A') code, CHAR(ASCII('A')) letter
UNION ALL
SELECT code+1, CHAR(code+1) FROM Letters
WHERE code+1 <= ASCII('Z')
)
SELECT letter FROM Letters;
