using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementModelsLibrary
{
    public class User
    {
        //Attributes declaration
        public string user_id { get; set; }
        public string user_nric { get; set; }
        public string user_name { get; set;}
        public string user_email { get; set; }
        public string user_password { get; set; }
        public string user_birth { get; set; }
        public int user_age { get; set; } //autogenerate after user_birth has been keyed in
        public string user_phone { get; set; }
        public string user_gender { get; set; }


        
        

        

        //Behavior declaration
        public User()
        {

        }


    }
}
