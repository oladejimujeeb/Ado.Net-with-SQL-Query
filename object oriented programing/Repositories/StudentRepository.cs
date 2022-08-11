using System;
namespace object_oriented_programing.Models
{
    public class StudentRepository
    {
        List<Student> students = new List<Student>();
        string file = "C:\\Users\\User\\Desktop\\code learners hub\\object oriented programing\\Files\\studentFile.txt";
        public StudentRepository()
        {
            ReadStudentsFromFile();
        }
        private void ReadStudentsFromFile()
        {
            try
            {
                if (File.Exists(file))
                {
                    var allStudents = File.ReadAllLines(file);
                    foreach (var s in allStudents)
                    {
                        Student student = Student.ToStudent(s);
                        students.Add(student);

                    }
                }
                else
                {
                    string path = "C:\\Users\\User\\Desktop\\code learners hub\\object oriented programing\\Files";
                    Directory.CreateDirectory(path);
                    string filename ="studentFile.txt";
                    string fullpath = Path.Combine(path, filename);
                    File.Create(fullpath);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                
            }
        }
        public Student Register()
        {
            Console.Write("Enter Student First Name; ");
            var firstname = Console.ReadLine();
            Console.Write("Enter Student Last Name; ");
            var lastname = Console.ReadLine();
            Console.Write("Enter Student Id; ");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Phone number; ");
            var phone = Console.ReadLine();
            Console.Write("Enter Student Email; ");
            var email = Console.ReadLine();
            Console.Write("Enter Student Address; ");
            var address = Console.ReadLine();
            Console.Write("Enter Student Age; ");
            var age = Convert.ToInt32(Console.ReadLine());
            var student = new Student(id, firstname, lastname, age, address, phone, email);
            students.Add(student);
            AddStudentToFile(student);

            return student;
        }
        
        public void UpdateStudent()
        {
            Console.Write("Enter the id of student to update: ");
            var stuId = Convert.ToInt32(Console.ReadLine());
            var student = GetStudentById(stuId);
            if (student != null)
            {
                Console.Write("Enter Student First Name; ");
                var firstname = Console.ReadLine();
                Console.Write("Enter Student Last Name; ");
                var lastname = Console.ReadLine();
                Console.Write("Enter Student Age; ");
                var age = Convert.ToInt32(Console.ReadLine());

                student.FirstName = firstname;
                student.LastName = lastname;
                student.Age = age;
                RefreshFile();
                Console.WriteLine($"Student with id:{stuId} update Successfully.");
            }
            else
            {
                Console.WriteLine($"Student with id:{stuId} does not exist.");
            }
        }
        private void AddStudentToFile(Student student)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(file, true))
                {
                    write.WriteLine(student.ToString());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void RefreshFile()
        {
            try
            {
                using (StreamWriter write = new StreamWriter(file))
                {
                    foreach (var student in students)
                    {
                        write.WriteLine(student.ToString());
                    }
                }
            }
            catch(Exception e)
            {
               Console.WriteLine(e.Message);
                
            }
        }
        public Student GetStudentById(int id)
        {
            foreach (var student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }
        public void DeleteStudent()
        {
            Console.Write("Enter the id of the student to update:");
            var id = Convert.ToInt32(Console.ReadLine());
            var student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
                RefreshFile();
                Console.WriteLine($"Student with id: {id} deleted successfully.");

            }
            else
            {
                Console.WriteLine($"Student with id: {id} Can not be found");
            }
        }
        private void PrintStudent(Student student)
        {
            Console.WriteLine(student.ToString());
        }
        public void GetAllStudent()
        {
            if(students.Count==0)
            {
                Console.WriteLine("There is no record available");
            }
            else
            {
                foreach(var student in students)
                {
                    PrintStudent(student);
                }
            }
        }
        public void GetStudent()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No student found.");
            }
            else
            {
                Console.Write("Enter the id of student:");
                var id = Convert.ToInt32(Console.ReadLine());
                foreach (var student in students)
                {
                    if (student.Id == id)
                    {
                        Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age} {student.Email}");
                    }
                }
            }
        }
    }
    
}