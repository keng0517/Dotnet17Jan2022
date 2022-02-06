using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFProject
{
    internal class Program
    {

        public void mainMenu()
        {
            int mainChoice;

            do
            {

                Console.WriteLine("\nWelcome to Day 12 Assignment Application");
                Console.WriteLine("[1] Add  Department");
                Console.WriteLine("[2] Edit Department Name");
                Console.WriteLine("[3] Print Department");
                Console.WriteLine("[4] Add Employee");
                Console.WriteLine("[5] Edit Employee Age");
                Console.WriteLine("[6] Edit Employee Department");
                Console.WriteLine("[7] Print All Employees");
                Console.WriteLine("[0] Exit");
                Console.Write("> ");

                while (!int.TryParse(Console.ReadLine(), out mainChoice))
                {
                    Console.WriteLine("\n!!! Please enter number [0 to 7] only. !!!\n");


                    Console.WriteLine("\nWelcome to Day 12 Assignment Application");
                    Console.WriteLine("[1] Add  Department");
                    Console.WriteLine("[2] Edit Department Name");
                    Console.WriteLine("[3] Print Department");
                    Console.WriteLine("[4] Add Employee");
                    Console.WriteLine("[5] Edit Employee Age");
                    Console.WriteLine("[6] Edit Employee Department");
                    Console.WriteLine("[7] Print All Employees");
                    Console.WriteLine("[0] Exit");
                    Console.Write("> ");
                }

                try
                {
                    switch (mainChoice)
                    {
                        case 1:
                            break;

                        case 2:
                            break;

                        case 0:
                            break;

                        default:
                            Console.WriteLine("\n!!! Please enter number [0 to 7] only. !!!\n");
                            break;

                    }

                }
                catch (NullReferenceException nre)
                {
                    Console.WriteLine("Null by mistake");
                    Console.WriteLine(nre.Message);
                }
                catch (ArgumentOutOfRangeException aore)
                {
                    Console.WriteLine("The employee could not be found");
                    Console.WriteLine(aore.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("expecting a number");
                    Console.WriteLine(fe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong");
                    Console.WriteLine(e.Message);
                }

            } while (mainChoice != 0);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.mainMenu();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
