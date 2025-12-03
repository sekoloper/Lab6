using System.Threading.Tasks;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;

            Console.WriteLine("Лабораторная 6\n~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("Задания:\n");
            Console.WriteLine("1 - коты и мяукающие объекты");
            Console.WriteLine("2 - дроби");
            Console.WriteLine("3 - для тестов\n");

            while (choice != 0)
            {
                choice = InputValidation.InputIntegerWithValidation("~~~~~~~~~~~~~~~~\nВведите номер задания или 0 для выхода:", 0, 8);
                Tasks.Choose(choice);
            }
        }
    }
}

