using Staffify.Models.Data;

namespace Staffify.Database;

public class Database : IDatabase
{
    // Constructor
    public Database()
    {
        // Add Test Data
        using (DatabaseContext _context = new())
        {
            if (!_context.Employees.Any())
            {
                List<Employee> _employeesToAdd = new()
                {
                    new Employee
                    {
                        EmployeeId = 1,
                        Name = "Jalen Hurts",
                        PhoneNumber = "(123) 456-7890",
                        EmailAddress = "jhurts@flyeaglesfly.com"
                    },
                    new Employee
                    {
                        EmployeeId = 11,
                        Name = "A.J. Brown",
                        PhoneNumber = "(123) 456-7891",
                        EmailAddress = "abrown@flyeaglesfly.com"
                    },
                    new Employee
                    {
                        EmployeeId = 6,
                        Name = "DeVonta Smith",
                        PhoneNumber = "(123) 456-7892",
                        EmailAddress = "dsmith@flyeaglesfly.com"
                    },
                    new Employee
                    {
                        EmployeeId = 91,
                        Name = "Fletcher Cox",
                        PhoneNumber = "(123) 456-7893",
                        EmailAddress = "fcox@flyeaglesfly.com"
                    }
                };

                _context.AddRange(_employeesToAdd);
                _context.SaveChanges();
            }
        }
    }

    // Inherited Methods
    public List<Employee> GetEmployees()
    {
        using (DatabaseContext _context = new())
        {
            List<Employee> _employees = _context.Employees.ToList();
            return _employees;
        }
    }

    public Employee GetSingleEmployee(int _employeeRecordId)
    {
        using (DatabaseContext _context = new())
        {
            Employee _employee = _context.Employees.Single(record => record.Id == _employeeRecordId);
            return _employee;
        }
    }

    public bool UpdateSingleEmployee(Employee _updatedEmployeeInformation)
    {
        using (DatabaseContext _context = new())
        {
            try
            {
                Employee _existingEmployee = _context.Employees.Single(record => record.Id == _updatedEmployeeInformation.Id);
                _existingEmployee.EmployeeId = _updatedEmployeeInformation.Id;
                _existingEmployee.Name = _updatedEmployeeInformation.Name;
                _existingEmployee.PhoneNumber = _updatedEmployeeInformation.PhoneNumber;
                _existingEmployee.EmailAddress = _updatedEmployeeInformation.EmailAddress;

                _context.SaveChanges();

                return true;
            }
            catch (Exception _ex)
            {
                // TODO
                return false;
            }
        }
    }
}
