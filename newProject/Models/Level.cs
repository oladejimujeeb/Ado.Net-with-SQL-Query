namespace newProject.Models;

public class Level
{
    public int ID  {get;set;}
    public string Name  {get;set;}
    public int MaximumNumbeOfStudent  {get;set;}

    public Level(int id, string name, int maximumNumbeOfStudent)
    {
        ID = id;
        Name = name;
        MaximumNumbeOfStudent = maximumNumbeOfStudent;
    }
}