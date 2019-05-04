using System;

namespace toy_robot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**Toy Robot**");
            Command command = new Command(new Robot());
            while (true)
            {
                Console.WriteLine("Please Enter A Command:");
                try{
                    string result = command.Execute(Console.ReadLine());
                    if(result != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(result + "\n");
                    }
                } catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }

                Console.ResetColor();
            }
        }
    }
}
