using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace UnderstandingADOApplication
{
    class User
    {
        string password;
        public string Username { get; set; }
        public string Password { get
            {
                string mask = password.Substring(1, 2) + "**..";
                return mask;
            } 
            set {
                password = value;
            }
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return "Username : " + Username
                + "\nPassword : " + Password
                + "\nName : " + Name
                + "\nAge : " + Age;
        }
    }
    internal class Program
    {
        SqlConnection conn;
        SqlCommand cmdInsert,cmdSelect;
        public Program()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            //conn.Open();
            //Console.WriteLine("Connected");
        }
        User TakeUserDetailsFromConsole()
        {
            User user = new User();
            Console.WriteLine("Please enter your preferred username");
            user.Username = Console.ReadLine();
            do
            {
                Console.WriteLine("Please enter your password");
                user.Password = Console.ReadLine();
                Console.WriteLine("Please Retype the password");
                string password = Console.ReadLine();
                if (password == user.Password)
                {
                    break;
                }
                Console.WriteLine("Password Mismatch.");
                Console.WriteLine("Lets  try again!!!");
            } while (true);
            Console.WriteLine("Please enter your full name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Please enter your age");
            user.Age = Convert.ToInt32(Console.ReadLine());
            return user;
        }
        void RegisterUser()
        {
            cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "insert into tblUser values(@un,@pass,@name,@age)";
            cmdInsert.Connection = conn;
            User user = TakeUserDetailsFromConsole();
            try
            {
                cmdInsert.Parameters.Add("@un", SqlDbType.VarChar, 20);
                cmdInsert.Parameters[0].Value = user.Username;
                cmdInsert.Parameters.AddWithValue("@pass", user.Password);
                cmdInsert.Parameters.AddWithValue("@name", user.Name);
                cmdInsert.Parameters.AddWithValue("@age", user.Age);
                conn.Open();
                int result = cmdInsert.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("User Registrerd");
            }
            catch (SqlException se)
            {
                Console.WriteLine("Could not insert");
                Console.WriteLine(se.Message);
                Console.WriteLine("---------------------------");
                Console.WriteLine(se.StackTrace);
                Console.WriteLine("---------------------------");
            }
            catch (Exception se)
            {
                Console.WriteLine("Could not insert-Some error");
                Console.WriteLine(se.Message);
                Console.WriteLine("---------------------------");
                Console.WriteLine(se.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        void ReadUsersFromDB_Connected()
        {
            List<User> users = new List<User>();
            cmdSelect = new SqlCommand("proc_GetAllUSers",conn);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                IDataReader reader = cmdSelect.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Username = reader[0].ToString();
                    user.Password = reader[1].ToString();
                    user.Name = reader[2].ToString();
                    user.Age = Convert.ToInt32(reader[3].ToString());
                    users.Add(user);
                }
                PrintAllUSers(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }
        void ReadUsersFromDB_DisConnected()
        {
            List<User> users = new List<User>();
            cmdSelect = new SqlCommand("proc_GetAllUSers", conn);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdSelect;
                adapter.Fill(ds, "myUsers");//open connection->Fetch the data->put it in the dataset-> disconnect from database
                conn.Close();
                foreach (DataRow item in ds.Tables["myUsers"].Rows)
                {
                    User user = new User();
                    user.Username = item["userid"].ToString();
                    user.Password = item[1].ToString();
                    user.Name = item[2].ToString();
                    user.Age = Convert.ToInt32(item[3].ToString());
                    users.Add(user);
                }
                PrintAllUSers(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
               
            }
        }
        void PrintAllUSers(ICollection<User> users)
        {
            if(users == null || users.Count==0)
            {
                Console.WriteLine("No users added yet");
                return;
            }
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ReadUsersFromDB_DisConnected();
            Console.ReadKey();
        }
    }
}
