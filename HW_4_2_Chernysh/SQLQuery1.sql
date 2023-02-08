--1
SELECT * FROM SALES.Customer
--2
SELECT * FROM SALES.Store ORDER BY Name ASC
--3
SELECT TOP 10 * FROM HumanResources.Employee WHERE BirthDate > '1989-09-28'
--4
SELECT NationalIDNumber, LoginID, JobTitle FROM HumanResources.Employee WHERE LoginID LIKE '%0' ORDER BY JobTitle ASC
--5
SELECT * FROM Person.Person WHERE ModifiedDate > '2008' AND MiddleName IS NOT NULL AND Title IS NULL
--6
SELECT Name FROM HumanResources.Department INNER JOIN HumanResources.EmployeeDepartmentHistory ON EndDate IS NOT NULL GROUP BY Name
--7
SELECT Sum(CommissionPct) as ComSum FROM Sales.SalesPerson GROUP BY TerritoryID HAVING Sum(CommissionPct) > 0
--8
SELECT * FROM HumanResources.Employee WHERE VacationHours = (SELECT MAX(VacationHours) FROM HumanResources.Employee)
--9
SELECT * FROM HumanResources.Employee WHERE JobTitle = 'Sales Representative' OR JobTitle = 'Network Administrator' OR JobTitle = 'Network Manager'
--10
SELECT * FROM HumanResources.Employee LEFT JOIN Purchasing.PurchaseOrderHeader ON BusinessEntityID = EmployeeID