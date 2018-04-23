
USE MASTER;
if (select count(*) 
    from sys.sysusers  where name = 'AdvWork2012') > 0
BEGIN
    DROP Login AdvWork2012;
	Drop User  Advwork2012;
END

Create Login AdvWork2012 With Password = 'pass123'
Go

Create user AdvWork2012
For Login AdvWork2012

Use AdventureWorks2012
Go



Exec sp_addrolemember 'db_datareader','AdvWork2012'
Exec sp_addrolemember 'db_datawriter','AdvWork2012'

Deny Select,Insert,Alter,Delete,Update on Schema :: HumanResources to AdvWork2012;
Go
Deny Insert,Alter,Delete,Update on Schema :: Person to AdvWork2012;

Grant Select on Schema:: Person to AdvWork2012;
Go




--GO
--Create procedure sp_CustomerSales
--(
--@CustID int
--)
--as
--Select	soh.SalesOrderID, soh.OrderDate, soh.ShipDate,CONCAT(p.FirstName,' ', p.LastName)[Sales Person],a.City,psp.Name[State], soh.TotalDue
--From	sales.SalesOrderHeader soh
--Inner join sales.Customer c
--on		c.CustomerID = soh.CustomerID
--inner join sales.SalesPerson sp
--on		sp.TerritoryID = soh.TerritoryID
--inner join person.Person p
--on		p.BusinessEntityID = sp.BusinessEntityID
--inner join person.Address a
--on		a.AddressID = soh.ShipToAddressID
--inner join person.StateProvince psp
--on		psp.StateProvinceID = a.StateProvinceID
--Where	c.CustomerID = @CustID;


--Go
--Create Proc sp_ActiveCust
--as
--Select	c.CustomerID, concat(p.FirstName, ' ', p.LastName) [Customer Name]
--From	sales.Customer c
--inner join Person.Person p
--on		p.BusinessEntityID = c.CustomerID
--order by c.CustomerID asc
