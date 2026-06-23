using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class Patient
    {
        public int patientId { get; set; }//system Generated
        public string patientName { get; set; } //User Input
        public int patientAge { get; set; }//User Input
        public string patientGender { get; set; }//User Input
        public string patientPhone { get; set; }//User Input
        public string patientEmail { get; set; }//User Input
        public string patientBloodType { get; set; }//User Input

        //Function To Convert the Data To String
        public void PatientInfo()
        {
            Console.WriteLine($"{patientId} | {patientName,-10} | {patientGender,-8} |{patientPhone,-8} |" +
                $" {patientEmail,-8} | {patientBloodType,-8} | {patientAge,9}" );
        }


    }
}
