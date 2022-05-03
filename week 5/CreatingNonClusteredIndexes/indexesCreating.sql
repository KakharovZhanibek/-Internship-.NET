USE AdventureWorks2019

GO

IF EXISTS(SELECT name FROM sys.indexes
			WHERE name=N'IX_TransactionHistory_ProductID' AND name = N'IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID')
	DROP INDEX 
		IX_TransactionHistory_ProductID ON Production.TransactionHistory,
		IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID ON Production.TransactionHistory
GO

CREATE NONCLUSTERED INDEX IX_TransactionHistory_ProductID
	ON Production.TransactionHistory(ProductID)
GO
CREATE NONCLUSTERED INDEX IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID
	ON Production.TransactionHistory(ReferenceOrderID,ReferenceOrderLineID)
GO

SET STATISTICS TIME ON;

GO
SELECT * FROM Production.TransactionHistory

--Со всеми индексами
 --Время работы SQL Server:
 --  Время ЦП = 78 мс, затраченное время = 1752 мс.


GO
SELECT * FROM Production.TransactionHistory WHERE ProductID>=332 AND ProductID<=856

--Со всеми индексами
 --Время работы SQL Server:
 --  Время ЦП = 47 мс, затраченное время = 715 мс.