namespace object_oriented_programing.Menu
{
    public class MainMenu
    {
        StudentMenu regstudent = new StudentMenu();

        public void Menu()
        {
            Console.WriteLine($"Welcome to Victory Internation Nursery And Primary School, Abeokuta");
            
            regstudent.StuMenu();
        }
    }
}