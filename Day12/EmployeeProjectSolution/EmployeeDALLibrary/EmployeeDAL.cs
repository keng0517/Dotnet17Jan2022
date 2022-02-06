using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeModelsLibrary;
using System.Data;

namespace EmployeeDALLibrary
{
    public class EmployeeDAL
    {

        public EmployeeDAL()
        {
        }

        public ICollection<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("proc_GetAllEmployees", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(ds);
            Employee employee;

            if (ds.Tables[0].Rows.Count == 0)
                throw new NoEmployeeException();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                employee = new Employee();
                employee.emp_id = Convert.ToInt32(item[0]);
                employee.emp_name = item[1].ToString();
                employee.emp_age = Convert.ToInt32(item[2]);

                employees.Add(employee);
            }
            return employees;
        }
        public bool InsertNewEmployee(Employee employee)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_name", employee.emp_name);
            cmd.Parameters.AddWithValue("@emp_age", employee.emp_age);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }

            conn.Close();
            return false;
        }
        public bool UpdateEmployeeAge(int id, int age)
        {
            SqlCommand cmd = new SqlCommand("proc_UpdateEmployeeAge", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", id);
            cmd.Parameters.AddWithValue("@emp_age", age);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
                
            conn.Close();
            return false;
        }

        public bool RemoveEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand("proc_RemoveEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", id);

            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }

            conn.Close();
            return false;
        }

    }
}
