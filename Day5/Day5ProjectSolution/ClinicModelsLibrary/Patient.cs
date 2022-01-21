using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelsLibrary
{
    public class Patient : User
    {
        public string remarks { get; set; }
        public string status { get; set; }

        public Patient()
        {
            type = "Patient";
        }

        public override void userInfoReceiver()
        {
            base.userInfoReceiver();

            Console.Write("Please enter remarks    :");
            remarks = Console.ReadLine();

            Console.Write("Please enter status     :");
            status = Console.ReadLine();
        }

        public override void displayUserInfo()
        {
            base.displayUserInfo();
            Console.WriteLine("Patient's remarks: {0}\n" +
                              "Patient's status : {1}\n", remarks, status);
        }


    }
}
