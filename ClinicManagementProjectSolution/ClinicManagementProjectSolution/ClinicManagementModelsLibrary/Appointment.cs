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
        public string apt_reg_datetime { get; set; }
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
            apt_reg_datetime = DateTime.Now.ToString();
            

            //auto generate input fields
            Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("                 Get an appointment with your prefered doctor");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine($"Appointment registration datetime                    : {apt_reg_datetime}");


            apt_status = "In Pending";
            apt_amount = -1;

            //require user input fields
            apt_doctor_id = getDoctorId(doctors);
            


            apt_date = getValidatedDate();

            apt_time = getValidatedTime(doctors, appts, apt_date, apt_doctor_id);

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

        public string getValidatedDate(List<Doctor> doctors, List<Appointment> appointments, string ref_apt_time, string ref_doc_id)
        {
            DateTime todayDate = DateTime.Today;
            bool isValid = true;
            string input_date;
            string ref_apt_time_hh = ref_apt_time.Substring(0, 2);
            int ref_apt_time_hh2 = Int32.Parse(ref_apt_time_hh) + 1;

            do
            {
                int crashCount = 0;
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
                        //check whether the input date and ori time crash with others
                        //check the apt_date is same with which appts
                        foreach (Appointment appt in appointments)
                        {

                            if (appt.apt_date == input_date && (appt.apt_time.Substring(0,2) == ref_apt_time_hh && appt.apt_doctor_id == ref_doc_id))
                            {
                                crashCount++;
                            }
                        }

                        if (crashCount == 0)
                            isValid = true;
                        else
                        {
                            Doctor doc = doctors.Find(d => d.user_id == apt_doctor_id);

                            

                            Console.WriteLine($"!!! The selected date {input_date} with booked time ({ref_apt_time.Substring(0,2)}:00 - {ref_apt_time_hh2}:00) is not available for {ref_doc_id} Doctor {doc.user_name}. !!!");
                            isValid = false;
                        }
                    }

                }

            } while (isValid == false);

            return input_date;
        }

        public string getValidatedTime(List<Doctor> doctors, List<Appointment> appts, string apt_date, string apt_doctor_id)
        {
            DateTime todayDate = DateTime.Today;
            bool isValid = true;
            string input_time;
            int crashCount = 0;

            do
            {
                Console.Write("Please enter the appointment time (Eg. 18:00)        : ");
                input_time = Console.ReadLine();
                crashCount = 0;
                Doctor doc = doctors.Find(d => d.user_id == apt_doctor_id);

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
                        string input_time_hh = appt_time.ToString("HH");
                        

                        //check the apt_date is same with which appts
                        foreach (Appointment appt in appts)
                        {
                            string apt_time_hh = appt.apt_time.Substring(0, 2);

                            if (appt.apt_date == apt_date && (apt_time_hh == input_time_hh && appt.apt_doctor_id == apt_doctor_id))
                            {
                                crashCount++;
                            }
                        }

                        if (crashCount == 0)
                            isValid = true;
                        else
                        {
                            int input_time_hh2 = Int32.Parse(input_time_hh) + 1;
                            Console.WriteLine($"!!! The selected time ({input_time_hh}:00 - {input_time_hh2}:00) on {apt_date} is not available for {apt_doctor_id} Doctor {doc.user_name}. !!!");
                            isValid = false;
                        }

                    }

                    

                }

            } while (isValid == false);


            return input_time;
        }

        public string getDoctorId(List<Doctor> doctors)
        {
            bool isValid = false;
            string input_doctor_id;

            do
            {
                Console.Write("Please enter the prefered doctor ID  (Eg. D101)      : ");
                input_doctor_id = Console.ReadLine();
                Doctor doc = doctors.Find(d => d.user_id == input_doctor_id);

                if (doc == null)
                {
                    Console.WriteLine($"!!! No doctor ID is matched with {input_doctor_id} !!!");
                    isValid = false;
                }
                else
                    isValid = true;


            } while (isValid == false);

            return input_doctor_id;
        }

        public string getDoctorId(List<Doctor> doctors, List<Appointment> appointments, string ref_apt_date, string ref_apt_time)
        {
            bool isValid = false;
            string input_doctor_id;
            string ref_apt_time_hh = ref_apt_time.Substring(0, 2);
            int ref_apt_time_hh2 = Int32.Parse(ref_apt_time_hh) + 1;

            do
            {
                int crashCount = 0;
                Console.Write("Please enter the prefered doctor ID  (Eg. D101)      : ");
                input_doctor_id = Console.ReadLine();
                Doctor doc = doctors.Find(d => d.user_id == input_doctor_id);

                if (doc == null)
                {
                    Console.WriteLine($"!!! No doctor ID is matched with {input_doctor_id} !!!");
                    isValid = false;
                }
                else
                {
                    foreach (Appointment appt in appointments)
                    {
                        string apt_time_hh = appt.apt_time.Substring(0, 2);

                        if (appt.apt_date == ref_apt_date && (appt.apt_time.Substring(0, 2) == ref_apt_time_hh && appt.apt_doctor_id == input_doctor_id))
                        {
                            crashCount++;
                        }


                    }

                    if (crashCount == 0)
                        isValid = true;
                    else
                    {
                        Console.WriteLine($"!!! The selected {input_doctor_id} Doctor {doc.user_name} with booked time ({ref_apt_time.Substring(0,2)}:00 - {ref_apt_time_hh2}:00) on {ref_apt_date} is not available.  !!!");
                        isValid = false;
                    }
                }


            } while (isValid == false);

            return input_doctor_id;
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
