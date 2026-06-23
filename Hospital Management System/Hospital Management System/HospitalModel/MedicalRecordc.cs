using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class MedicalRecordc
    {
        public int recordId { get; set; }//System Generated
        public int appointmentId { get; set; }//User Input
        public int patientId { get; set; }//User Calculated From appointmentId
        public int doctorId { get; set; }//User Calculated From  appointmentId
        public string diagnosis { get; set; }//User Input
        public string prescription { get; set; }//User Input
        public string visitDate { get; set; }//User Calculated From  appointmentId
        public decimal visitFee { get; set; }//User Calculated From  doctorId

    }
}
