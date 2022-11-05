namespace Staffify.Database;

public interface IDatabase<T>
{
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
    public List<T> GetRecords();

    // Returns a single employee
    public T GetSingleRecord(int _x);

    /*
        UPDATE
    */

    // Updates an individual Employee
    public bool UpdateSingleRecord(T _t);
}
