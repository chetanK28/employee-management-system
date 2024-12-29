using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using System.Collections;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // Add a new employee
        public void AddEmployee(Employee employee)
        {
            employeeRepository.AddEmployee(employee);
        }

        // Delete an employee by ID
        public void DeleteEmployee(int employeeId)
        {
            employeeRepository.DeleteEmployee(employeeId);
        }

        // Get all employees
        public IEnumerable GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        // Get an employee by ID
        public Employee GetEmployeeById(int id)
        {
            return employeeRepository.GetEmployeeById(id);
        }

        // Update an employee's details
        public void UpdateEmployee(Employee employee)
        {
            employeeRepository.UpdateEmployee(employee);
        }
    }
}
