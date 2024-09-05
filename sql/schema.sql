CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    EmployeeName NVARCHAR(100),
    EmailID NVARCHAR(100),
    Designation NVARCHAR(100)
);

GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName NVARCHAR(100),
    Location NVARCHAR(100),
    Phone NVARCHAR(15)
);
