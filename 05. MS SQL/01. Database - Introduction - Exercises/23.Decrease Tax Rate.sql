-- Problem 23.	Decrease Tax Rate
UPDATE [Payments]
   SET [TaxRate] -= 0.03

SELECT [TaxRate] FROM [Payments]