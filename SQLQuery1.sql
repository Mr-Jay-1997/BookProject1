--create table query

CREATE TABLE tbl_USER(
	userid int NOT NULL PRIMARY KEY,
	firstname nvarchar(50) NOT NULL,
	lastname nvarchar(50) NULL,
	email nvarchar(50) NOT NULL,
	password nvarchar(50) NOT NULL,
	mobile nvarchar(50) NULL)
	GO;

CREATE TABLE tbl_BOOK(
	bookid int NOT NULL PRIMARY KEY,
	bookname nvarchar(50) NOT NULL,
	--categoryid nvarchar(50) NOT NULL,
	categoryid int NOT NULL FOREIGN KEY REFERENCES tbl_CATEGORY(categoryid),
	author nvarchar(50)  NULL,
	publisher nvarchar(50)  NULL,
	price decimal(8,2) NOT NULL)
	--categoryid int FOREIGN KEY REFERENCES tbl_CATEGORY(categoryid)
	GO;

CREATE TABLE tbl_CATEGORY(
    categoryid int IDENTITY (1,1) NOT NULL PRIMARY KEY,
	categoryname nvarchar(50)NOT NULL)
	GO;

--select query

SELECT * FROM tbl_BOOK;
SELECT * FROM tbl_CATEGORY;
SELECT * FROM tbl_USER;

