using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementModelsLibrary
{
    public class Doctor : User
    {
        //attribute declarations
        public string doc_speacialization { get; set; }
        public int doc_exp_year { get; set; }

        


        //behaviour declarations
        public Doctor()
        {
            
        }


        public bool usernameExistChecker(List<Doctor> doctors, string doc_input_username)
        {
            foreach (Doctor d in doctors)
            {
                if (d.user_id == doc_input_username)
                {
                    return true;
                }
            }

            return false;
        }

        public bool passwordChecker(List<Doctor> doctors, string doc_input_username, string doc_input_password)
        {
            foreach (Doctor d in doctors)
            {
                if (d.user_id == doc_input_username)
                {
                    if (d.user_password == doc_input_password)
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }



        public Doctor getDoctorInfo(List<Doctor> doctors, string doc_input_username, string doc_input_password)
        {
            Doctor doctor = new Doctor();

            foreach (Doctor d in doctors)
            {
                if (d.user_id == doc_input_username)
                {
                    if (d.user_password == doc_input_password)
                        return d;
                }
            }

            return doctor;

        }

        public string ToString()
        {
            return "\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
                    + "\nDoctor's ID                              > " + user_id
                    + "\nDoctor's Full Name                       > " + user_name
                    + "\nDoctor's Email                           > " + user_email
                    + "\nDoctor's Phone Number                    > " + user_phone
                    + "\nDoctor's Age                             > " + user_age
                    + "\nDoctor's Gender                          > " + user_gender
                    + "\nDoctor's Speacialization                 > " + doc_speacialization
                    + "\nDoctor's Experience                      > " + doc_exp_year + " year(s)";
        }

    }
}
