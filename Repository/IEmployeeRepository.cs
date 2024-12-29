using EmployeeManagementSystem.Models;
using System.Collections;

namespace EmployeeManagementSystem.Repositories
{
    public interface IEmployeeRepository
    {
        // Add a new employee
        void AddEmployee(Employee employee);

        // Delete an employee by ID
        void DeleteEmployee(int employeeId);

        // Update employee details
        void UpdateEmployee(Employee employee);

        // Get an employee by ID
        Employee GetEmployeeById(int id);

        // Get all employees
        IEnumerable GetAllEmployees();
    }
}
