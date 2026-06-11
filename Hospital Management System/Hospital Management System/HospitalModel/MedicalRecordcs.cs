using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital_Management_System.HospitalModel
{
    public class MedicalRecordcs
    {
        public int recordId { get; set; }
        public int appointmentId { get; set; }
        public int patientId { get; set; }
        public int doctorId { get; set; }
        public string diagnosis { get; set; }
        public string prescription { get; set; }
        public string visitDate { get; set; }
        public decimal visitFee { get; set; }

    }
}
