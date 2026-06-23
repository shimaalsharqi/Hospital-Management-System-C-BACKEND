using Flight_Management_System.Models;
using Microsoft.Win32;

namespace Flight_Management_System
{
    public class Program
    {

        //System storage
        public static FlightContext context = new FlightContext
        {
            Passengers = new List<Passenger>(),
            Pilots = new List<Pilot>(),
            Flights = new List<Flight>(),
            Aircrafts = new List<Aircraft>(),
            Bookings = new List<Booking>()
        };

        static void Main(string[] args)
        {
            bool stop = false;

            while (stop == false)
            {
                //the  menu of the system 

                Console.WriteLine("Welcom to the Hospital Management System");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1- Register a Passenger");
                Console.WriteLine("2-Add an Aircraft");
                Console.WriteLine("3-Register a Pilot");
                Console.WriteLine("4-View All Flights");
                Console.WriteLine("5-Schedule a Flight");
                Console.WriteLine("6- Book a Flight");
                Console.WriteLine("7-Cancel a Booking");
                Console.WriteLine("8-Depart a Flight");
                Console.WriteLine("9- Cancel a Flight");
                Console.WriteLine("10-Passenger Booking History");
                Console.WriteLine("11- Flight Revenue & Load Factor Report");
                Console.WriteLine("0- Exit");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //RegisterPassenger(); //Add,From List(Passengers)
                        break;
                    case 2:
                        //AddAircraft();  //Add,From List(Aircrafts)

                        break;
                    case 3:
                        // RegisterPilot(); //Add,From List(Pilots)
                        break;
                    case 4:
                        // ViewAllFlights(); //Read ,From List(Flights)
                        break;
                    case 5:
                        //ScheduleFlight(); //Add,internal read (Flights,Aircrafts,Pilots)
                        break;
                    case 6:
                        //BookFlight(); //Add,internal read (Bookings,Flights,Aircrafts,Pilots)
                        break;
                    case 7:
                        //CancelBooking();  //Internal Read,Update (Bookings)
                        break;

                    case 8:
                        //DepartFlight();  // Update
                        break;
                    case 9:
                        //CancelFlight(); //Internal Read,Update (Flights)
                        break;

                    case 10:
                        //PassengerBookingHistory(); //Read
                        break;
                    case 11:
                        //FlightRevenueAndLoadFactorReport(); //Read
                        break;
                    case 0:
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;

                }

                //To clear the cosole page 
                if (!stop)
                {
                    Console.WriteLine("Please press any key ...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}

