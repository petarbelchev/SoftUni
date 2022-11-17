-- Problem 10.	Add Check Constraint
TRUNCATE TABLE [Users]

ALTER TABLE [Users]
ADD CHECK (DATALENGTH([Password]) >= 5)

INSERT INTO [Users]
	([Username],[Password],[LastLoginTime],[IsDeleted])
VALUES
	('Petar', '123123', '2022-11-15 14:21:02', 0),
	('Cvetelina', 'ASHER', '2022-11-16 10:21:02', 1),
	('Ivan', 'vfgsh', '2022-11-10 11:21:02', 0),
	('Gosho', 'rtyrty', '2022-11-12 09:21:02', 1),
	('Minka', 'dfg456', '2022-11-13 07:21:02', 0)