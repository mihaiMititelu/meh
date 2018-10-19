create table Files
(
	Id int IDENTITY(1, 1) NOT NULL,
	Name varchar(max) NOT NULL,
	Size int,
	CreationDate DATETIME,
	LastModified DATETIME,
	Extension varchar(max) not null
)

drop table files