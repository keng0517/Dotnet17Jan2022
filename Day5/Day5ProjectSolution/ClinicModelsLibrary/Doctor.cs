using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelsLibrary
{
    public class Doctor : User
    {
        public int experience { get; set; }
        public string speciality { get; set; }

        public Doctor()
        {
            type = "Doctor";
        }



        public override void userInfoReceiver()
        {
            base.userInfoReceiver();

            Console.Write("Please enter experience :");
            experience = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter speciality :");
            speciality = Console.ReadLine();
        }

        public override void displayUserInfo()
        {
            base.displayUserInfo();
            Console.WriteLine("Experience       : {0} year(s)\n" +
                              "Speciality       : {1}\n", experience, speciality);
        }
    }
}
