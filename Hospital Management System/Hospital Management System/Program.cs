using Hospital_Management_System.HospitalModel;
using System.Reflection;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Hospital_Management_System

{
    public class Program
    {

        //Patient Registration Function
        public static void PatientRegistration(HospitalContext context) {
            //patient information
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Gender");
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
        //Add a New Doctor Function
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
        //View All Patients Function

        public static void ViewAllPatients(HospitalContext context)
        {
            if (context.Decoders.Count== 0)
            {
                Console.WriteLine("No patients registered yet.");
                return;
            }
            else
            {
                foreach (var patient in context.patients)
                {
                    
                    Console.WriteLine("ID: " + patient.patientId);
                    Console.WriteLine("Name: " + patient.patientName);
                    Console.WriteLine("Age: " + patient.patientAge);
                    Console.WriteLine("Gender: " + patient.patientGender);
                    Console.WriteLine("Phone: " + patient.patientPhone);
                    Console.WriteLine("Email: " + patient.patientEmail);
                    Console.WriteLine("Blood Type: " + patient.patientBloodType);
                }
            }
        }

        //View All Doctors by Specialization Function

        public static void ViewDoctorsBySpecialization(HospitalContext context)
        {
            Console.WriteLine("Enter Specialization:");
            string specialization = Console.ReadLine();

            bool found = false;

            foreach (var doctor in context.Decoders)
            {
                if (doctor.doctorSpecialization == specialization)
                {
                    found = true;

                    Console.WriteLine("ID: " + doctor.doctorId);
                    Console.WriteLine("Name: " + doctor.doctorName);
                    Console.WriteLine("Specialization: " + doctor.doctorSpecialization);
                    Console.WriteLine("Phone: " + doctor.doctorPhone);
                    Console.WriteLine("Email: " + doctor.doctorEmail);
                   
                }
            }

            if (found == false)
            {
                Console.WriteLine("No doctors found with this specialization.");
            }
        }
       

        //Main the program
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

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:

                        break;
                    case 10:

                        break;
                    case 11:

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
