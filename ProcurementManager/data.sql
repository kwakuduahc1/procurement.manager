-- Script Date: 21-Jul-2018 19:52  - ErikEJ.SqlCeScripting version 3.5.2.75
-- Database information:
-- Database: C:\Users\Kwaku\Documents\Visual Studio 2017\Projects\ProcurementManager\ProcurementManager\procurement.db
-- ServerVersion: 3.22.0
-- DatabaseSize: 48 KB
-- Created: 21-Jul-2018 09:44

-- User Table information:
-- Number of tables: 5
-- __EFMigrationsHistory: -1 row(s)
-- ContractParameters: -1 row(s)
-- Contracts: -1 row(s)
-- Methods: -1 row(s)
-- Timelines: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
INSERT INTO [Methods] ([MethodsID],[Method],[Concurrency]) VALUES (
1,'National Competitive Tendering',NULL);
INSERT INTO [Methods] ([MethodsID],[Method],[Concurrency]) VALUES (
2,'Sole Sourcing',NULL);
INSERT INTO [Methods] ([MethodsID],[Method],[Concurrency]) VALUES (
3,'Request for quotation',NULL);
INSERT INTO [Methods] ([MethodsID],[Method],[Concurrency]) VALUES (
4,'Price quotation',NULL);
INSERT INTO [Methods] ([MethodsID],[Method],[Concurrency]) VALUES (
5,'Restrictive Tendering',NULL);
INSERT INTO [Methods] ([MethodsID],[Method],[Concurrency]) VALUES (
6,'International Competitive Tendering',NULL);
INSERT INTO [Methods] ([MethodsID],[Method],[Concurrency]) VALUES (
7,'Price quotation',NULL);
INSERT INTO [Contracts] ([ContractsID],[Subject],[MethodsID],[Contractor],[Amount],[IsFlexible],[IsApproved],[DateSigned],[IsCompleted],[ExpectedDate],[DateAdded],[Concurrency]) VALUES (
'COHAS/PROC/0','Build three unit class room block',1,'Kwaku Duah and sons',30000,0,0,'2018-05-01 00:00:00',0,'2018-03-12 00:00:00','2018-07-21 18:55:03.9151423',NULL);
INSERT INTO [Contracts] ([ContractsID],[Subject],[MethodsID],[Contractor],[Amount],[IsFlexible],[IsApproved],[DateSigned],[IsCompleted],[ExpectedDate],[DateAdded],[Concurrency]) VALUES (
'COHAS/PROC/1','Purchase 100 laptop computers',2,'Ama goldings',20000,0,0,'2018-04-14 00:00:00',0,'2018-11-20 00:00:00','2018-07-21 18:57:34.6612256',NULL);
INSERT INTO [Contracts] ([ContractsID],[Subject],[MethodsID],[Contractor],[Amount],[IsFlexible],[IsApproved],[DateSigned],[IsCompleted],[ExpectedDate],[DateAdded],[Concurrency]) VALUES (
'COHAS/PROC/2','Purchase library books',2,'Linus Mornah',2000,0,0,'2018-07-19 00:00:00',0,'2018-08-31 00:00:00','2018-07-21 19:03:54.6501457',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
1,0,'COHAS/PROC/0',10,2000,1,'2018-05-01 00:00:00',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
2,0,'COHAS/PROC/0',15,2500,0,'2018-05-21 00:00:00',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
3,0,'COHAS/PROC/0',25,4500,0,'2018-06-15 00:00:00',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
4,0,'COHAS/PROC/0',40,20000,0,'2018-07-25 00:00:00',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
5,0,'COHAS/PROC/0',10,1000,0,'2018-08-18 00:00:00',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
6,0,'COHAS/PROC/1',75,15000,1,'2018-08-15 00:00:00',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
7,0,'COHAS/PROC/1',25,5000,0,'2018-10-20 00:00:00',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
8,0,'COHAS/PROC/2',30,900,1,'2018-07-31 00:00:00',NULL);
INSERT INTO [ContractParameters] ([ContractParametersID],[ContractParameter],[ContractsID],[Percentage],[Amount],[IsCompleted],[ExpectedDate],[Concurrency]) VALUES (
9,0,'COHAS/PROC/2',70,1100,0,'2018-08-09 00:00:00',NULL);
COMMIT;

