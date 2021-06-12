--2021-05-22
GO  
EXEC sp_rename 'dbo.PriceHistories.Price', 'Rate', 'COLUMN';  
GO 
-- 2021-06-12
update AppSettings set Value = '' where Name = 'Password' or Name='Username'
