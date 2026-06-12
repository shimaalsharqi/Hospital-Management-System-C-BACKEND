using System;
using System.Collections.Generic;
using System.Text;
using Hospital_Management_System.HospitalModel;

namespace Hospital_Management_System
{
    public class HospitalContext
    {
        //system storage
        public List <Patient> patients { get; set; }
        public List<MedicalRecordc> MedicalRecordcs { get; set; }
        public List<Doctor> Decoders { get; set; }
        public List<AvailableSlotc> AvailableSlotcs { get; set; }
        public List<Appointment> Appointments { get; set; }



    }
}
