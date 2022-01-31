using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDALLibrary;
using EmployeeModelsLibrary;

namespace EmployeeProject
{
    internal class ManageMenu
    {
        List<Employee> employees;
        EmployeeDAL employeeDAL;
        

        public ManageMenu()
        {
            employeeDAL = new EmployeeDAL();
        }

        void GetAllEmployees()
        {
            employees = null;
            try
            {
                employees = employeeDAL.GetAllEmployees().ToList();
            }
            catch (NoEmployeeException npe)
            {
                Console.WriteLine(npe.Message);
            }
            catch (Exception npe)
            {
                Console.WriteLine("Something went wrong. Will fix soon...");
                Console.WriteLine(npe.Message);
            }
        }




        public void AddEmployees()
        {
           
            Employee employee = new Employee();

            employee.GetEmployeeDetails();
            try
            {
                employeeDAL.InsertNewEmployee(employee);

            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add the employee");
                Console.WriteLine(e.Message);
            }
        }



        public void EditEmployeeAge()
        {
            int id = GetIdFromUser();
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Invalid Employee Id. Cannot edit");
                return;
            }
            Console.WriteLine("The employee for you have chosen to edit age");
            PrintEmployee(employee);
            int age;
            Console.WriteLine("Please enter the new age");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid input for age. Please try again...");
            }
            employee.emp_age = age;
            if (employeeDAL.UpdateEmployeeAge (id, ((int)age)))
                Console.WriteLine("Updated. New Details");
            PrintEmployee(employee);
        }



        public void RemoveEmployee()
        {
            int id = GetIdFromUser();
            int idx = -1;

            try
            {
                idx = employees.SingleOrDefault(e => e.emp_id == id).emp_id;
            }
            catch (Exception)
            {
                Console.WriteLine("No such employee");
            }

            Employee employee = GetEmployeeById(id);
            if (idx != -1)
            {
                Console.WriteLine("Do you want to delete the following employee???");
                PrintEmployee(employee);
                string check = Console.ReadLine();
                if (check == "yes")
                {
                    if (employeeDAL.RemoveEmployee(id))
                        Console.WriteLine("Removed successfully");
                    employees.RemoveAt(idx);
                }
                    
            }

        }


        public void PrintSingleEmployeeByID()
        {
            int id = GetIdFromUser();
            Employee employee = GetEmployeeById(id);
            if (employee != null)
            {
                PrintEmployee(employee);
            }
            else
                Console.WriteLine("No such pizza");
        }


        public void PrintEmployees()
        {
            GetAllEmployees();
            var sortedPizzas = employees.OrderBy(e => e.emp_id);
            foreach (var item in sortedPizzas)
            {
                if (item != null)
                    PrintEmployee(item);
            }
        }





        int GetIdFromUser()
        {
            Console.WriteLine("Please enter the employee id");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry Employee ID. Please try again...");
            }
            return id;
        }


        public Employee GetEmployeeById(int id)
        {
            GetAllEmployees();
            Employee employee = employees.SingleOrDefault(e => e.emp_id == id);
            return employee;
        }


        private void PrintEmployee(Employee item)
        {

            Console.WriteLine("**************************");
            Console.WriteLine(item);
            Console.WriteLine("**************************");
        }

    }
}
