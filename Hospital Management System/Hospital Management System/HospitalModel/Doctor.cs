using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class Doctor
    {
        public int doctorId { get; set; }
        public string doctorName { get; set; }
        public string doctorSpecialization { get; set; }
        public string doctorPhone { get; set; }
        public string doctorEmail { get; set; }
        public decimal consultationFee { get; set; }

        //Function To Convert the Data To String
        public void ConvertDataPatientToString()
        {
            Console.WriteLine($"{doctorId} | {doctorName,-10} | {doctorSpecialization,-8} |{doctorPhone,-8} |" +
                $" {doctorEmail,-8} | {consultationFee,-8} ");
        }
    }
}
