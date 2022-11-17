--Problem 8.	Create Table Users
CREATE TABLE [Users] (
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY,
	CHECK (DATALENGTH([ProfilePicture]) <= 921600),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
)

INSERT INTO [Users]
	([Username],[Password],[LastLoginTime],[IsDeleted])
VALUES
	('Petar', '123123', '2022-11-15 14:21:02', 0),
	('Cvetelina', 'ASHER', '2022-11-16 10:21:02', 1),
	('Ivan', 'vfgh', '2022-11-10 11:21:02', 0),
	('Gosho', 'rtyrty', '2022-11-12 09:21:02', 1),
	('Minka', 'dfg456', '2022-11-13 07:21:02', 0)