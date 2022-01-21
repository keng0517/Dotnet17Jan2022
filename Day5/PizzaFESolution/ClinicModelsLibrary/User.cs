using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelsLibrary
{
    public class User
    {
        private int id;
        private string name;
        private string password;
        private string age;
        private string type;


        //Get Set Methods
        public int Id { 
            get 
            { 
                return id; 
            } 
            
            set 
            { 
                id = value; 
            } 
        
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }

        }
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }

        }
        public string Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }

        }
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }

        }
    }
}
