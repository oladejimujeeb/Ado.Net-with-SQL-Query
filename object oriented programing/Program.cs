// See https://aka.ms/new-console-template for more information
using object_oriented_programing.Menu;
namespace object_oriented_programing
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Menu();
        }
    }
}