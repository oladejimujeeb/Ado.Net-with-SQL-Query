namespace newProject.Models;

public class Course
{
    public int ID {get;set;}
    public string Name  {get;set;}
    public string Code  {get;set;}
    public string Description  {get;set;}

    public Course(int id, string name, string code, string description)
    {
        ID = id;
        Name = name;
        Code = code;
        Description = description;
    }
}