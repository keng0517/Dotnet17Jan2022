using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    internal class Program
    {

        //Method Header
        void PrintName()
        {//Method Body
            Console.WriteLine("Hello G3");
        }

        void PrintAnyName(string name)
        {
            Console.WriteLine("Hello" + name);
        }

        void Greet(string greet)
        {
            string name;
            Console.WriteLine("Please enter your name");
            name = Console.ReadLine();
            Console.WriteLine(greet+" "+name);        }

        static void Main(string[] args)
        {

            Program program = new Program();
            //program.PrintName(); //Method Call
            //program.PrintAnyName("Raindy");
            //program.Greet("Hi!!");
            //Calculator calc = new Calculator();
            //calc.add();

            Statements stat = new Statements();
            stat.IterationWithWhile();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
