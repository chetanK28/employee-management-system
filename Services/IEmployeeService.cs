using System.Collections;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public interface IEmployeeService
    {
        // Add a new employee
        void AddEmployee(Employee employee);

        // Delete an employee by ID
        void DeleteEmployee(int employeeId);

        // Update an employee's details
        void UpdateEmployee(Employee employee);

        // Get an employee by ID
        Employee GetEmployeeById(int id);

        // Get all employees
        IEnumerable GetAllEmployees();
    }
}
