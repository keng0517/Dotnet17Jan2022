using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementModelsLibrary;
using System.Globalization;

namespace ClinicManagementProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Program program = new Program();
            program.mainMenu();

            Console.WriteLine("\n\nThanks for using Raindy's Clinic Management System\nPress any key to continue...");
            Console.ReadKey();

        }

        public void mainMenu()
        {
            int mainChoice;
            ManageMenu menu = new ManageMenu();

            
            do
            {
                Console.WriteLine("\n\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                Console.WriteLine("Hi. Welcome to Raindy's Clinic Management System");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                Console.WriteLine("\nAre you a patient or doctor ?");
                Console.WriteLine("[1] Doctor");
                Console.WriteLine("[2] Patient");
                Console.WriteLine("[0] Exit");
                Console.Write("> ");

                while (!int.TryParse(Console.ReadLine(), out mainChoice))
                {
                    Console.WriteLine("\n!!! Please enter number [0 to 2] only. !!!\n");

                    Console.WriteLine("\n\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    Console.WriteLine("Hi. Welcome to Raindy's Clinic Management System");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine("\nAre you a patient or doctor ?");
                    Console.WriteLine("[1] Doctor");
                    Console.WriteLine("[2] Patient");
                    Console.WriteLine("[0] Exit");
                    Console.Write("> ");
                }

                switch (mainChoice)
                {
                    case 1:
                        menu.doctorMainMenu();
                        break;

                    case 2:
                        menu.patientMainMenu();
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("\n!!! Please enter number [0 to 2] only. !!!\n");
                        break;

                }

            } while(mainChoice != 0);
        }

        public void doctorMenu()
        {





            //menu Selection
            int mainChoice;

            do
            {

                Console.WriteLine("Are you a patient or doctor ?");
                Console.WriteLine("[1] Doctor");
                Console.WriteLine("[2] Patient");
                Console.WriteLine("[0] Exit\n");
                Console.Write("> ");

                while (!int.TryParse(Console.ReadLine(), out mainChoice))
                {
                    Console.WriteLine("\n!!! Please enter number [0 to 2] only. !!!\n");

                    Console.WriteLine("Are you a patient or doctor ?");
                    Console.WriteLine("[1] Doctor");
                    Console.WriteLine("[2] Patient");
                    Console.WriteLine("[0] Exit\n");
                    Console.Write("> ");
                }

                switch (mainChoice)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("\n!!! Please enter number [0 to 2] only. !!!\n");
                        break;

                }

            } while (mainChoice != 0);
        }

    }
}
