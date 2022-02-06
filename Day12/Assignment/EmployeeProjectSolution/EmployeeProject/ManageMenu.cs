using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDALEFLibrary;
using EmployeeModelsLibrary;

namespace EmployeeProject
{
    internal class ManageMenu
    {
        List<Employee> employees;
        List<Department> departments;
        EmployeeDALEF employeeDALEF;
        

        public ManageMenu()
        {
            employeeDALEF = new EmployeeDALEF();
        }


        /// <summary>
        /// /////////////Department//////////////////////////////
        /// </summary>
        public void AddDepartment()
        {
            Department dpm = new Department();

            dpm.GetDepartmentDetails();

            try
            {
                employeeDALEF.AddDepartment(dpm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not add the department");
                Console.WriteLine(e.Message);
            }
        }


        public void EditDepartment()
        {
            int id = GetIdFromUser();
            Department dept = GetDepartmentById(id);
            if (dept == null)
            {
                Console.WriteLine("Invalid Department Id. Cannot edit");
                return;
            }
            Console.WriteLine("The department for you have chosen to edit name");
            PrintDepartment(dept);
            
            Console.WriteLine("Please enter the new department name");
            string input_name = Console.ReadLine();

            dept.dpm_name = input_name;

            if (employeeDALEF.EditDepartment(id, input_name))
                Console.WriteLine("Updated. New Department Name");
            PrintDepartment(dept);
        }



        public void PrintDepartments()
        {
            GetAllDepartments();
            var sortedDepartments = departments.OrderBy(d => d.dpm_id);
            foreach (var item in sortedDepartments)
            {
                if (item != null)
                    PrintDepartment(item);
            }
        }



        public Department GetDepartmentById(int id)
        {
            GetAllDepartments();
            Department dept = departments.SingleOrDefault(d => d.dpm_id == id);
            return dept;
        }


        private void PrintDepartment(Department item)
        {

            Console.WriteLine("**************************");
            Console.WriteLine(item);
            Console.WriteLine("**************************");
        }


        void GetAllDepartments()
        {
            departments = null;
            try
            {
                departments = employeeDALEF.GetAllDepartments().ToList();
            }
            catch (NoDepartmentException npe)
            {
                Console.WriteLine(npe.Message);
            }
            catch (Exception npe)
            {
                Console.WriteLine("Something went wrong. Will fix soon...");
                Console.WriteLine(npe.Message);
            }
        }

        /// <summary>
        /// ////////////////Employees//////////////////////////////
        /// </summary>

        void GetAllEmployees()
        {
            employees = null;
            try
            {
                employees = employeeDALEF.GetAllEmployees().ToList();
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
                employeeDALEF.InsertNewEmployee(employee);

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
            if (employeeDALEF.UpdateEmployee(id, ((int)age)))
                Console.WriteLine("Updated. New Details");
            PrintEmployee(employee);
        }


        public void EditEmployeeDepartment()
        {
            int id = GetIdFromUser();
            Employee employee = GetEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Invalid Employee Id. Cannot edit");
                return;
            }
            Console.WriteLine("The employee for you have chosen to edit department");
            PrintEmployee(employee);

            int edit_dpm_id;
            PrintDepartments();
            Console.WriteLine("Please select one department by entering the new department ID");
            while (!int.TryParse(Console.ReadLine(), out edit_dpm_id))
            {
                Console.WriteLine("Invalid input for department ID. Please try again...");
            }

            employee.dpm_id = edit_dpm_id;
            if (employeeDALEF.UpdateEmployeeDepartment(id, ((int)edit_dpm_id)))
                Console.WriteLine("Updated. New Employee Department");
            PrintEmployee(employee);
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
            var sortedEmployees = employees.OrderBy(e => e.emp_id);
            foreach (var item in sortedEmployees)
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
