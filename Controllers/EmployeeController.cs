using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using System.Collections;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // Default action
        public IActionResult Index()
        {
            return View();
        }

        // Show form to add a new employee
        public IActionResult AddEmployee()
        {
            return View();
        }

        // Handle submission of the new employee form
        [HttpPost]
        public IActionResult AddEmployee(string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, double salary)
        {
            Employee employee = new Employee(firstName, lastName, email, phoneNumber, hireDate, salary);

            if (ModelState.IsValid)
            {
                employeeService.AddEmployee(employee);
                return RedirectToAction("GetAllEmployees");
            }
            return View(employee);
        }

        // List all employees
        public IActionResult GetAllEmployees()
        {
            IEnumerable employees = employeeService.GetAllEmployees();
            return View(employees);
        }

        // Handle employee deletion
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            employeeService.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployees");
        }

        // Show form to edit an employee's details
        public IActionResult EditEmployee(int id)
        {
            var employee = employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Handle submission of the edit form
        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeService.UpdateEmployee(employee);
                return RedirectToAction("GetAllEmployees");
            }
            return View(employee);
        }
    }
}
