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
        //data storage for the system ( in memory )
        public static HospitalContext context = new HospitalContext
        {
            patients = new List<Patient>(),
            Decoders = new List<Doctor>(),
            Appointments = new List<Appointment>(),
            MedicalRecordcs = new List<MedicalRecordc>(),
            AvailableSlotcs = new List<AvailableSlotc>()
        };
        //1 Patient Registration Function
        public static void PatientRegistration()
        {
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
                    patientId = userId,
                    patientName = name,
                    patientAge = age,
                    patientGender = gender,
                    patientPhone = phoneNumber,
                    patientEmail = Email,
                    patientBloodType = bloodType


                }
              );
            Console.WriteLine("Pateint  Added Successfully with ID " + userId);

        }

        //2 Add a New Doctor Function
        public static void AddDcotor()
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
        public static void ViewAllPatients()
        {

            //If no patients have been registered
            if (context.patients.Count == 0)
            {
                Console.WriteLine("No patients registered yet.");
                return;
            }
            //To view every patient currently registered 
            foreach (var patient in context.patients)
            {

                patient.PatientInfo();
            }
        }


        //4 View All Doctors by Specialization Function
        public static void ViewDoctorsBySpecialization()
        {
            Console.WriteLine("Enter Specialization to search:");
            string specialization = Console.ReadLine().ToLower(); ;

            List<Doctor> DecodersSpecializationList = context.Decoders.Where(d => d.doctorSpecialization == specialization.ToLower()).ToList();

            if (DecodersSpecializationList.Count == 0)
            {
                Console.WriteLine("No doctors found with this specialization.");
                return;
            }
            foreach (Doctor DS in DecodersSpecializationList)
            {
                DS.DoctorInfo();
            }


        }


        //5 Add an Available Time Slot for a Doctor Function
        public static void AddAvailableTimeSlot()
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
            bool repeat = context.AvailableSlotcs
                                .Any(a => a.slotDate == dateOfSlot && a.slotTime == timeOfSlot && a.doctorId == doctorId);
            if (repeat == true)
            { Console.WriteLine("the date or time is repeated"); return; }


            //Add a new slot
            int slotId = (context.AvailableSlotcs.Count) + 1;

            context.AvailableSlotcs.Add(new AvailableSlotc
            {
                slotId = slotId,
                doctorId = doctorId,
                slotDate = dateOfSlot,
                slotTime = timeOfSlot,
                isBooked = false

            });

            Console.WriteLine($"the slot has been added{slotId}");

        }


        //6 Book an Appointment Function
        public static void BookAppointment()
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
            ViewDoctorsBySpecialization();

            //*********check if the doctor found By LINQ*********//
            Console.WriteLine("Enter the doctor Id");
            int IdOfDoctor = int.Parse(Console.ReadLine());
            bool doctorFound = context.Decoders
                                  .Any(a => a.doctorId == IdOfDoctor);
            if (doctorFound == false) { Console.WriteLine($"The doctor not  found "); return; }




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
            if (slotFound == null)
            {
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
                    appointmentDate = slotFound.slotDate,
                    appointmentTime = slotFound.slotTime,
                    status = "Scheduled"
                });
            slotFound.isBooked = true;
            Console.WriteLine("Book  Appointment Added Successfully with ID " + AppointmentId);
        }

        //7 Cancel an Appointment Function
        public static void CancelAppointment()
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

            //Enter the slot ID
            Console.WriteLine("Enter the slot Id");
            int idOfSlot = int.Parse(Console.ReadLine());

            AvailableSlotc slotFound = context.AvailableSlotcs
                                              .FirstOrDefault(a =>
                                             a.slotId == idOfSlot);

            if (slotFound == null)
            {
                Console.WriteLine("Invalid slot Id");
                return;
            }



            Console.WriteLine("Enter the Book Appointment Id");
            int bookAppointmentId = int.Parse(Console.ReadLine());
            Appointment bookAppointmentIdFound = context.Appointments
                                                        .FirstOrDefault(a => a.appointmentId == bookAppointmentId);
            if (bookAppointmentIdFound == null)
            {
                Console.WriteLine("The Book Appointment Id not found");
                return;
            }
            if (bookAppointmentIdFound.status == "canceled")
            {
                Console.WriteLine("The Book Appointment Id already cancel");
                return;
            }

            if (bookAppointmentIdFound.status == "Completed")
            {
                Console.WriteLine("Cannot cancel completed appointment");
                return;
            }
            bookAppointmentIdFound.status = "cancel";
            slotFound.isBooked = false;

            Console.WriteLine($"The Book Appointment be cancel now {bookAppointmentId}");


        }

        //8 Create a Medical Record After a Visit Function
        public static void MedicalRecordAfterVisit()
        {

            //appointment Info

            Console.WriteLine("Enter the appointment Id");
            int appointmentOfId = int.Parse(Console.ReadLine());
            Appointment bookAppointmentIdFound = context.Appointments
                                                          .FirstOrDefault(a => a.appointmentId == appointmentOfId);
            if (bookAppointmentIdFound == null)
            {
                Console.WriteLine("The Book Appointment Id not found");
                return;
            }
            if (bookAppointmentIdFound.status == "canceled")
            {
                Console.WriteLine("Cannot create a medical record for a cancelled appointment");
                return;
            }

            if (bookAppointmentIdFound.status == "Completed")
            {
                Console.WriteLine("A medical record already exists for this appointment");
                return;
            }
            // to get the consultationFee
            decimal fee = context.Decoders.Where(d => d.doctorId == bookAppointmentIdFound.doctorId)
                                         .Select(d => d.consultationFee)
                                         .FirstOrDefault();

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
                    appointmentId = appointmentOfId,
                    diagnosis = diagnosisUser,
                    prescription = prescriptionUser,
                    visitDate = visitDateUser,
                    visitFee = fee
                }
            );

            Console.WriteLine($"Record Id Added Successfully with ID   {recordIdNew}  | Fee charged: {fee}");
            bookAppointmentIdFound.status = "cmplated";
        }

        //9 Generate a Patient Medical History Report
        public static void GeneratePatientMedicalHistoryReport()
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

            List<MedicalRecordc> records = context.MedicalRecordcs
                                                  .Where(r => r.patientId == IdOfPatient)
                                                  .ToList();

            if (records.Count == 0)
            {
                Console.WriteLine("No medical records found");
                return;
            }
            records.ForEach(r =>
            {
                // to Know doctor name
                string doctorName = context.Decoders
                    .Where(d => d.doctorId == r.doctorId)
                    .Select(d => d.doctorName)
                    .FirstOrDefault();

                Console.WriteLine($" Record ID   : {r.recordId}");
                Console.WriteLine($"  Visit Date  : {r.visitDate}");
                Console.WriteLine($"  Doctor      : {doctorName}");
                Console.WriteLine($"  Diagnosis   : {r.diagnosis}");
                Console.WriteLine($"  Prescription: {r.prescription}");
                Console.WriteLine($"  Fee Charged : {r.visitFee}");

                // total all fees
                decimal total = records.Sum(r => r.visitFee);
                Console.WriteLine($"total amount: {total}");
            });

        }


        //10 Doctor Workload and Revenue Summary
        public static void DoctorRevenueSummary()
        {
            if (context.Appointments.Count == 0)
            {
                Console.WriteLine("No appointments recorded");
                return;
            }

            var doctorSummary = context.Decoders.Select(a => new { a.doctorId, a.doctorName, a.doctorSpecialization,
                //Count the completed Appointments
                completed = context.Appointments.Count(c=>c.doctorId==a.doctorId && c.status=="completed"),
                //Count the canceled Appointments
                canceled =context.Appointments.Count(d=>d.doctorId==a.doctorId && d.status=="canceled"),
                // sum the total Revenue
                sumRevenue= context.MedicalRecordcs.Where(r => r.doctorId==a.doctorId)
                                                   .Sum(r=>r.visitFee)

            }).OrderByDescending(b => b.sumRevenue)
              .ToList();
            Console.WriteLine("\n  Rank  | Doctor Name               | Specialization       | Completed | Cancelled | Total Revenue");

            for (int i = 0; i < doctorSummary.Count; i++)
            {
                var x = doctorSummary[i];
                Console.WriteLine($"  #{i + 1,-5} | {x.doctorName,-25} | {x.doctorSpecialization,-20} |" +
                                  $" {x.completed,-9} | {x.canceled,-9} | {x.sumRevenue:C}");
            }
        }
        //Main the program Function
        static void Main(string[] args)
        {

                bool stop = false;

                while (stop == false)
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
                    Console.WriteLine("9-Generate a Patient Medical History Report");
                    Console.WriteLine("10-Doctor Workload and Revenue Summary");
                    Console.WriteLine("0- Exit");

                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            PatientRegistration();//Add , List(Patient)
                            break;
                        case 2:
                            AddDcotor();//Add ,List(Dector)

                            break;
                        case 3:
                            ViewAllPatients();//Read ,List(Patient)
                            break;
                        case 4:
                            ViewDoctorsBySpecialization();//Reed,List(Dector)
                            break;
                        case 5:
                            AddAvailableTimeSlot();//Add,internal Read, List(Dector,Patient,AvailableTimeSlot)
                            break;
                        case 6:
                            BookAppointment();//Add,internal Read,update, List(Dector,Patient,AvailableTimeSlot,Appointment)
                           break;
                        case 7:
                            CancelAppointment();//internal Read,update, List( AvailableTimeSlot, Appointment)
                        break;
                          
                        case 8:
                            MedicalRecordAfterVisit();//Add,internal Read
                        break;
                        case 9:
                            GeneratePatientMedicalHistoryReport();//internal Read
                        break;
                      
                        case 10:
                            DoctorRevenueSummary();//Read
                           break;

                        case 0:
                            stop = true;
                            break;
                    default: Console.WriteLine("Invalid option. Please try again."); 
                        break;

                }

                //To clear the cosole page 
                if (!stop)
                {
                    Console.WriteLine("Please press any key ...");
                    Console.ReadKey();
                    Console.Clear();
                }
                }











            

        }
    }
}