Use AdventureWorks2012
Go
--drop login AdvWork2012;

Create Login AdvWork2012 With Password = 'pass123'
Go

Create user AdvWork2012
For Login AdvWork2012

Exec sp_addrolemember 'db_datareader','AdvWork2012'
Exec sp_addrolemember 'db_datawriter','AdvWork2012'

Deny Select,Insert,Alter,Delete,Update on Schema :: HumanResources to AdvWork2012;
Go
Deny Insert,Alter,Delete,Update on Schema :: Person to AdvWork2012;

Grant Select on Schema:: Person to AdvWork2012;
Go
Grant Select on Schema:: Sales to AdvWork2012;
Go
Grant Select on Schema:: Purchasing to AdvWork2012;
Go
Grant Select on Schema:: Production to AdvWork2012;
Go