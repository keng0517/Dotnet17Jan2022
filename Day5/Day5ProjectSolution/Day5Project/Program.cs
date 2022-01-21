using ClinicModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create the methods to take input in each class
            //Override it in the inherited calss so that it takes teh appropriate details
            //Hint : Keep the common ones in the base
            //Override teh tostring method so that the details printed are complete


            ManageUser mu = new ManageUser();

            mu.userRegistration();


            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();  

        }
    }
}
