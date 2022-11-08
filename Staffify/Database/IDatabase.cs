namespace Staffify.Database;

public interface IDatabase<T>
{
    /*
        v0.1.0
        Instructions only specify that the User Detail Page should "show the
        user's detail and give the ability to update fields", yet the images
        show an "Add" and "Delete" button. I am only going to include the
        view and update features per the instructions.

        v0.2.0
        Adding Create and Delete operations.
    */

    /*
        CREATE
    */

    // Create a new record in the table
    public bool CreateRecord(T _t);

    /*
        READ
    */

    // Returns all of the table
    public List<T> GetRecords();

    // Returns a single record
    public T GetSingleRecord(int _x);

    /*
        UPDATE
    */

    // Updates an individual Employee
    public bool UpdateSingleRecord(T _t);

    /*
        DELETE
    */

    // Deletes a single record in the table
    public bool DeleteRecord(int _x);
}
