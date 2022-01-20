using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    internal class Calculator
    {
        int number1, number2;

        public void takeNumbers()
        {
            Console.WriteLine("Please enter the first number");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the second number");
            number2 = Convert.ToInt32(Console.ReadLine());
        }

        public void add()
        {
            takeNumbers(); 

            int sum = number1 + number2;
            Console.WriteLine("The sum of " + number1 + " and" + number2 + " is " + sum);
        }

        public void Product()
        {
            takeNumbers();
            int product = number1 * number2;
            Console.WriteLine("The product of "+number1+" and "+number2+" is "+product);
        }
    }
}
