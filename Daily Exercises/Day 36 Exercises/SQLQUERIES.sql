select p.ProductName, c.CategoryName from Products p JOIN Categories c on p.CategoryID = c.CategoryID;



select o.OrderID, c.CompanyName from Orders o JOIN Customers c ON o.CustomerID = c.CustomerID;



select p.ProductName, s.CompanyName FROM Products p JOIN Suppliers s ON p.SupplierID = s.SupplierID;



select o.OrderID, o.OrderDate, e.FirstName, e.LastName FROM Orders o JOIN Employees e ON o.EmployeeID = e.EmployeeID;



select o.OrderID, s.CompanyName FROM Orders o JOIN Shippers s ON o.ShipVia = s.ShipperID WHERE o.ShipCountry = 'France';



select c.CategoryName, SUM(p.UnitsInStock) AS TotalUnitsInStock FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID GROUP BY c.CategoryName;



select c.CompanyName, SUM(od.UnitPrice * od.Quantity) AS TotalSpent FROM Customers c, Orders o, [Order Details] od where c.CustomerID = o.CustomerID and o.OrderID = od.OrderID GROUP BY c.CompanyName;



select e.LastName, COUNT(o.OrderID) AS TotalOrders FROM Employees e JOIN Orders o ON e.EmployeeID = o.EmployeeID GROUP BY e.LastName;



select s.CompanyName, SUM(o.Freight) AS TotalFreight FROM Orders o JOIN Shippers s ON o.ShipVia = s.ShipperID GROUP BY s.CompanyName;



select TOP 5 p.ProductName, SUM(od.Quantity) AS TotalQuantitySold FROM [Order Details] od JOIN Products p ON od.ProductID = p.ProductID GROUP BY p.ProductName ORDER BY TotalQuantitySold DESC;



select ProductName FROM Products WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);



select (e.FirstName + ' ' + e.LastName) AS Employee, (m.FirstName + ' ' + m.LastName) AS Manager FROM Employees e LEFT JOIN Employees m ON e.ReportsTo = m.EmployeeID;



select CompanyName FROM Customers c WHERE NOT EXISTS (SELECT * FROM Orders o WHERE o.CustomerID = c.CustomerID);



select OrderID FROM [Order Details] GROUP BY OrderID HAVING SUM(UnitPrice * Quantity) > (SELECT AVG(OrderTotal) FROM (SELECT SUM(UnitPrice * Quantity) AS OrderTotal FROM [Order Details] GROUP BY OrderID) AS OrderTotals);



select ProductName FROM Products p WHERE NOT EXISTS (SELECT * FROM Orders o JOIN [Order Details] od ON o.OrderID = od.OrderID WHERE od.ProductID = p.ProductID AND YEAR(o.OrderDate) > 1997);



select (e.FirstName + ' ' + e.LastName) AS Employee, r.RegionDescription FROM Employees e, EmployeeTerritories et, Territories t, Region r WHERE e.EmployeeID = et.EmployeeID and et.TerritoryID = t.TerritoryID and t.RegionID = r.RegionID;



select c.CompanyName AS Customer, s.CompanyName AS Supplier, c.City FROM Customers c JOIN Suppliers s ON c.City = s.City;



select c.CompanyName FROM Customers c, Orders o, [Order Details] od, Products p WHERE c.CustomerID = o.CustomerID and o.OrderID = od.OrderID and od.ProductID = p.ProductID GROUP BY c.CompanyName HAVING COUNT(DISTINCT p.CategoryID) > 3;



select SUM(od.UnitPrice * od.Quantity) AS TotalRevenue FROM [Order Details] od JOIN Products p ON od.ProductID = p.ProductID WHERE p.Discontinued = 'True';



select c.CategoryName, p.ProductName, p.UnitPrice FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID WHERE p.UnitPrice =(SELECT MAX(p2.UnitPrice) FROM Products p2 WHERE p2.CategoryID = p.CategoryID);