using Flight_Management_System.Models;

namespace Flight_Management_System
{
    public class Program
    {

        //System storage
        public static FlightContext context = new FlightContext
        {
            Passengers=new  List<Passenger>(),
            Pilots = new List<Pilot>(),
            Flights = new List<Flight>(),
            Aircrafts = new List<Aircraft>(),
            Bookings = new List<Booking>()
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
