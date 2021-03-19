CREATE DATABASE DemoCRUD
GO

USE DemoCRUD
GO

CREATE TABLE tbl_Employee(
	Sr_no INT IDENTITY(1,1) PRIMARY KEY,
	Emp_Name NVARCHAR(500) NOT NULL,
	City NVARCHAR(500),
	STATE NVARCHAR(500),
	Country NVARCHAR(500),
	Department NVARCHAR(500),
	flag NVARCHAR(500),
)

CREATE PROC Sp_Employee @Sr_no INT, @Emp_Name NVARCHAR(500),@City NVARCHAR(500), @STATE NVARCHAR(500),
@Country NVARCHAR(500), @Department NVARCHAR(500), @flag NVARCHAR(500)
AS
BEGIN
	IF(@flag = 'insert')
	BEGIN
		INSERT INTO tbl_Employee(Emp_Name, City, STATE, Country, Department)
		VALUES (@Emp_Name, @City, @STATE, @Country, @Department)
	END

	ELSE IF(@flag = 'update')
	BEGIN
		UPDATE tbl_Employee
		SET Emp_Name = @Emp_Name, City = @City, STATE = @STATE, Country = @Country, Department = @Department
		WHERE Sr_no = @Sr_no
	END

	ELSE IF(@flag = 'delete')
	BEGIN
		DELETE FROM tbl_Employee
		WHERE Sr_no = @Sr_no
	END

	ELSE IF(@flag = 'getid')
	BEGIN
		SELECT * FROM tbl_Employee
		WHERE Sr_no = @Sr_no
	END

	ELSE IF(@flag = 'get')
	BEGIN
		SELECT * FROM tbl_Employee
	END
END