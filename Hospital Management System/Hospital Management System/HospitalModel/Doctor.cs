using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class Doctor
    {
        public int doctorId { get; set; }//System Generated
        public string doctorName { get; set; }//User Input
        public string doctorSpecialization { get; set; }//User Input
        public string doctorPhone { get; set; }//User Input
        public string doctorEmail { get; set; }//User Input
        public decimal consultationFee { get; set; }//System Calculated

        //Function To Convert the Data To String
        public void DoctorInfo()
        {
            Console.WriteLine($"{doctorId} | {doctorName,-10} | {doctorSpecialization,-8} |{doctorPhone,-8} |" +
                $" {doctorEmail,-8} | {consultationFee,-8} ");
        }
    }
}
