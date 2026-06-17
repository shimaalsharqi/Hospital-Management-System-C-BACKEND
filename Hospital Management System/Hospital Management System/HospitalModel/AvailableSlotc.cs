using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class AvailableSlotc
    {
        public int slotId { get; set; }
        public int doctorId { get; set; }
        public string slotDate { get; set; }
        public string slotTime { get; set; }
        public bool isBooked { get; set; } = false;

        //Function To Convert the Data To String
        public void ConvertDataAvailableSlotcToString()
        {
            Console.WriteLine($"{slotId} | {doctorId} | {slotDate,-8} |{slotTime,-8} | {isBooked}");
        }
    }
}
