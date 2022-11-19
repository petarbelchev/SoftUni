-- Problem 11.	Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR [LastLoginTime]

INSERT INTO [Users]
	([Username],[Password],[IsDeleted])
VALUES
	('Pesho', '123123', 0)