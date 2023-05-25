CREATE TABLE Employee (
	EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
	EmployeeName NVARCHAR(120) NOT NULL,
	Department NVARCHAR(200),
	DataOfJoining DATETIME,
	PhotoFileName NVARCHAR(500)
);

CREATE TABLE Department (
	DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
	DepartmentName NVARCHAR(500) NOT NULL
);

INSERT INTO Department VALUES ('Human Resources');
INSERT INTO Department VALUES ('SW Development');
INSERT INTO Department VALUES ('Sales');


SELECT * FROM Department;

INSERT INTO Employee VALUES ('Hugo', 2, GETDATE(), 'hugo.png');


SELECT * FROM Employee;