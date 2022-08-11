using MySql.Data.MySqlClient;
using newProject.Models;

namespace newProject.Respositories;

public class CourseRepository
{
    private MySqlConnection _connection;

    public CourseRepository(MySqlConnection connection)
    {
        _connection = connection;
    }

    public void CreateCourse()
    {
        Console.Write("Enter Course name:");
        string name = Console.ReadLine();
        Console.Write("Enter Course Code:");
        string code = Console.ReadLine();
        Console.Write("Course description:");
        string description = Console.ReadLine();
        try
        {
            _connection.Open();
            string query = "insert into courses (name,code,description) values ('" + name + "','" + code + "','" +
                           description + "')";
            MySqlCommand command = new MySqlCommand(query, _connection);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("Course created successfully");
                _connection.Close();
            }
        }
        catch (MySqlException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private Course FindCourse(int Id)
    {
        try
        {
            _connection.Open();
            string query = "select * from courses where id='"+Id+"'";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(1);
                var code = reader.GetString(2);
                var description = reader.GetString(3);
                _connection.Close();
                return new Course( Id,name,code,description);
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        
        return null;
    }

    public List<Course> AllCourses()
    {
        List<Course> courses = new List<Course>();
        try
        {
            _connection.Open();
            string query = "select * from courses";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var code = reader.GetString(2);
                var description = reader.GetString(3);
                Course course = new Course( id,name,code,description);
                courses.Add(course);
                
            }
            _connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        return courses;
    }

    public void GetAllCourses()
    {
        var courses = AllCourses();
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.ID}\t{course.Name}\t{course.Code}\t{course.Description}");
        }
    }

    public void GetACourse()
    {
        Console.Write("Enter the id of the Course:");
        int Id = Convert.ToInt32(Console.ReadLine());
        var cour = FindCourse(Id);
        if (cour !=null)
        {
            Console.WriteLine($"{cour.ID}\t {cour.Name}\t{cour.Code}\t{cour.Description}");
        }
        else
        {
            Console.WriteLine("Course not found");
        }
    }
    public void UpdateCourse()
    {
        Console.Write("Enter the id of the Course to update:");
        int id = Convert.ToInt32(Console.ReadLine());
        var cour = FindCourse(id);
        _connection.Open();
        if (cour !=null)
        {
            try
            {
                Console.Write("Enter course name:");
                string name = Console.ReadLine();
                Console.Write("Enter course code:");
                string code = Console.ReadLine();
                string query = "update courses set name ='" + name + "', code='"+code+ "'where id='"+id+"'";
                MySqlCommand command = new MySqlCommand(query, _connection);
                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    Console.WriteLine("Course updated sucessfully.");
                    _connection.Close();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Course with id"+id+"does not exist.");
        }
        _connection.Close();
        
    }
    public void DeleteCourse()
    {
        Console.Write("Enter the id of the course you want to delete:");
        int id = Convert.ToInt32(Console.ReadLine());
        var course = FindCourse(id);
        _connection.Open();
        if (course !=null)
        {
            try
            {
                string query = "delete from courses where id='"+id+"'";
                MySqlCommand command = new MySqlCommand(query, _connection);
                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    Console.WriteLine("Course deleted successfully.");
                    _connection.Close();
                }
                else
                {
                    Console.WriteLine("Courses with id"+id+"does not exist.");
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        _connection.Close();
    }
}