using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class Appointment
    {
        public int appointmentId { get; set; }//System Generated
        public int patientId { get; set; }//From List
        public int doctorId { get; set; }//From List
        public string appointmentDate { get; set; }//System Calculated
        public string appointmentTime { get; set; }//System Calculated
        public string status { get; set; } //Default Value
    }
}
