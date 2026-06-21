using Hospital_Management_System.HospitalModel;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Hospital_Management_System

{
    public class Program
    {
       
        //1 Patient Registration Function
        public static void PatientRegistration(HospitalContext context) {
            //patient information
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Gender (Male/Female): ");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your Email ");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter your Blood Type");
            string bloodType = Console.ReadLine();

            int userId = (context.patients.Count) + 1;

            context.patients.Add(
                new Patient
            {
                patientId=userId,
                patientName = name,
                patientAge= age,
                patientGender= gender,
                patientPhone= phoneNumber,
                patientEmail= Email,
                patientBloodType= bloodType


                }
              );
            Console.WriteLine("Pateint  Added Successfully with ID " + userId);

        }

        //2 Add a New Doctor Function
        public static void AddDcotor(HospitalContext context)
        {
            Console.WriteLine("Enter the doctor Name");
            string dname = Console.ReadLine(); 
            Console.WriteLine("Enter the doctor Specialization");
            string dSpecialization = Console.ReadLine();
            Console.WriteLine("Enter the doctor Phone Number");
            string dPhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter the doctor  Email");
            string dEmail = Console.ReadLine();
            Console.WriteLine("Enter the doctor consultationFee");
            decimal dconsultationFee = decimal.Parse(Console.ReadLine());
            int newDoctorId = (context.Decoders.Count) + 1;

            context.Decoders.Add(
                new Doctor
                {
                    doctorId = newDoctorId,
                    doctorName = dname,
                    doctorSpecialization = dSpecialization,
                    doctorPhone = dPhoneNumber,
                    doctorEmail = dEmail,
                    consultationFee = dconsultationFee

                }
                );
            Console.WriteLine("Doctor  Added Successfully with ID " + newDoctorId);

        }

        //3 View All Patients Function
        public static void ViewAllPatients(List<Patient> patients)
        {

            //If no patients have been registered
            if (patients.Count == 0)
            {
                Console.WriteLine("No patients registered yet.");
                return;
            }
            //To view every patient currently registered 
            foreach (var patient in patients)
            {

                patient.PatientInfo();
            }
        }


        //4 View All Doctors by Specialization Function
        public static void ViewDoctorsBySpecialization(HospitalContext context)
        {
            Console.WriteLine("Enter Specialization to search:");
            string specialization = Console.ReadLine().ToLower(); ;

            List<Doctor> DecodersSpecializationList= context.Decoders.Where(d => d.doctorSpecialization== specialization.ToLower()).ToList();

            if (DecodersSpecializationList.Count == 0)
            {
                Console.WriteLine("No doctors found with this specialization.");
                return;
            }
            foreach(Doctor DS in DecodersSpecializationList)
            {
                DS.DoctorInfo();
            }

            
        }





        //5 Add an Available Time Slot for a Doctor Function
        public static void AddAvailableTimeSlot(HospitalContext context)
        {
            //If no doctor found in the system
            if (context.Decoders.Count == 0)
            {
                Console.WriteLine("No no doctor found in the system yet.");
                return;
            }
            Console.WriteLine("Available doctors:");
            context.Decoders.ForEach(d => Console.WriteLine($"  ID: {d.doctorId}  |  {d.doctorName}  ({d.doctorSpecialization})")
            );

            Console.WriteLine("Enter the Doctor Id ");
            int doctorId = int.Parse(Console.ReadLine());

         
            //*****check the doctor if is found By LinQ****//
            bool doctorFound = context.Decoders
                                      .Any(a => a.doctorId == doctorId);
            if (doctorFound == false)
            {
                Console.WriteLine($"The doctor was not found");
                return;
            }
            //enters  date and time
            Console.WriteLine("Enter the date");
            string dateOfSlot = Console.ReadLine();
            Console.WriteLine("Enter the time");
            string timeOfSlot = Console.ReadLine();

           
            //****For check if there is any time or date repeat By LINQ****//
            bool repeat= context.AvailableSlotcs
                                .Any(a => a.slotDate == dateOfSlot && a.slotTime== timeOfSlot && a.doctorId==doctorId);
            if (repeat == true)
            { Console.WriteLine("the date or time is repeated"); return; }


            //Add a new slot
            int slotId = (context.AvailableSlotcs.Count) + 1;

            context.AvailableSlotcs.Add(new AvailableSlotc
            {
                slotId= slotId,
                doctorId = doctorId,
                slotDate= dateOfSlot,
                slotTime= timeOfSlot,
                isBooked = false

            });

                Console.WriteLine($"the slot has been added{slotId}");
            
        }


        //6 Book an Appointment Function
        public static void BookAppointment(HospitalContext context)
        {
            Console.WriteLine("Enter the patient Id");
            int IdOfPatient = int.Parse(Console.ReadLine());

            //*********check if the patient found By LINQ*********//
            bool patientFound = context.patients
                                       .Any(a => a.patientId == IdOfPatient);
            if (patientFound == false)
            {
                Console.WriteLine("The patient not found");
                return;
            }

            //View All Doctors by Specialization Function
            ViewDoctorsBySpecialization(context);

            //*********check if the doctor found By LINQ*********//
            Console.WriteLine("Enter the doctor Id");
            int IdOfDoctor = int.Parse(Console.ReadLine());
            bool doctorFound = context.Decoders
                                  .Any(a => a.doctorId == IdOfDoctor);
            if (doctorFound == false) { Console.WriteLine($"The doctor not  found ");return; }




            List<AvailableSlotc> AvailableSlotcList = context.AvailableSlotcs
                                                             .Where(a => a.isBooked == false &&
                                                                    a.doctorId == IdOfDoctor)
                                                              .ToList();
            if (AvailableSlotcList.Count == 0)
            {
                Console.WriteLine("There are no available slots ");
                return;
            }
            Console.WriteLine($"Available slots for Dr:");
            AvailableSlotcList.ForEach(a => Console.WriteLine($"  Slot ID: {a.slotId}  |  Date: {a.slotDate}  |  Time: {a.slotTime}"));

            //Enter the slot ID
            Console.WriteLine("Enter the slot Id you want");
            int idOfSlot = int.Parse(Console.ReadLine());

            AvailableSlotc slotFound = context.AvailableSlotcs
                                              .FirstOrDefault(a =>
                                             a.slotId == idOfSlot &&
                                             a.doctorId == IdOfDoctor &&
                                             a.isBooked == false);
            if (slotFound == null) {
                Console.WriteLine("Invalid slot Id");
                return;
            }

            int AppointmentId = (context.Appointments.Count) + 1;
            context.Appointments.Add(
                new Appointment
                {
                    appointmentId = AppointmentId,
                    patientId = IdOfPatient,
                    doctorId = IdOfDoctor,
                    appointmentDate= slotFound.slotDate,
                    appointmentTime= slotFound.slotTime,
                    status = "Scheduled"
                });
            slotFound.isBooked = true;
            Console.WriteLine("Book  Appointment Added Successfully with ID " + AppointmentId);
        }
        



        //7 Cancel an Appointment Function
        public static void CancelAppointment(HospitalContext context)
        {
            Console.WriteLine("Enter the Book Appointment Id");
            int bookAppointmentId = int.Parse(Console.ReadLine());

            //bool appointmentIdfound = false;

            //foreach (var app in context.Appointments)
            //{
            //    if (app.appointmentId == bookAppointmentId)
            //    {
            //        appointmentIdfound = true;

            //        if (app.status == "cancelled")
            //        {
            //            Console.WriteLine("Appointment already cancelled");
            //        }
            //        else
            //        {
            //            app.status = "cancelled";
            //            Console.WriteLine("Appointment cancelled successfully");
            //        }

            //        break;
            //    }
            //}

            //    if (appointmentIdfound = false)
            //    {
            //        Console.WriteLine("Appointment Id not found");
            //    }


            //********************Solveb By LINQ*************

        }
        //8 Create a Medical Record After a Visit Function
        public static void MedicalRecordAfterVisit(HospitalContext context)
        {
            //Patient Info
            Console.WriteLine("Enter the pateint Id");
            int patientOfId = int.Parse(Console.ReadLine());
            bool patientFound = false;
            foreach (var petient in context.patients)
            {
              if(petient.patientId== patientOfId)
                {
                    Console.WriteLine("the Patient Id found");
                    patientFound = true;
                    break;
                }
                else
                {
                    Console.WriteLine("the Patient Id not found");
                    return;
                }
            }

            //Doctor Info
          
            Console.WriteLine("Enter the doctor Id");
            int doctorOfId = int.Parse(Console.ReadLine());
            bool doctorFound = false;
            decimal visitFeeUser = 0;
            foreach (var doctor in context.Decoders)
            {
                if (doctor.doctorId == doctorOfId)
                {
                    Console.WriteLine("the Doctor Id found");
                    visitFeeUser = doctor.consultationFee;
                    doctorFound = true;
                    break;
                }
                else
                {
                    Console.WriteLine("the Doctor Id not found");
                    return;
                }
            }

            //appointment Info

            Console.WriteLine("Enter the appointment Id");
            int appointmentOfId = int.Parse(Console.ReadLine());
            bool appointmentFound = false;
            foreach (var appointment in context.Appointments)
            {
                if (appointment.appointmentId == appointmentOfId)
                {
                    Console.WriteLine("the appointment Id found");
                    //To updated to reflect that the visit has been completed
                    appointment.status = "completed";
                    appointmentFound = true;
                  
                    break;
                }
                else
                {
                    Console.WriteLine("the appointment Id not found");
                    return;
                }
                
            }

            Console.WriteLine("Enter the diagnosis");
            string diagnosisUser = Console.ReadLine();

            Console.WriteLine("Enter the prescription");
            string prescriptionUser = Console.ReadLine();

            Console.WriteLine("Enter the visitDate");
            string visitDateUser = Console.ReadLine();
  
            int recordIdNew = (context.MedicalRecordcs.Count) + 1;
            context.MedicalRecordcs.Add(
                new MedicalRecordc
                {
                    recordId = recordIdNew,
                    patientId = patientOfId,
                    doctorId= doctorOfId,
                    appointmentId= appointmentOfId,
                    diagnosis= diagnosisUser,
                    prescription= prescriptionUser,
                    visitDate= visitDateUser,
                    visitFee= visitFeeUser
                }
                );

            Console.WriteLine("Record Id Added Successfully with ID " + recordIdNew);
        } 

        //Main the program Function
        static void Main(string[] args)
        {
            //data storage for the system ( in memory )
            HospitalContext mainContext = new HospitalContext();
            mainContext.patients = new List<Patient>();
            mainContext.MedicalRecordcs = new List<MedicalRecordc>();
            mainContext.Decoders = new List<Doctor>();
            mainContext.AvailableSlotcs = new List<AvailableSlotc>();
            mainContext.Appointments = new List<Appointment>();

            bool stop = false;

            while (stop ==false)
            {
                //the  menu of the system 

                Console.WriteLine("Welcom to the Hospital Management System");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1-Register patien");
                Console.WriteLine("2-Add a New Doctor");
                Console.WriteLine("3-View All Patients");
                Console.WriteLine("4-View All Doctors by Specialization");
                Console.WriteLine("5-Add an Available Time Slot for a Doctor");
                Console.WriteLine("6-Book an Appointment");
                Console.WriteLine("7-Cancel an Appointment");
                Console.WriteLine("8-Create a Medical Record After a Visit");
                Console.WriteLine("10-Generate a Patient Medical History Report");
                Console.WriteLine("11-Doctor Workload and Revenue Summary");
                Console.WriteLine("0- Exit");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        PatientRegistration(mainContext);
                        break;
                    case 2:
                        AddDcotor(mainContext);

                        break;
                    case 3:
                        ViewAllPatients(mainContext);
                        break;
                    case 4:
                        ViewDoctorsBySpecialization(mainContext);
                        break;
                    case 5:
                        AddAvailableTimeSlot(mainContext);
                        break;
                    case 6:
                        BookAppointment(mainContext);
                        break;
                    case 7:
                        CancelAppointment(mainContext);
                        break;
                    case 8:
                        MedicalRecordAfterVisit(mainContext);
                        break;
                    case 9:

                        break;
                    case 10:

                        break;
                    case 0:

                        break;

                }

                //To clear the cosole page 
                Console.WriteLine("Please press any key ...");
                Console.ReadKey();
                Console.Clear();

            }











        }
    }
}
