using System;
using System.IO;

namespace BrainfuckInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "../../bf.txt";
            string content = File.ReadAllText(file);
            Interpreter i = new Interpreter(content);
            Console.Clear();
            i.Run();
            Console.ReadKey();
        }
    }
}