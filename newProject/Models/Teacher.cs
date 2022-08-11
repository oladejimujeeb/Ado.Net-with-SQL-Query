namespace newProject.Models;

public class Teacher:Person
{
    public string StaffID  {get;set;}

    public Teacher(string firstName, string lastName, int age, string address, string phone, string email, string password, string hashsalt, string departmentId, string staffId)
    {
        StaffID = staffId;
    }
}