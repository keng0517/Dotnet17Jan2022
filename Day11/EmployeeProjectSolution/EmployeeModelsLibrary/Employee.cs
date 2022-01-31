using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelsLibrary
{
    public class Employee
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public int emp_age { get; set; }




        public void GetEmployeeDetails()
        {
            Console.WriteLine("Please enter the employee name");
            emp_name = Console.ReadLine();

            Console.WriteLine("Please enter the employee's age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid entry for age. Please try again...");
            }
            emp_age = age;
        }


        public override string ToString()
        {
            return "Employee ID " + emp_id
                + "\nEmployee Name " + emp_name
                + "\nEmployee Age " + emp_age;
        }
    }
}
