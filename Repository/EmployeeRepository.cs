using MySql.Data.MySqlClient;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;

using System.Collections;
using System.Data;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString;

        public EmployeeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddEmployee(Employee employee)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, HireDate, Salary) VALUES (@firstName, @lastName, @Email, @PhoneNumber, @HireDate, @Salary)", connection);
                    command.Parameters.AddWithValue("@firstName", employee.FirstName);
                    command.Parameters.AddWithValue("@lastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", connection);
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("SELECT * FROM Employees", connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Id = reader.GetInt32("EmployeeID");
                            employee.FirstName = reader.GetString("FirstName");
                            employee.LastName = reader.GetString("LastName");
                            employee.Email = reader.GetString("Email");
                            employee.PhoneNumber = reader.GetString("PhoneNumber");
                            employee.HireDate = reader.GetDateTime("HireDate");
                            employee.Salary = reader.GetDouble("Salary");
                            employees.Add(employee);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID", connection);
                    command.Parameters.AddWithValue("@EmployeeID", id);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee.Id = reader.GetInt32("EmployeeID");
                            employee.FirstName = reader.GetString("FirstName");
                            employee.LastName = reader.GetString("LastName");
                            employee.Email = reader.GetString("Email");
                            employee.PhoneNumber = reader.GetString("PhoneNumber");
                            employee.HireDate = reader.GetDateTime("HireDate");
                            employee.Salary = reader.GetDouble("Salary");
                        }
                    }
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    var command = new MySqlCommand("UPDATE Employees SET FirstName = @firstName, LastName = @lastName, Email = @Email, PhoneNumber = @PhoneNumber, HireDate = @HireDate, Salary = @Salary WHERE EmployeeID = @EmployeeID", connection);
                    command.Parameters.AddWithValue("@firstName", employee.FirstName);
                    command.Parameters.AddWithValue("@lastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@EmployeeID", employee.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    throw e;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
