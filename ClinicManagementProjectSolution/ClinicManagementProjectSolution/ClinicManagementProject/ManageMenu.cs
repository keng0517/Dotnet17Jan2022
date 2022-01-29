using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementModelsLibrary;
using System.Globalization;

namespace ClinicManagementProject
{
    public class ManageMenu
    {

        string input_username;
        string input_password;


        //manually add some doctor records
        List<Doctor> doctors = new List<Doctor>()
        {
            new Doctor
            {
                user_id = "D101",
                user_nric = "S1234567J",
                user_name = "Chee Keh Keng",
                user_email = "keng88888@email.com",
                user_password = "123123Aa@",
                user_birth = "1999-05-17",
                user_age = 23,
                user_phone = "+92358385",
                user_gender = "Male",
                doc_speacialization = "random specialization 1",
                doc_exp_year = 3

            },
            new Doctor
            {
                user_id = "D102",
                user_nric = "S1231234J",
                user_name = "Johnson Liew",
                user_email = "johnson@email.com",
                user_password = "123123Aa@",
                user_birth = "1998-05-17",
                user_age = 24,
                user_phone = "+92312344",
                user_gender = "Female",
                doc_speacialization = "random specialization 2",
                doc_exp_year = 5

            },
        };

        List<Patient> patients = new List<Patient>()
        {
            new Patient
            {
                user_id = "P101",
                user_nric = "S3456579J",
                user_name = "William Toh",
                user_email = "william@email.com",
                user_password = "123123Aa@",
                user_birth = "1999-05-17",
                user_age = 23,
                user_phone = "+92358123",
                user_gender = "Male",
                p_status = "any status input here 1",
                p_remarks = "remarks 1"

            },
            new Patient
            {
                user_id = "P102",
                user_nric = "S8646456N",
                user_name = "Tiffany Leng",
                user_email = "albert@email.com",
                user_password = "123123Aa@",
                user_birth = "1998-05-17",
                user_age = 24,
                user_phone = "+92312888",
                user_gender = "Female",
                p_status = "any status input here 2",
                p_remarks = "remarks 2"

            },
        };

        List<Appointment> appointments = new List<Appointment>()
        {
            new Appointment{
                apt_id = "A101",
                apt_reg_datetime = "28/1/2022 9:35:47 AM",
                apt_doctor_id = "D101",
                apt_date = "12/12/2022",
                apt_time = "12:00",
                apt_amount = -1,
                apt_reason = "any reason from patient",
                apt_status = "In Pending",
                apt_patient_id = "P101"
            },
            new Appointment{
                apt_id = "A102",
                apt_reg_datetime = "29/1/2022 9:35:47 AM",
                apt_doctor_id = "D102",
                apt_date = "12/12/1999",
                apt_time = "13:00",
                apt_amount = -1,
                apt_reason = "any reason from patient 2",
                apt_status = "In Pending",
                apt_patient_id = "P101"
            },
            new Appointment{
                apt_id = "A103",
                apt_reg_datetime = "28/1/2022 10:35:47 AM",
                apt_doctor_id = "D101",
                apt_date = "12/12/2222",
                apt_time = "14:00",
                apt_amount = -1,
                apt_reason = "any reason from patient 2",
                apt_status = "Approved",
                apt_patient_id = "P101"
            },

        };

        public ManageMenu()
        {


        }




