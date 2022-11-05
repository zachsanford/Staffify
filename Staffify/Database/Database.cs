using Staffify.Models.Data;
using Serilog;

namespace Staffify.Database;

public class Database : IDatabase<Employee>
{
    // Constructor
    public Database()
    {
        // Add Test Data
        using (DatabaseContext _context = new())
        {
            Log.Information("Making database connection.");

            if (!_context.Employees.Any())
            {
                Log.Information("No data in Employees table in the StaffifyDB. Adding data.");

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
                Log.Information("Data added to the StaffifyDB Employees table.");
                Log.Information("Closing database connection.");
            }
        }
    }

    // Inherited Methods
    public List<Employee> GetRecords()
    {
        using (DatabaseContext _context = new())
        {
            Log.Information("Making database connection.");
            List<Employee> _employees = _context.Employees.ToList();
            Log.Information("Returning all records from the StaffifyDB Employees table.");
            Log.Information("Closing database connection.");
            return _employees;
        }
    }

    public Employee GetSingleRecord(int _employeeRecordId)
    {
        using (DatabaseContext _context = new())
        {
            Log.Information("Making database connection.");
            Employee _employee = _context.Employees.Single(record => record.Id == _employeeRecordId);
            Log.Information($"Returning record from the StaffifyDB Employees table. Record Id: {_employeeRecordId}");
            Log.Information("Closing database connection.");
            return _employee;
        }
    }

    public bool UpdateSingleRecord(Employee _updatedEmployeeInformation)
    {
        using (DatabaseContext _context = new())
        {
            Log.Information("Making database connection.");
            try
            {
                Employee _existingEmployee = _context.Employees.Single(record => record.Id == _updatedEmployeeInformation.Id);
                Log.Information($"Updating record in the Staffify Employees table. Record Id: {_updatedEmployeeInformation.Id}");
                _existingEmployee.EmployeeId = _updatedEmployeeInformation.Id;
                _existingEmployee.Name = _updatedEmployeeInformation.Name;
                _existingEmployee.PhoneNumber = _updatedEmployeeInformation.PhoneNumber;
                _existingEmployee.EmailAddress = _updatedEmployeeInformation.EmailAddress;

                _context.SaveChanges();
                Log.Information($"Successful update. Record Id: {_updatedEmployeeInformation.Id}");
                Log.Information("Closing database connection.");

                return true;
            }
            catch (Exception _ex)
            {
                Log.Error($"Unsuccessful update in the Staffify Employees table. Record Id: {_updatedEmployeeInformation.Id}");
                Log.Error("ERROR MESSAGE");
                Log.Error(_ex.ToString());
                return false;
            }
        }
    }
}
