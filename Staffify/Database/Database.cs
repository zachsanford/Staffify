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

                _context.Employees.AddRange(_employeesToAdd);
                _context.SaveChanges();
                Log.Information("Data added to the StaffifyDB Employees table.");
                Log.Information("Closing database connection.");
            }
        }
    }

    // Inherited Methods
    // TODO - Add exception handling to all API operations
    public bool CreateRecord(Employee _employeeToCreate)
    {
        using (DatabaseContext _context = new())
        {
            try
            {
                Log.Information("Making database connection.");
                _context.Employees.Add(_employeeToCreate);
                _context.SaveChanges();
                Log.Information("Successfully created new record in the StaffifyDB Employees table.");
                Log.Information("Closing database connection.");
                return true;
            }
            catch (Exception _ex)
            {
                Log.Error("Unsuccessful record creation in the StaffifyDB Employees table.");
                Log.Error("ERROR MESSAGE");
                Log.Error(_ex.ToString());
                Log.Information("Closing database connection.");
                return false;
            }
        }
    }

    public List<Employee> GetRecords()
    {
        using (DatabaseContext _context = new())
        {
            try
            {
                Log.Information("Making database connection.");
                List<Employee> _employees = _context.Employees.ToList();
                Log.Information("Returning all records from the StaffifyDB Employees table.");
                Log.Information("Closing database connection.");
                return _employees;
            }
            catch (Exception _ex)
            {
                Log.Error("Unsuccessful retrieval of records from the StaffifyDB Employees table.");
                Log.Error("ERROR MESSAGE");
                Log.Error(_ex.ToString());
                Log.Information("Closing database connection.");
                return new List<Employee>
                {
                    new Employee
                    {
                        EmployeeId = 999999,
                        Name = "Database Error - Check Logs",
                        PhoneNumber = "Database Error - Check Logs",
                        EmailAddress = "Database Error - Check Logs"
                    }
                };
            }
        }
    }

    public Employee GetSingleRecord(int _employeeRecordId)
    {
        using (DatabaseContext _context = new())
        {
            try
            {
                Log.Information("Making database connection.");
                Employee _employee = _context.Employees.Single(record => record.Id == _employeeRecordId);
                Log.Information($"Returning record from the StaffifyDB Employees table. Record Id: {_employeeRecordId}");
                Log.Information("Closing database connection.");
                return _employee;
            }
            catch (Exception _ex)
            {
                Log.Error($"Unsuccessful retrieval of record from the StaffifyDB Employees table. Record Id: {_employeeRecordId}");
                Log.Error("ERROR MESSAGE");
                Log.Error(_ex.ToString());
                Log.Information("Closing database connection.");
                return new Employee
                {
                    EmployeeId = 999999,
                    Name = "Database Error - Check Logs",
                    PhoneNumber = "Database Error - Check Logs",
                    EmailAddress = "Database Error - Check Logs"
                };
            }
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
                Log.Information($"Updating record in the StaffifyDB Employees table. Record Id: {_updatedEmployeeInformation.Id}");
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
                Log.Error($"Unsuccessful update in the StaffifyDB Employees table. Record Id: {_updatedEmployeeInformation.Id}");
                Log.Error("ERROR MESSAGE");
                Log.Error(_ex.ToString());
                Log.Information("Closing database connection.");
                return false;
            }
        }
    }

    public bool DeleteRecord(int _recordToDelete)
    {
        using (DatabaseContext _context = new())
        {
            try
            {
                Log.Information("Making database connection.");
                Employee _employeeToDelete = _context.Employees.Single(record => record.Id == _recordToDelete);
                _context.Employees.Remove(_employeeToDelete);
                _context.SaveChanges();
                Log.Information($"Deleting record from the StaffifyDB Employees table. Record Id: {_employeeToDelete.Id}");
                Log.Information("Closing database connection.");
                return true;
            }
            catch (Exception _ex)
            {
                Log.Error($"Unsuccessful delete in the StaffifyDB Employees table. Record ID: {_recordToDelete}");
                Log.Error("ERROR MESSAGE");
                Log.Error(_ex.ToString());
                Log.Information("Closing database connection");
                return false;
            }
        }
    }
}
