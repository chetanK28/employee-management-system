using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        // Primary Key
        public int Id { get; set; }

        // Required fields with annotations
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number.")]
        [StringLength(15, ErrorMessage = "Phone Number cannot exceed 15 characters.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Hire Date is required.")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be greater than 0.")]
        public double Salary { get; set; }

        // Parameterless constructor for EF or manual instantiation
        public Employee() { }

        // Constructor without Id for new employee creation
        public Employee(string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, double salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            HireDate = hireDate;
            Salary = salary;
        }

        // Constructor with Id for updating or retrieving an employee
        public Employee(int id, string firstName, string lastName, string email, string phoneNumber, DateTime hireDate, double salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            HireDate = hireDate;
            Salary = salary;
        }
    }
}
