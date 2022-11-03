using Staffify.Models.Data;

namespace Staffify.Database;

public interface IDatabase
{
    #region Employees Table

    /*
        Instructions only specify that the User Detail Page should "show the
        user's detail and give the ability to update fields", yet the images
        show an "Add" and "Delete" button. I am only going to include the
        view and update features per the instructions.
    */

    /*
        READ
    */

    // Returns all of the Employees in the database
    public List<Employee> GetEmployees();

    // Returns a single employee
    public Employee GetSingleEmployee(int _employeeRecordId);

    /*
        UPDATE
    */

    // Updates an individual Employee
    public bool UpdateSingleEmployee(Employee _updatedEmployeeInformation);

    #endregion
}
