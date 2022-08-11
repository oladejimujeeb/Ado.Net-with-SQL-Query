using MySql.Data.MySqlClient;
using newProject.Respositories;

namespace newProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;database=schoolapp;port=3306;password=oladejimujib@gmail.com";
            MySqlConnection connection = new MySqlConnection(connectionString);
            DepartmentRepository departmentRepository = new DepartmentRepository(connection);
            //departmentRepository.CreateDept();
            //departmentRepository.GetADepartment();
            //departmentRepository.UpdateDept();
            //departmentRepository.Delete();
            CourseRepository courseRepository = new CourseRepository(connection);
            //courseRepository.CreateCourse();
            courseRepository.GetAllCourses();
            //courseRepository.DeleteCourse();
            
            
        }
    }
}

