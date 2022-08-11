namespace newProject.Models;

public class Student:Person
{
    public string Matricnumber  {get;set;}
    public string LevelID {get;set;}

    public Student(string firstName, string lastName, int age, string address, string phone, string email, string password, string hashsalt, string departmentId,string matricnumber, string levelId)
    {
        Matricnumber = matricnumber;
        LevelID = levelId;
    }
}