        public void doctorMainMenu()
        {
            int doctorChoice;
            Doctor d = new Doctor();



            //verify username and password;
            if (verification("doctor") == true)
            {
                d = d.getDoctorInfo(doctors, input_username, input_password);


                do
                {
                    Console.WriteLine("\n\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    Console.WriteLine($"        Hi. Welcome Doctor {d.user_name} ");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine("Choose from the options below:");
                    Console.WriteLine("[1] View Appointment");
                    Console.WriteLine("[2] Update Appointment");
                    Console.WriteLine("[3] View History");
                    Console.WriteLine("[4] Raise Payment");
                    Console.WriteLine("[0] Exit\n");
                    Console.Write("> ");

                    while (!int.TryParse(Console.ReadLine(), out doctorChoice))
                    {
                        Console.WriteLine("\n!!! Please enter number [0 to 3] only. !!!\n");

                        Console.WriteLine("\n\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                        Console.WriteLine($"        Hi. Welcome Doctor {d.user_name} ");
                        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                        Console.WriteLine("Choose from the options below:");
                        Console.WriteLine("[1] View Appointment");
                        Console.WriteLine("[2] Update Appointment");
                        Console.WriteLine("[3] View History");
                        Console.WriteLine("[4] Raise Payment");
                        Console.WriteLine("[0] Exit\n");
                        Console.Write("> ");
                    }

                    switch (doctorChoice)
                    {
                        case 1:
                            viewAppointment(d.user_id, "active");
                            break;

                        case 2:
                            updateAppointment(d.user_id);
                            break;

                        case 3:
                            viewAppointment(d.user_id, "deactive");
                            break;

                        case 4:
                            raisePayment(d.user_id);
                            break;

                        case 0:
                            break;

                        default:
                            Console.WriteLine("\n!!! Please enter number [0 to 3] only. !!!\n");
                            break;

                    }

                } while (doctorChoice != 0);

            }
            else
                return;
            //back to User Main menu


        }

        public void patientMainMenu()
        {
            int patientChoice;
            Patient p = new Patient();



            //verify username and password;
            if (verification("patient") == true)
            {

                p = p.getPatientInfo(patients, input_username, input_password);



                do
                {
                    Console.WriteLine("\n\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    Console.WriteLine($"        Hi. Welcome Patient {p.user_name} ");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine("\nChoose from the options below:");
                    Console.WriteLine("[1] Add Appointment");
                    Console.WriteLine("[2] View Appointment");
                    Console.WriteLine("[3] Edit Appointment");
                    Console.WriteLine("[4] View History");
                    Console.WriteLine("[5] View Doctor Details");
                    Console.WriteLine("[6] Make Payment");
                    Console.WriteLine("[0] Exit\n");
                    Console.Write("> ");

                    while (!int.TryParse(Console.ReadLine(), out patientChoice))
                    {
                        Console.WriteLine("\n!!! Please enter number [0 to 4] only. !!!\n");

                        Console.WriteLine("\n\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                        Console.WriteLine($"        Hi. Welcome Patient {p.user_name} ");
                        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                        Console.WriteLine("\nChoose from the options below:");
                        Console.WriteLine("[1] Add Appointment");
                        Console.WriteLine("[2] View Appointment");
                        Console.WriteLine("[3] Edit Appointment");
                        Console.WriteLine("[4] View History");
                        Console.WriteLine("[5] View Doctor Details");
                        Console.WriteLine("[6] Make Payment");
                        Console.WriteLine("[0] Exit\n");
                        Console.Write("> ");
                    }

                    switch (patientChoice)
                    {
                        case 1:
                            addAppointment(p.user_id);
                            break;

                        case 2:
                            viewAppointment(p.user_id, "active");
                            break;

                        case 3:
                            editAppointment(p.user_id);
                            break;

                        case 4:
                            viewAppointment(p.user_id, "deactive");
                            break;

                        case 5:
                            viewDoctorDetails();
                            break;

                        case 6:
                            makePayment(p.user_id);
                            break;

                        case 0:
                            break;

                        default:
                            Console.WriteLine("\n!!! Please enter number [0 to 4] only. !!!\n");
                            break;

                    }

                } while (patientChoice != 0);

            }
            else
                return;
            //back to User Main menu



        }

        public bool verification(string userType)
        {
            bool tempAns = false;
            Doctor doctor = new Doctor();
            Patient patient = new Patient();

            do
            {
                //do the username checking first
                Console.Write($"\nPlease enter {userType} username: ");
                input_username = Console.ReadLine();

                if (userType == "doctor")
                {
                    if (doctor.usernameExistChecker(doctors, input_username) == false) //when username not match
                    {
                        if (tryAgainOrNot("username") == false) //user want to exit verification to menu
                            return false;
                    }
                    else
                        break;
                }
                else
                {
                    if (patient.usernameExistChecker(patients, input_username) == false) //when username not match
                    {
                        if (tryAgainOrNot("username") == false) //user want to exit verification to menu
                            return false;
                    }
                    else
                        break;
                }


            } while (tempAns != true);



            do
            {
                //if username is matched, let user input password
                Console.Write($"\nPlease enter {userType} password: ");
                input_password = Console.ReadLine();

                if (userType == "doctor")
                {
                    if (doctor.passwordChecker(doctors, input_username, input_password) == false) //when username not match
                    {
                        if (tryAgainOrNot("password") == false) //user want to exit verification to menu
                            return false;
                    }
                    else
                        break;
                }
                else
                {
                    if (patient.passwordChecker(patients, input_username, input_password) == false) //when username not match
                    {
                        if (tryAgainOrNot("password") == false) //user want to exit verification to menu
                            return false;
                    }
                    else
                        break;
                }


            } while (tempAns != true);




            return true;
        }

        //functions in doctor menu
        public void updateAppointment(string user_id)
        {
            int editChoice;
            string rejectReason;
            bool confirm = false;

            //doctor input appointment id
            Console.Write("\nPlease enter the appointment ID : ");
            string inputApptId = Console.ReadLine();

            //check whether apt id is match with any apt with login user id
            Appointment ap = appointments.Find(a => a.apt_id == inputApptId && a.apt_doctor_id == user_id);

            if (ap == null)
            {
                Console.WriteLine("\n!!! No appointment matched. !!!");
                return;
            }



            do
            {
                //display that appointment details
                Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"                       Your selected appointment with ID ({ap.apt_id}) ");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                Console.Write(ap.ToString());

                //fill in doctor name
                Doctor doc = doctors.Find(d => d.user_id == ap.apt_doctor_id);
                Console.Write("Doctor " + doc.user_name);

                Console.WriteLine(ap.ToString2());

                Console.WriteLine("\nWhich action you want to execute : ");
                Console.WriteLine("[1] Approve");
                Console.WriteLine("[2] Reject");
                Console.WriteLine("[0] Exit\n");
                Console.Write("> ");

                while (!int.TryParse(Console.ReadLine(), out editChoice))
                {
                    Console.WriteLine("\n!!! Please enter number [0 to 2] only. !!!\n");

                    //display that appointment details
                    Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine($"                       Your selected appointment with ID ({ap.apt_id}) ");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                    Console.Write(ap.ToString());

                    //fill in doctor name
                    Console.Write("Doctor " + doc.user_name);

                    Console.WriteLine(ap.ToString2());

                    Console.WriteLine("\nWhich action you want to execute : ");
                    Console.WriteLine("[1] Approve");
                    Console.WriteLine("[2] Reject");
                    Console.WriteLine("[0] Exit\n");
                    Console.Write("> ");
                }

                switch (editChoice)
                {
                    case 1:
                        confirm = Confirmation();
                        if (confirm == true)
                            ap.apt_status = "Approved";
                        break;

                    case 2:
                        Console.Write("\nPlease enter the rejected reason : ");
                        rejectReason = Console.ReadLine();
                        confirm = Confirmation();
                        if (confirm == true)
                            ap.apt_status = $"Rejected ( {rejectReason} )";
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("\n!!! Please enter number [0 to 2] only. !!!\n");
                        break;

                }

            } while (editChoice != 0 || confirm == false);


        }

        public void raisePayment(string user_id)
        {
            //get user input appointment ID 
            Console.Write("\nPlease enter the appointment ID : ");
            string inputApptId = Console.ReadLine();
            float apt_amount;

            //check whether apt id is match with any apt with login user id
            Appointment ap = appointments.Find(a => a.apt_id == inputApptId && a.apt_doctor_id == user_id);

            if (ap == null)
            {
                Console.WriteLine("\n!!! No appointment matched. !!!");
                return;
            }
            else if (ap.apt_status != "In Pending" && ap.apt_status != "Approved")
            {
                Console.WriteLine($"\n!!! The appointment {ap.apt_id} is already {ap.apt_status}.");
                return;
            }

            //get appointments - must be in active status

            do
            {
                //display that appointment details
                Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"                       Your selected appointment with ID ({ap.apt_id}) ");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                Console.Write(ap.ToString());
                //fill in doctor name
                Doctor doc = doctors.Find(d => d.user_id == ap.apt_doctor_id);
                Console.Write("Doctor " + doc.user_name);
                Console.WriteLine(ap.ToString2());

                Console.Write("\nPlease enter the total amount of this appointment (SGD) : $ ");


                while (!float.TryParse(Console.ReadLine(), out apt_amount))
                {

                    Console.WriteLine("\n!!! Please enter number only. !!!\n");

                    ///display that appointment details
                    Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine($"                       Your selected appointment with ID ({ap.apt_id}) ");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                    Console.Write(ap.ToString());
                    //fill in doctor name
                    Console.Write("Doctor " + doc.user_name);
                    Console.WriteLine(ap.ToString2());

                    Console.Write("\nPlease enter the total amount of this appointment (SGD) : $ ");
                }

                //show error message if value lower than 0
                if (apt_amount < 0)
                    Console.WriteLine("!!! The total amount must be greater than $ 0.00. !!!");
                else
                {
                    if (Confirmation() == true)
                    {
                        ap.apt_amount = apt_amount;
                        ap.apt_status = "Waiting For Payment";
                    }

                }


            } while (apt_amount < 0);

        }

        //functions in patient menu
        public void addAppointment(string user_id)
        {
            Appointment appt = new Appointment();


            //auto generate appt id
            appt.apt_id = apptIdGenerator();

            //appt_patient_id = login user
            appt.apt_patient_id = user_id;

            //let user select which doctor he/she needs (add on later if time enough)


            //let user input date, time, reason, and current status
            appt.GetAppointmentDetails(doctors, appointments);


            //raise confirmation to user
            if (Confirmation() == true)
                appointments.Add(appt);

        }

        public void editAppointment(string user_id)
        {
            int editChoice;
            string newInput;
            bool confirm = false;

            //get apt id from user
            Console.Write("\nPlease enter the appointment ID : ");
            string inputApptId = Console.ReadLine();

            //check whether apt id is match with any apt with login user id
            Appointment ap = appointments.Find(a => a.apt_id == inputApptId && a.apt_patient_id == user_id);

            if (ap == null)
            {
                Console.WriteLine("\n!!! No appointment matched. !!!");
                return;
            }




            //ask for which field to edit

            do
            {
                //display that appointment details
                Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"                       Your selected appointment with ID ({ap.apt_id}) ");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                Console.Write(ap.ToString());

                //fill in doctor name
                Doctor doc = doctors.Find(d => d.user_id == ap.apt_doctor_id);
                Console.Write("Doctor " + doc.user_name);

                Console.WriteLine(ap.ToString2());

                Console.WriteLine("\nWhich information need to edit ?");
                Console.WriteLine("[1] Appointment Date");
                Console.WriteLine("[2] Appointment Time");
                Console.WriteLine("[3] Appointment Reason");
                Console.WriteLine("[4] Selected doctor");
                Console.WriteLine("[0] Exit\n");
                Console.Write("> ");

                while (!int.TryParse(Console.ReadLine(), out editChoice))
                {

                    Console.WriteLine("\n!!! Please enter number [0 to 4] only. !!!\n");

                    //display that appointment details
                    Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine($"                       Your selected appointment with ID ({ap.apt_id}) ");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                    Console.Write(ap.ToString());

                    //fill in doctor name
                    Console.Write("Doctor " + doc.user_name);

                    Console.WriteLine(ap.ToString2());

                    Console.WriteLine("\nWhich information need to edit ?");
                    Console.WriteLine("[1] Appointment Date");
                    Console.WriteLine("[2] Appointment Time");
                    Console.WriteLine("[3] Appointment Reason");
                    Console.WriteLine("[4] Selected doctor");
                    Console.WriteLine("[0] Exit\n");
                    Console.Write("> ");
                }

                switch (editChoice)
                {
                    case 1:
                        newInput = ap.getValidatedDate(doctors, appointments, ap.apt_time, ap.apt_doctor_id);

                        confirm = Confirmation();
                        if (confirm == true)
                        {
                            ap.apt_date = newInput;
                            ap.apt_status = "In Pending";
                        }

                        break;

                    case 2:
                        newInput = ap.getValidatedTime(doctors, appointments, ap.apt_date, ap.apt_doctor_id);

                        confirm = Confirmation();
                        if (confirm == true)
                        {
                            ap.apt_time = newInput;
                            ap.apt_status = "In Pending";
                        }
                        break;

                    case 3:
                        Console.Write("\nPlease enter new reason of appointment               : ");
                        newInput = Console.ReadLine();
                        confirm = Confirmation();
                        if (confirm == true)
                        {
                            ap.apt_reason = newInput;
                            ap.apt_status = "In Pending";
                        }
                        break;

                    case 4:
                        newInput = ap.getDoctorId(doctors, appointments, ap.apt_date, ap.apt_time);
                        confirm = Confirmation();
                        if (confirm == true)
                        {
                            ap.apt_doctor_id = newInput;
                            ap.apt_status = "In Pending";
                        }
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine("\n!!! Please enter number [0 to 4] only. !!!\n");
                        break;

                }

            } while (editChoice != 0 || confirm == false);


        }

        public void viewDoctorDetails()
        {
            Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("                  List of doctors in Raindy's Clinic Management System ");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");


            foreach (Doctor d in doctors)
            {
                Console.WriteLine(d.ToString());
            }
        }

        //functions for both menu
        public void viewAppointment(string user_id, string view_apt_status)
        {
            bool apptIsEmpty = !appointments.Any();
            int recordCount = 0;
            Appointment ap = new Appointment();

            if (user_id.Contains('P'))
            {
                ap = appointments.Find(a => a.apt_patient_id == user_id);
            }
            else
            {
                ap = appointments.Find(a => a.apt_doctor_id == user_id);
            }



            if (apptIsEmpty || ap == null)
            {
                Console.WriteLine("\n!!! No appointment was added. !!!\n\n");
            }
            else
            {

                if (view_apt_status == "active")
                {
                    Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine("                              Your current appointment(s) ");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                }
                else
                {
                    Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.WriteLine("                              Your history appointment(s) ");
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                }


                foreach (Appointment appt in appointments)
                {
                    if (user_id.Contains('P'))
                    {

                        if (view_apt_status == "active")
                        {
                            if (appt.apt_patient_id == user_id && ((appt.apt_status == "In Pending" || appt.apt_status == "Approved") || appt.apt_status == "Waiting For Payment"))
                            {
                                Console.Write(appt.ToString());

                                //fill in doctor name
                                Doctor doc = doctors.Find(d => d.user_id == appt.apt_doctor_id);
                                Console.Write("Doctor " + doc.user_name);

                                Console.WriteLine(appt.ToString2());
                                recordCount++;
                            }
                        }
                        else
                        {
                            if (appt.apt_patient_id == user_id && (appt.apt_status != "In Pending" && appt.apt_status != "Approved"))
                            {
                                if (appt.apt_status != "Waiting For Payment")
                                {
                                    Console.Write(appt.ToString());

                                    //fill in doctor name
                                    Doctor doc = doctors.Find(d => d.user_id == appt.apt_doctor_id);
                                    Console.Write("Doctor " + doc.user_name);

                                    Console.WriteLine(appt.ToString2());

                                    recordCount++;
                                }
         
                            }
                        }

                    }
                    else //if doctor view appointments
                    {
                        if (view_apt_status == "active")
                        {
                            if (appt.apt_doctor_id == user_id && ((appt.apt_status == "In Pending" || appt.apt_status == "Approved") || appt.apt_status == "Waiting For Payment"))
                            {
                                Console.Write(appt.ToString());

                                //fill in doctor name
                                Doctor doc = doctors.Find(d => d.user_id == appt.apt_doctor_id);
                                Console.Write("Doctor " + doc.user_name);

                                Console.WriteLine(appt.ToString2());
                                recordCount++;
                            }
                        }
                        else
                        {
                            if (appt.apt_doctor_id == user_id && (appt.apt_status != "In Pending" && appt.apt_status != "Approved"))
                            {
                                if (appt.apt_status != "Waiting For Payment")
                                {
                                    Console.Write(appt.ToString());

                                    //fill in doctor name
                                    Doctor doc = doctors.Find(d => d.user_id == appt.apt_doctor_id);
                                    Console.Write("Doctor " + doc.user_name);

                                    Console.WriteLine(appt.ToString2());

                                    recordCount++;
                                }
                                
                            }
                        }
                    }
                }


                //shows no records if recordCount = 0
                if (recordCount > 0)
                    Console.WriteLine($"{recordCount} records have been shown");
                else
                    Console.WriteLine("No record can be shown");


            }



            


        }

        

       

        

        

        public void makePayment(string user_id)
        {
            //display all appointments with Waiting To Pay status
            int recordCount = 0;
            Appointment ap = new Appointment();
            ap = appointments.Find(a => a.apt_patient_id == user_id);

            Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("                        Your appointment(s) - Waiting For Payment");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");


            foreach (Appointment appt in appointments)
            {

                if (appt.apt_patient_id == user_id &&  appt.apt_status == "Waiting For Payment")
                {
                    Console.Write(appt.ToString());

                    //fill in doctor name
                    Doctor doc1 = doctors.Find(d => d.user_id == appt.apt_doctor_id);
                    Console.Write("Doctor " + doc1.user_name);

                    Console.WriteLine(appt.ToString2());
                    recordCount++;
                }
            }

            //shows no records if recordCount = 0
            if (recordCount > 0)
                Console.WriteLine($"{recordCount} records have been shown");
            else
            {
                Console.WriteLine("No record can be shown");
                return;
            }


            //receive appointment ID from user
            Console.Write("\nPlease enter the appointment ID : ");
            string inputApptId = Console.ReadLine();

            //check whether apt id is match with any apt with login user id
            ap = appointments.Find(a => a.apt_id == inputApptId && a.apt_patient_id == user_id && a.apt_status == "Waiting For Payment");

            if (ap == null)
            {
                Console.WriteLine("\n!!! No appointment matched. !!!");
                return;
            }


            //display selected appointment details
            
            Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine($"                       Your selected appointment with ID ({ap.apt_id}) ");
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            Console.Write(ap.ToString());

            //fill in doctor name
            Doctor doc = doctors.Find(d => d.user_id == ap.apt_doctor_id);
            Console.Write("Doctor " + doc.user_name);

            Console.WriteLine(ap.ToString2());

            Console.WriteLine("\nYou are going to pay for this appointment.");
            if (Confirmation() == true)
            {
                ap.apt_status = "Paid";

                Console.WriteLine("\n\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"                       Your selected appointment with ID ({ap.apt_id}) ");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

                Console.Write(ap.ToString());

                //fill in doctor name
                doc = doctors.Find(d => d.user_id == ap.apt_doctor_id);
                Console.Write("Doctor " + doc.user_name);

                Console.WriteLine(ap.ToString2());
            }
            else
                return;

                
                

            


        }


        //sub functions
        public bool tryAgainOrNot(string inputType)
        {
            int errChoice;

            do
            {
                if (inputType == "username")
                    Console.WriteLine("\nThis username is not exist.");
                else
                    Console.WriteLine("\nThis password is incorrect.");

                Console.WriteLine("[1] Try again");
                Console.WriteLine("[0] Exit");
                Console.Write("> ");

                while (!int.TryParse(Console.ReadLine(), out errChoice))
                {
                    Console.WriteLine("\n!!! Please enter number [0 - 1] only. !!!\n");

                    if (inputType == "username")
                        Console.WriteLine("\nThis username is not exist.");
                    else
                        Console.WriteLine("\nThis password is incorrect.");
                    Console.WriteLine("[1] Try again");
                    Console.WriteLine("[0] Exit");
                    Console.Write("> ");
                }

                switch (errChoice)
                {
                    case 1:
                        return true;

                    case 0:
                        return false;

                    default:
                        Console.WriteLine("\n!!! Please enter number [0 - 1] only. !!!\n");
                        break;

                }


            } while (errChoice != 0 || errChoice != 1);

            return false;
        }
        public string apptIdGenerator()
        {
            if(appointments.Count == 0)
                return "A101";

            return ($"A{appointments.Count + 101}");
        }
        public bool Confirmation()
        {
            int userChoice;
            
            do
            {
                Console.WriteLine("\nAre you confirm ?");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[0] No\n");
                Console.Write("> ");

                while (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.WriteLine("\n!!! Please enter number [0 to 1] only. !!!\n");

                    Console.WriteLine("Are you confirm ?");
                    Console.WriteLine("[1] Yes");
                    Console.WriteLine("[0] No\n");
                    Console.Write("> ");
                }

                switch (userChoice)
                {
                    case 1:
                        return true;

                    case 0:
                        return false;

                    default:
                        Console.WriteLine("\n!!! Please enter number [0 to 1] only. !!!\n");
                        break;

                }

            } while (userChoice != 0);

            return false;

        }
    }
}
