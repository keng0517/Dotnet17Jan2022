using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelsLibrary
{
    public class Employee
    {
        [Key]
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public int emp_age { get; set; }

        public int dpm_id { get; set; }

        [ForeignKey("dpm_id")]
        public Department department { get; set; }


        public void GetEmployeeDetails()
        {
            Console.WriteLine("Please enter the employee's name");
            emp_name = Console.ReadLine();

            Console.WriteLine("Please enter the employee's age");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid entry for age. Please try again...");
            }
            emp_age = age;

            Console.WriteLine("Please select one department by entering the new department ID");
            int input_id;
            while (!int.TryParse(Console.ReadLine(), out input_id))
            {
                Console.WriteLine("Invalid entry for department ID. Please try again...");
            }
            dpm_id = input_id;
        }

        

        public override string ToString()
        {
            return "Employee ID             : " + emp_id
                + "\nEmployee Name          : " + emp_name
                + "\nEmployee Age           : " + emp_age
                + "\nEmployee Department ID : " + dpm_id;
        }
    }
}
