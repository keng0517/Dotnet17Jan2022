using EmployeeModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDALEFLibrary
{
    public class EmployeeDALEF
    {
        readonly EmployeeContext _employeeContext;

        public EmployeeDALEF()
        {
            _employeeContext = new EmployeeContext();
        }

        public bool AddDepartment(Department dpm)
        {
            _employeeContext.Departments.Add(dpm);
            _employeeContext.SaveChanges();

            return true;
        }



        /////////////Department///////////////////////////
        
        public bool EditDepartment(int id, string input_name)
        {
            Department dept = _employeeContext.Departments.SingleOrDefault(d => d.dpm_id == id);

            if (dept == null)
            {
                return false;
            }
                
            dept.dpm_name = input_name;

            _employeeContext.SaveChanges();

            return true;

        }

        public ICollection<Department> GetAllDepartments()
        {
            List<Department> departments = _employeeContext.Departments.ToList();
            if (departments.Count == 0)
                throw new NoDepartmentException();
            return departments;
        }


        /////////Employee////////////////////////////////
        ///



        public ICollection<Employee> GetAllEmployees()
        {
            List<Employee> employees = _employeeContext.Employees.ToList();
            if (employees.Count == 0)
                throw new NoEmployeeException();
            return employees;
        }


        public bool InsertNewEmployee(Employee emp)
        {
            _employeeContext.Employees.Add(emp);
            _employeeContext.SaveChanges();
            return true;
        }


        public bool UpdateEmployee(int id, int age)
        {
            Employee employee = _employeeContext.Employees.SingleOrDefault(e => e.emp_id == id);
            if (employee == null)
                return false;
            employee.emp_age = age;
            _employeeContext.SaveChanges();
            return true;
        }

        public bool UpdateEmployeeDepartment(int id, int edit_dpm_id)
        {
            Employee employee = _employeeContext.Employees.SingleOrDefault(e => e.emp_id == id);
            if (employee == null)
                return false;
            employee.dpm_id = edit_dpm_id;
            _employeeContext.SaveChanges();
            return true;
        }
    }
}
