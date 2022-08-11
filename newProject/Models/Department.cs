namespace newProject.Models;

public class Department
{
    public int ID  {get;set;}
    public string Name  {get;set;}
    public string Code  {get;set;}
    public string Description  {get;set;}

    public Department(int id, string name, string code, string description)
    {
        ID = id;
        Name = name;
        Code = code;
        Description = description;
    }

    
}