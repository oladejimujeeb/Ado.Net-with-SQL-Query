using object_oriented_programing.Models;
namespace object_oriented_programing.Menu
{
    public class StudentMenu
    {
        StudentRepository student = new StudentRepository();

        public void StuMenu()
        {
            while(true)
            {
                Console.WriteLine("Enter 1 to register student:");
                Console.WriteLine("Enter 2 to update student:");
                Console.WriteLine("Enter 3 to get student with id:");
                Console.WriteLine("Enter 4 to get all student:");
                Console.WriteLine("Enter 5 to delete student:");
                Console.WriteLine("Enter 6 to exit:");
                Console.Write("Input: ");
                
                int input = Convert.ToInt32(Console.ReadLine());
                if(input<=5)
                {   switch(input)
                    {
                        case 1:
                            student.Register();
                            break;
                        case 2:
                            student.UpdateStudent();
                            break;
                        case 3:
                            student.GetStudent();
                            break;
                        case 4:
                            student.GetAllStudent();
                            break;
                        case 5:
                            student.DeleteStudent();
                            break;
                        default:
                            break;
                    }
                }
                else
                    break;
            }
        }
    }
}