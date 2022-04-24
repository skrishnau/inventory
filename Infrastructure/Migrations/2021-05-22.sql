
--2021-05-22 
--EXEC sp_rename 'dbo.PriceHistories.Price', 'Rate', 'COLUMN';  
GO 
-- 2021-06-12
update AppSettings set Value = '' where Name = 'Password' or Name='Username'
GO
-- 2021-06-16
ALTER TABLE Payments ADD TransactionId INT NULL CONSTRAINT [FK_dbo.Payments_dbo.Transactions_TransactionId] FOREIGN KEY(TransactionId) REFERENCES Transactions(Id)
GO