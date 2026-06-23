using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class AvailableSlotc
    {
        public int slotId { get; set; }//System Generated
        public int doctorId { get; set; }//From List
        public string slotDate { get; set; }//User Input
        public string slotTime { get; set; }//User Input
        public bool isBooked { get; set; } = false; //Default Value

        //Function To Convert the Data To String
        public void ConvertDataAvailableSlotcToString()
        {
            Console.WriteLine($"{slotId} | {doctorId} | {slotDate,-8} |{slotTime,-8} | {isBooked}");
        }
    }
}
