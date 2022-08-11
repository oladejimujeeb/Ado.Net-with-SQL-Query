using MySql.Data.MySqlClient;
using newProject.Models;

namespace newProject.Respositories;

public class DepartmentRepository
{
    MySqlConnection _connection;

    public DepartmentRepository(MySqlConnection connection)
    {
        _connection = connection;
    }

    public bool CreateDept()
    {
        Console.Write("Enter Department name:");
        string name = Console.ReadLine();
        Console.Write("Enter department code:");
        string code = Console.ReadLine();
        Console.Write("Enter department description:");
        string description = Console.ReadLine();
        try
        {
            _connection.Open();
            string query = "insert into departments(name, code, description) values('"+name+"','"+code+"','"+description+"')";
            MySqlCommand command = new MySqlCommand(query,_connection);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("Department created successfully");
                _connection.Close();
            }
        }
        catch(MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }

        return false;
    }

    public List<Department> GetAll()
    {
        List<Department> departments = new List<Department>();
        try
        {
            _connection.Open();
            string query = "select * from departments";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                var code = reader.GetString(2);
                var description = reader.GetString(3);
                var department = new Department(id, name, code, description);
                departments.Add(department);
            }

            _connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }

        return departments;
    }

    private Department Find(int id)
    {
        try
        {
            _connection.Open();
            string query = "select * from departments where id='"+id+"'";
            MySqlCommand command = new MySqlCommand(query, _connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader.GetString(1);
                var code = reader.GetString(2);
                var description = reader.GetString(3);
                _connection.Close();
                return new Department( id,name,code,description);
            }

        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex);
        }
        
        return null;
    }

    public void GetDepartments()
    {
        var departments = GetAll();
        foreach (var dept in departments)
        {
            Console.WriteLine($"{dept.ID}\t{dept.Name}\t{dept.Code}\t{dept.Description}");
        }
    }

    public void GetADepartment()
    {
        Console.Write("Enter the Id of the Department:");
        int Id = Convert.ToInt32(Console.ReadLine());
        var dept = Find(Id);
        if (dept != null)
        {
            Console.WriteLine($"{dept.ID}\t{dept.Name}\t{dept.Code}\t{dept.Description}");
        }
        else
        {
            Console.WriteLine("Department not found");
        }
    }

    public bool UpdateDept()
    {
        Console.Write("Enter the id of the department to update:");
        int id = Convert.ToInt32(Console.ReadLine());
        var dept = Find(id);
        _connection.Open();
        if (dept !=null)
        {
            try
            {
                Console.Write("Enter Department name:");
                string name = Console.ReadLine();
                Console.Write("Enter department code:");
                string code = Console.ReadLine();
                string query = "update departments set name ='" + name + "', code='"+code+ "'where id='"+id+"'";
                MySqlCommand command = new MySqlCommand(query, _connection);
                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    Console.WriteLine("Department updated sucessfully.");
                    _connection.Close();
                    return true;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("Department with id"+id+"does not exist.");
        }
        _connection.Close();
        return false;
    }

    public void Delete()
    {
        Console.Write("Enter the id of the department you want to delete:");
        int id = Convert.ToInt32(Console.ReadLine());
        var dept = Find(id);
        _connection.Open();
        if (dept !=null)
        {
            try
            {
                string query = "delete from departments where id='"+id+"'";
                MySqlCommand command = new MySqlCommand(query, _connection);
                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    Console.WriteLine("Department deleted sucessfully.");
                    _connection.Close();
                }
                else
                {
                    Console.WriteLine("Department with id"+id+"does not exist.");
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