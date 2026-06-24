using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Flight
    {
        public int flightId { get; set; }//System Generated
        public string flightCode { get; set; }//System Generated
        public int aircraftId { get; set; }//User input from the List
        public int pilotId { get; set; }//User input from the List
        public string origin { get; set; }//User Input
        public string destination { get; set; }//User Input
        public string departureDate { get; set; }//User Input
        public string departureTime { get; set; }//User Input
        public decimal ticketPrice { get; set; }//User Input
        public double duration { get; set; }//User Input
        public int availableSeats { get; set; }  //Calculated

        public string status { get; set; }//Default Value, Scheduled | Departed | Cancelled

    }
}
