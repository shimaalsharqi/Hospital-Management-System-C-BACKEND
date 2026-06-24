using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Booking
    {
        public int bookingId { get; set; }//System Generated
        public int passengerId { get; set; }//User Input
        public int flightId { get; set; }//User Input from list
        public string seatNumber { get; set; }//System
        public string bookingDate { get; set; }//User Input
        public decimal totalPrice { get; set; }//Calculated
        public string status { get; set; }//Default Value  ,Confirmed | Cancelled
    }
}
