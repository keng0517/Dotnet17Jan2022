using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelsLibrary
{
    internal class Doctor
    {
        private string experience;
        private string speciality;


        //get set methods
        public string Experience
        {
            get
            {
                return experience;
            }

            set
            {
                experience = value;
            }

        }
        public string Speciality
        {
            get
            {
                return speciality;
            }

            set
            {
                speciality = value;
            }

        }
    }
}
