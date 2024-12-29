# Employee Management System

## Overview
The **Employee Management System** is a software application designed to manage employee data efficiently. It provides functionality for creating, reading, updating, and deleting (CRUD) employee records. This system utilizes a MySQL database for storage and retrieval, with a C# backend for business logic.

## Features
- Add new employees.
- Retrieve all employee details.
- Update existing employee information.
- Delete employee records.
- Validation for required fields such as First Name, Last Name, Email, and Salary.
- Unique constraints for employee emails.

## Technologies Used
- **Programming Language**: C#
- **Framework**: .NET
- **Database**: MySQL
- **ORM/Database Connector**: MySql.Data.MySqlClient

## Prerequisites
- Visual Studio 2022 or later
- MySQL Server and MySQL Workbench
- .NET 6.0 SDK or later

## Database Setup
1. Install MySQL Server if not already installed.
2. Create the `Employees` table using the following SQL script:

   ```sql
   CREATE TABLE Employees (
       EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
       FirstName VARCHAR(50) NOT NULL,
       LastName VARCHAR(50) NOT NULL,
       Email VARCHAR(100) UNIQUE NOT NULL,
       PhoneNumber VARCHAR(15),
       HireDate DATE NOT NULL,
       Salary DECIMAL(10, 2) NOT NULL
   );
   ```

3. Note down your database credentials (host, username, password, and database name).
4. Update the `connectionString` in the `EmployeeRepository` class with your database details.

   Example:
   ```csharp
   private readonly string connectionString = "Server=localhost;Database=EmployeeDB;Uid=root;Pwd=password;";
   ```

## Installation
1. Clone the repository:
   ```bash
   git clone  https://github.com/chetanK28/employee-management-system.git
   ```
2. Open the project in Visual Studio.
3. Restore NuGet packages.
4. Build the solution.

## Usage
1. Run the application from Visual Studio.
2. Use the provided methods in the `EmployeeRepository` class to perform CRUD operations:
   - `AddEmployee(Employee employee)`
   - `GetAllEmployees()`
   - `GetEmployeeById(int id)`
   - `UpdateEmployee(Employee employee)`
   - `DeleteEmployee(int employeeId)`

## Example
### Adding a New Employee
```csharp
Employee employee = new Employee
{
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@example.com",
    PhoneNumber = "1234567890",
    HireDate = DateTime.Now,
    Salary = 50000.00
};

EmployeeRepository repo = new EmployeeRepository(connectionString);
repo.AddEmployee(employee);
```

### Fetching All Employees
```csharp
EmployeeRepository repo = new EmployeeRepository(connectionString);
var employees = repo.GetAllEmployees();
foreach (var employee in employees)
{
    Console.WriteLine($"{employee.Id}: {employee.FirstName} {employee.LastName}");
}
```

## Project Structure
```
EmployeeManagementSystem
├── Models
│   └── Employee.cs
├── Repositories
│   ├── IEmployeeRepository.cs
│   └── EmployeeRepository.cs
└── Program.cs
```

## Future Enhancements
- Implement a front-end UI for better interaction.
- Add authentication and authorization.
- Integrate RESTful APIs.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Author
- **Chetan Kirange**

