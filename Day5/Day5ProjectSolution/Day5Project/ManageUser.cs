using ClinicModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Project
{
    internal class ManageUser
    {
        

        public void userRegistration()
        {
            string inputType;

            Console.Write("Please enter your user type \n" +
                "Patient    < P >\n" +
                "Doctor     < D >\n" +
                ":");
            inputType = Console.ReadLine();

            User user;

            switch (inputType)
            {
                case "P":
                    user = new Patient();
                    break;
                case "p":
                    user = new Patient();
                    break;
                case "D":
                    user = new Doctor();
                    break;
                case "d":
                    user = new Doctor();
                    break;
                default:
                    Console.WriteLine("Invalid Entry. System automatically treat as Patient");
                    user = new Patient();
                    break;
                    
            }

            user.userInfoReceiver();
            user.displayUserInfo();
        }

        //public void displayUserInfo()
        //{
        //    Console.WriteLine(user);
        //}
    }
}
