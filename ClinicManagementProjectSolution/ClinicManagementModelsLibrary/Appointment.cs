using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ClinicManagementModelsLibrary
{
    public class Appointment
    {
        //attribute declarations
        public string apt_id { get; set; }
        public DateTime apt_reg_datetime { get; set; }
        public string apt_date { get; set; }
        public string apt_time { get; set; }
        public string apt_reason { get; set; }
        public string apt_status { get; set;} //pending > rejected / approved > paid 
        public string apt_patient_id { get; set; }
        public string apt_doctor_id { get; set; }
        public float apt_amount { get; set; }


        public Appointment()
        {

        }

        public void GetAppointmentDetails(List<Doctor> doctors, List<Appointment> appts) 
        {
            DateTime apt_reg_datetime = DateTime.Now;
            bool isValid = false;

            //auto generate input fields
            Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("                 Get an appointment with your prefered doctor");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine($"Appointment registration datetime                    : {apt_reg_datetime}");


            apt_status = "In Pending";
            apt_amount = -1;

            //require user input fields
            do
            {
                Console.Write("Please enter the prefered doctor ID  (Eg. D101)      : ");
                apt_doctor_id = Console.ReadLine();
                Doctor doc = doctors.Find(d => d.user_id == apt_doctor_id);

                if (doc == null)
                {
                    Console.WriteLine($"!!! No doctor ID is matched with {apt_doctor_id} !!!");
                    isValid = false;
                }
                else
                    isValid = true;
                    

            } while (isValid == false);
            


            apt_date = getValidatedDate();

            apt_time = getValidatedTime(doctors, appts, apt_date);

            Console.Write("Please enter the reason of appointment               : ");
            apt_reason = Console.ReadLine();

            

            Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }


        public string getValidatedDate()
        {
            DateTime todayDate = DateTime.Today;
            bool isValid = true;
            string input_date;

            do
            {
                Console.Write("Please enter the appointment date (Eg. dd/mm/yyyy)   : ");
                 input_date = Console.ReadLine();

                if (!DateTime.TryParseExact(input_date, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var appt_date))
                {
                    isValid = false;
                    Console.WriteLine("Appointment date format should be dd/MM/yyyy. (Eg. 12/5/2022)");
                }
                else
                {
                    if (appt_date.Date < todayDate.Date)
                    {
                        isValid = false;
                        Console.WriteLine($"Appointment date must be greater than today {todayDate.ToString("dd/MM/yyyy")}.");
                    }
                    else
                    {
                        isValid = true;
                    }

                }

            } while (isValid == false);

            return input_date;
        }

        public string getValidatedTime(List<Doctor> doctors, List<Appointment> appts, string apt_date)
        {
            DateTime todayDate = DateTime.Today;
            bool isValid = true;
            string input_time;

            do
            {
                Console.Write("Please enter the appointment time (Eg. 18:00)        : ");
                input_time = Console.ReadLine();

                if (!DateTime.TryParseExact(input_time, "H:m", CultureInfo.InvariantCulture, DateTimeStyles.None, out var appt_time))
                {
                    isValid = false;
                    Console.WriteLine("Appointment time should be in 24-hour format. (Eg. 12:00)");
                }
                else
                {
                    if (appt_time.Hour < 9 || appt_time.Hour > 18)
                    {
                        isValid = false;
                        Console.WriteLine("!!! Raindy's Clinic operates 09:00 to 18:00 only. !!!");
                    }
                    else if (appt_time.Hour == 18)
                    {
                        isValid = false;
                        Console.WriteLine("!!! Any appointment time must be 1 hour before clinic close. !!!");
                    }
                    else
                    {
                        input_time = appt_time.ToString("HH:mm");
                        
                        //check the apt_date is same with which appts

                        //check input time with those appts

                        //if crash, prompt error message

                        //else, isValid = true;

                        isValid = true;
                    }

                }

            } while (isValid == false);

            
            return input_time;
        }

        public override string ToString()
        {
            if (apt_amount < 0)
                return "\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
                    + "\nAppointment ID                         > " + apt_id
                    + "\nAppointment registration datetime      > " + apt_reg_datetime
                    + "\nSelected Doctor ID                     > " + apt_doctor_id
                    + "\nSelected Doctor Name                   > ";
            else
                return "\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>"
                    + "\nAppointment ID                         > " + apt_id
                    + "\nAppointment registration datetime      > " + apt_reg_datetime
                    + "\nSelected Doctor ID                     > " + apt_doctor_id
                    + "\nSelected Doctor Name                   > ";
        }

        public string ToString2()
        {
            if (apt_amount < 0)
                return "\nAppointment date                       > " + apt_date
                    + "\nAppointment time                       > " + apt_time
                    + "\nAppointment reason                     > " + apt_reason
                    + "\nAppointment status                     > " + apt_status
                    + "\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";
            else
                return "\nAppointment date                       > " + apt_date
                    + "\nAppointment time                       > " + apt_time
                    + "\nAppointment reason                     > " + apt_reason
                    + "\nAppointment amount (SGD)               > $ " + apt_amount.ToString("n2")
                    + "\nAppointment status                     > " + apt_status
                    + "\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";
        }

    }
}
