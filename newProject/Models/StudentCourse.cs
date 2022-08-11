namespace newProject.Models;

public class StudentCourse
{
    public int ID  {get;set;}
    public string StudentId  {get;set;}
    public string CourseId {get;set;}

    public StudentCourse(int id, string studentId, string courseId)
    {
        ID = id;
        StudentId = studentId;
        CourseId = courseId;
    }
}