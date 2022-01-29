using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementModelsLibrary
{
    public class Patient : User
    {
        //attributes declarations
        public string p_status { get; set; }
        public string p_remarks { get; set; }

        //behaviour declaration
        public Patient()
        {

        }



        public bool usernameExistChecker(List<Patient> patients, string input_username)
        {
            foreach (Patient p in patients)
            {
                if (p.user_id == input_username)
                {
                    return true;
                }
            }

            return false;
        }

        public bool passwordChecker(List<Patient> doctors, string input_username, string input_password)
        {
            foreach (Patient p in doctors)
            {
                if (p.user_id == input_username)
                {
                    if (p.user_password == input_password)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }



        public Patient getPatientInfo(List<Patient> doctors, string input_username, string input_password)
        {
            Patient patient = new Patient();

            foreach (Patient p in doctors)
            {
                if (p.user_id == input_username)
                {
                    if (p.user_password == input_password)
                        return p;
                }
            }

            return patient;

        }
    }
}
