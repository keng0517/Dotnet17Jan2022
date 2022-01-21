using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.numberPrinterQ1();
            //program.oddEvenCheckerQ2();
            //program.greatestFinderQ3();
            //program.greatestFinderQ4();
            //program.numbersBetweenMinMaxQ5();
            //program.primeOrNotQ6();
            //program.primeNumbersFinderQ7();
            //program.numsDivisibleBy7Q8();
            //program.sumOf4digitsQ9();
            //program.palindromeCheckerQ10();
            //program.myPowCalculatorQ11();
            program.isHappyNumberQ12();


            //Make a pause and the console
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }



        public void numberPrinterQ1()
        {
            int number;

            Console.Write("Please enter a number: ");
            number = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < number+1; i++)
            {
                Console.WriteLine(i);
            }
        }


        public void oddEvenCheckerQ2()
        {
            int number;

            Console.Write("Please enter a number: ");
            number = Convert.ToInt32(Console.ReadLine());

            if (number % 2 == 0)
                Console.WriteLine(number + " is even number.");
            else
                Console.WriteLine(number + " is odd number.");
        }


        public void greatestFinderQ3()
        {
            int number1, number2;

            Console.Write("Please enter 1st number: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter 2nd number: ");
            number2 = Convert.ToInt32(Console.ReadLine());

            if (number1 > number2)
                Console.WriteLine(number1 + " is the greatest");
            else if (number1 < number2)
                Console.WriteLine(number2 + " is the greatest");
            else
                Console.WriteLine("Both are the same.");
        }


        public void greatestFinderQ4()
        {
            int number1, number2, number3;

            Console.Write("Please enter 1st number: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter 2nd number: ");
            number2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter 3rd number: ");
            number3 = Convert.ToInt32(Console.ReadLine());

            if (number1 > number2)
            {
                if (number1 > number3)
                    Console.WriteLine(number1+" is the greatest");
                else
                    Console.WriteLine(number3+" is the greatest");
            }
            else if (number2 > number3)
                Console.WriteLine(number2+" is the greatest");
            else
                Console.WriteLine(number3+" is the greatest");
        }


        public void numbersBetweenMinMaxQ5()
        {
            int minNum, maxNum;

            Console.Write("Please enter minimum number: ");
            minNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter maximum number: ");
            maxNum = Convert.ToInt32(Console.ReadLine());

            if (minNum > maxNum)
                Console.WriteLine("Minimum number is bigger than maximum number.");
            else if (minNum < maxNum)
            {
                for(int i = 1; i < (maxNum - minNum); i++)
                {
                    Console.WriteLine(minNum + i);
                }
            }
            else
                Console.WriteLine("Both are the same.");
        }


        public void primeOrNotQ6()
        {
            bool prime = false;
            int num;

            Console.Write("Please enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());

            prime = primeChecker(num);

            if (prime == true)
                Console.WriteLine("It is prime number.");
            else
                Console.WriteLine("It is not prime number.");
        }


        public void primeNumbersFinderQ7()
        {
            int minNum, maxNum;
            bool prime;

            Console.Write("Please enter minimum number: ");
            minNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter maximum number: ");
            maxNum = Convert.ToInt32(Console.ReadLine());

            if (minNum > maxNum)
                Console.WriteLine("Minimum number is bigger than maximum number.");
            else if (minNum < maxNum)
            {
 
                for (int i = 1; i < (maxNum - minNum); i++)
                {
                    
                    prime = primeChecker(minNum + i);

                    if (prime == true)
                        Console.WriteLine(minNum + i);

                }
            }
            else
                Console.WriteLine("Both are the same.");
        }


        public void numsDivisibleBy7Q8()
        {
            int inputNum, sum = 0;
            Console.WriteLine("Enter negative number to break the looping");

            do
            {
                Console.Write("Please enter a number: ");
                inputNum = Convert.ToInt32(Console.ReadLine());

                if(inputNum % 7 == 0)
                    sum += inputNum;


            } while (inputNum >= 0);

            Console.WriteLine("Total sum of numbers which are divisible by 7 is "+sum);

        }


        public void sumOf4digitsQ9()
        {
            int num, sum = 0;
            int divNum = 1000;

            Console.Write("Please enter a 4 digit number: ");
            num = Convert.ToInt32(Console.ReadLine());


            for(int i = 0; i < 4; i++)
            {
                int digitSplit = num / divNum;
                num = num % divNum;
                divNum = divNum / 10;
                
                Console.WriteLine(digitSplit);
                sum += digitSplit;

            }

            Console.WriteLine("The sum is " + sum);
        }

        public void palindromeCheckerQ10()
        {
            int num, original, reverse = 0, sum = 0;
            int divNum = 1000, mulNum = 1;

            Console.Write("Please enter a 4 digit number: ");
            num = Convert.ToInt32(Console.ReadLine());
            original = num;

            for (int i = 0; i < 4; i++)
            {
                int digitSplit = num / divNum;
                num = num % divNum;
                divNum = divNum / 10;


                reverse += digitSplit * mulNum;
                mulNum = mulNum * 10;

                sum += digitSplit;

            }

            if (reverse == original)
                Console.WriteLine(original + " is palindrome number.");
            else
                Console.WriteLine(original + " is not palindrome number.");

        }


        public void myPowCalculatorQ11()
        {
            int baseNum, powNum, powNum2;
            int ans = 1;

            Console.Write("Please enter the base number: ");
            baseNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter the power number: ");
            powNum = Convert.ToInt32(Console.ReadLine());
            powNum2 = powNum;

            while (powNum != 0)
            {
                ans *= baseNum;
                --powNum;
            }

            Console.WriteLine(baseNum +" power with "+ powNum2 + " equal to "+ans);
        }


        public void isHappyNumberQ12()
        {
            int num, num2 = 0 , result;

            Console.Write("Please enter a number : ");
            num = Convert.ToInt32(Console.ReadLine());
            result = num;

            while (result != 1 && result != 4)
            {
                result = happyNumVerification(result);
            }

            if (result == 1)
                Console.WriteLine(num + " is a happy number");
            else if (result == 4)
                Console.WriteLine(num + " is not a happy number");

        }



        public int happyNumVerification(int num)
        {
            int rem = 0, sum = 0;

            while (num > 0)
            {
                rem = num % 10;
                sum = sum + (rem * rem);
                num = num / 10;
            }
            return sum;
        }



        public bool primeChecker(int num)
        {
            int i;

            for (i = 2; i <= (num - 1); i++)
            {
                if (num % i == 0)
                    return false;
            }

            if (i == num)
            {
                return true;
            }

            return false;
        }




    }

    
}
