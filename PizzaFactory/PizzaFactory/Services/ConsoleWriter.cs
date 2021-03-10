using System;

namespace PizzaFactory.Services
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}