using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelsLibrary
{
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int age  { get; set; }
        public string type { get; set; }

        public User()
        {
            type = "Patient";
        }


        public virtual void userInfoReceiver()
        {
            Console.Write("Please enter user ID    :");
            id = Console.ReadLine();

            Console.Write("Please enter user name  :");
            name = Console.ReadLine();

            Console.Write("Please enter password   :");
            password = Console.ReadLine();

            Console.Write("Please enter age        :");
            age = Convert.ToInt32(Console.ReadLine());

        }


        public virtual void displayUserInfo()
        {
            Console.WriteLine("-----------------------\n" +
                              "User ID          : {0}\n" +
                              "User Name        : {1}\n" +
                              "User Password    : {2}\n" +
                              "User Age         : {3}\n" +
                              "User Type        : {4}", id, name, password, age, type);
        }
    }
}
