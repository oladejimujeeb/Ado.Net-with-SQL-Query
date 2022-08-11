namespace object_oriented_programing.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

        public Student(int id, string firstname, string lastname, int age, string address, string phone, string email)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Age = age;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Id}\t{FirstName}\t{LastName}\t{Age}\t{Address}\t{Phone}\t{Email}";
        }
        public static Student ToStudent(string student)
        {
            var studentStr = student.Split("\t");
            int id = int.Parse(studentStr[0]);
            string firstname = studentStr[1];
            string lastname = studentStr[2];
            int age = int.Parse(studentStr[3]);
            string address = studentStr[4];
            string phone = studentStr[5];
            string email = studentStr[6];

            return new Student(id, firstname, lastname, age, address, phone, email);
        }
    }

}