using EmployeeModelsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeModelsLibrary
{
    public class Department
    {
        [Key]
        public int dpm_id { get; set; }
        public string dpm_name { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public void GetDepartmentDetails()
        {
            Console.WriteLine("Please enter the department name");
            dpm_name = Console.ReadLine();


        }


        public override string ToString()
        {
            return "Department ID       : " + dpm_id
                + "\nDepartment Name    : " + dpm_name;
        }
    }
}
