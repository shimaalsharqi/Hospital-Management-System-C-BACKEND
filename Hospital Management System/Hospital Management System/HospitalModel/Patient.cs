using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class Patient
    {
        public int patientId { get; set; }
        public string patientName { get; set; }
        public int patientAge { get; set; }
        public string patientGender { get; set; }
        public string patientPhone { get; set; }
        public string patientEmail { get; set; }
        public string patientBloodType { get; set; }

        //Function To Convert the Data To String
        public void ConvertDataPatientToString()
        {
            Console.WriteLine($"{patientId} | {patientName,-10} | {patientGender,-8} |{patientPhone,-8} |" +
                $" {patientEmail,-8} | {patientBloodType,-8} | {patientAge,9}" );
        }


    }
}
