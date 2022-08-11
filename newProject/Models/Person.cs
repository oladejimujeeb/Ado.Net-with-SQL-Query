namespace newProject.Models;

public abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Hashsalt { get; set; }
    public string DepartmentId { get; set; }

    public Person()
    {
        
    }

    public Person(string firstName, string lastName, int age, string address, string phone, string email, string password, string hashsalt, string departmentId)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Address = address;
        Phone = phone;
        Email = email;
        Password = password;
        Hashsalt = hashsalt;
        DepartmentId = departmentId;
    }
    
}