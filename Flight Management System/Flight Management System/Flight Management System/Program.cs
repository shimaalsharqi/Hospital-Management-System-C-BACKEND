using Flight_Management_System.Models;
using Microsoft.Win32;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

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

        //1 Register a Passenger Funcation
        public static void RegisterPassenger()
        {
            Console.WriteLine("=====================Register a Passenger====================");
            Console.WriteLine("Enter passenger  Full name");
            string pName = Console.ReadLine();
            Console.WriteLine("Enter Passenger Email");
            string pEmail = Console.ReadLine();
            Console.WriteLine("Enter Passenger Phone Number");
            string pPhone = Console.ReadLine();
            Console.WriteLine("Enter Passenger passport Number");
            string passportNumber = Console.ReadLine();
            Console.WriteLine("Enter Passenger nationality");
            bool checkpassportNumber = context.Passengers.Any(p => p.passportNumber == passportNumber);
            if (checkpassportNumber == true)
            {
                Console.WriteLine("Can not passport Number be repeat ");
                return;
            }
            string pnationality = Console.ReadLine();

            int passengerId = (context.Passengers.Count) + 1;

            context.Passengers.Add(
                new Passenger
                {
                    passengerId= passengerId,
                    passengerName= pName,
                    passengerEmail= pEmail,
                    passengerPhone= pPhone,
                    passportNumber= passportNumber,
                    nationality= pnationality

                });
            Console.WriteLine($"Register a Passenger Sucsseful with Id{passengerId}");
        }
        // 2  Add an Aircraft Funcation
        public static void AddAircraft()
        {
            Console.WriteLine("=====================Add an Aircraft====================");
            Console.WriteLine("Enter Aircraft Model");
            string aircraftModel = Console.ReadLine();
            Console.WriteLine("Enter Aircraft total Seats");
            int aircraftTotalSeats =int.Parse( Console.ReadLine());

            int aircraftId = (context.Aircrafts.Count) + 1;
            context.Aircrafts.Add(
               new Aircraft
               {
                   aircraftId = aircraftId,
                   model = aircraftModel,
                   totalSeats = aircraftTotalSeats,
                   isOperational = true
               });
            Console.WriteLine($"Add an Aircraft Sucsseful with Id{aircraftId}");
        }
        //3 Register a Pilot
        public static void RegisterPilot()
        {
            Console.WriteLine("=====================Register a Pilot====================");
            Console.WriteLine("Enter Pilot  Full name");
            string pilotNameInput = Console.ReadLine();
            Console.WriteLine("Enter Pilot Phone");
            string pilotPhoneInput = Console.ReadLine();
            Console.WriteLine("Enter Pilot license Number");
            string pilotlicenseNumber = Console.ReadLine();
            Console.WriteLine("Enter flight Hours");
            int passportNumber = int.Parse(Console.ReadLine());

            int pilotId = (context.Pilots.Count) + 1;
            context.Pilots.Add(
               new Pilot
               {
                   pilotId = pilotId,
                   pilotName = pilotNameInput,
                   pilotPhone = pilotPhoneInput,
                   licenseNumber = pilotlicenseNumber,
                   flightHours = 0,
                   isAvailable = true
               });
            Console.WriteLine($"Register a Pilot Sucsseful with Id{pilotId}");
        }

        //4 View All Flights
        public static void ViewAllFlights()
        {
            Console.WriteLine("===================== View All Flights ====================");
            foreach(Flight s in context.Flights)
            {
                Console.WriteLine($"  flight Id: {s.flightId}  |  aircraft Id: {s.aircraftId}  |" +
                    $"  flight Code: {s.flightCode} pilot Id: {s.pilotId}  |  origin: {s.origin}  |" +
                    $"destination: {s.destination} departureDate: {s.departureDate}  |  departureTime: {s.departureTime}  |" +
                    $"ticketPrice: {s.ticketPrice} duration: {s.duration}  |  availableSeats: {s.availableSeats} |  status: {s.status} |");
            }
        }
        //5 Schedule a Flight
        public static void ScheduleFlight()
        {
            Console.WriteLine("=====================Schedule a Flight====================");
            //choose an aircraft from the available operational fleet 
            List<Aircraft> aircraftsAvailable = context.Aircrafts.Where(a => a.isOperational == true).ToList();
            if (aircraftsAvailable.Count==0)
            {
                Console.WriteLine("there are no aircrafts are available operational ");
                return;
            }
            //View the aircraft 

            foreach (Aircraft d in aircraftsAvailable)
            {
                Console.WriteLine($"  ID: {d.aircraftId}  |  {d.model}");
            }

            Console.WriteLine("Enter aircraft Id");
            int aircraftIdInput = int.Parse(Console.ReadLine());
            //check
            Aircraft checkaircraftId = context.Aircrafts.FirstOrDefault(s => s.aircraftId == aircraftIdInput);
            if (checkaircraftId == null)
            {
                Console.WriteLine("Invalid aircraft Id ");
                return;
            }

            //assign a pilot.  
            List<Pilot> PilotsAvailable = context.Pilots.Where(a => a.isAvailable == true).ToList();
            if (PilotsAvailable.Count==0)
            {
                Console.WriteLine("there are no Pilots are available  ");
                return;
            }
            //View the  pilot Id

            foreach (Pilot d in PilotsAvailable)
            {
                Console.WriteLine($"  ID: {d.pilotId}  |  pilot Name: {d.pilotName}");
            }

            Console.WriteLine("Enter pilot Id");
            int pilotIdInput = int.Parse(Console.ReadLine());

            //check
            bool checkpilotId = context.Pilots.Any(p => p.pilotId == pilotIdInput);
            if (checkpilotId == false)
            {
                Console.WriteLine("Invalid pilot Id ");
                return;
            }

            Console.WriteLine("Enter origin");
            string originInput = Console.ReadLine();
            Console.WriteLine("Enter destination");
            string destinationInput = Console.ReadLine();
            Console.WriteLine("Enter departure Date");
            string departureDateInput = Console.ReadLine();
            Console.WriteLine("Enter departure Time");
            string departureTimeInput = Console.ReadLine();
            Console.WriteLine("Enter ticket Price");
            decimal ticketPriceInput = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter duration");
            int durationInput = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter flight Code");

            //Genrate flight Code by system
            string flightCodeSystem = "OA" + ((context.Flights.Count) + 1);
            //Genrate flight Id by system
            int flightId = (context.Flights.Count) + 1;

            context.Flights.Add(
               new Flight
               {
                   flightId = flightId,
                   flightCode = flightCodeSystem,
                   aircraftId = aircraftIdInput,
                   pilotId = pilotIdInput,
                   origin = originInput,
                   destination = destinationInput,
                   departureDate = departureDateInput,
                   departureTime = departureTimeInput,
                   ticketPrice = ticketPriceInput,
                   duration = durationInput,
                   availableSeats = checkaircraftId.totalSeats,
                   status = "Scheduled"
               });
            Console.WriteLine($"Register a Pilot Sucsseful with Id{flightId} and flight Code:{flightCodeSystem}");


        }
        //6  Book a Flight
        public static void BookFlight()
        {
            Console.WriteLine("=====================Book a Flight====================");
            Console.WriteLine("Enter Passenger Id");
            int passengerIdInput = int.Parse(Console.ReadLine());

            //check
            bool checkpilotId = context.Passengers.Any(p => p.passengerId == passengerIdInput);
            if (checkpilotId == false)
            {
                Console.WriteLine("Invalid Passenger Id ");
                return;
            }
            Console.WriteLine("Enter destination");
            string destinationInput = Console.ReadLine();

            List<Flight> Flightsavailable = context.Flights.Where(f => f.availableSeats > 0  
                                                                         && f.destination== destinationInput
                                                                         && f.status== "Scheduled")
                                                                .ToList();
            if (Flightsavailable == null)
            {
                Console.WriteLine("No available Seats Or choose the correct destination");
                return;
            }
            foreach(Flight s in Flightsavailable)
            {
                Console.WriteLine($"  flight Id: {s.flightId}  |  aircraft Id: {s.aircraftId}  |" +
                    $"  flight Code: {s.flightCode} pilot Id: {s.pilotId}  |  origin: {s.origin}  |" +
                    $"destination: {s.destination} departureDate: {s.departureDate}  |  departureTime: {s.departureTime}  |" +
                    $"ticketPrice: {s.ticketPrice} duration: {s.duration}  |  availableSeats: {s.availableSeats} |  status: {s.status} |");
            }
            Console.WriteLine("Enter Flight Id");
            int FlightIdInput = int.Parse(Console.ReadLine());

            //check
           
            Flight checkFlightId = context.Flights.FirstOrDefault(p => p.flightId == FlightIdInput);
            if (checkpilotId == null)
            {
                Console.WriteLine("Invalid Flight Id ");
                return;
            }
            Console.WriteLine("Enter booking Date");
            string bookingDateInput = Console.ReadLine();
            int bookingId = context.Bookings.Count + 1;

            string seatLabel = "Seat-" + (context.Bookings.Count + 1);

            context.Bookings.Add(
               new Booking
               {
                   bookingId = bookingId,
                   passengerId = passengerIdInput,
                   flightId = FlightIdInput,
                   seatNumber = seatLabel,
                   bookingDate = bookingDateInput,
                   totalPrice = checkFlightId.ticketPrice,
                   status = "Confirmed"

               });
            
            checkFlightId.availableSeats= checkFlightId.availableSeats - 1;

            Console.WriteLine($"The Booking  Sucsseful with Id{bookingId} and seat Label:{seatLabel}");


        }
        //7 Cancel a Booking
        public static void CancelBooking()
        {
            Console.WriteLine("=====================Cancel a Booking====================");
            Console.WriteLine("Enter Passenger Id");
            int passengerIdInput = int.Parse(Console.ReadLine());

            //check
            bool checkPassengerId = context.Passengers.Any(p => p.passengerId == passengerIdInput);
            if (checkPassengerId == false)
            {
                Console.WriteLine("Invalid Passenger Id ");
                return;
            }
            List<Flight> FlightsView = context.Flights.Where(f =>f.status == "Scheduled")
                                                           .ToList();

            if (FlightsView.Count==0)
            {
                Console.WriteLine("Flight Departed Or Cancelled");
                return;
            }
            foreach (Flight s in FlightsView)
            {
                Console.WriteLine($"  flight Id: {s.flightId}  |  aircraft Id: {s.aircraftId}  |" +
                    $"  flight Code: {s.flightCode} pilot Id: {s.pilotId}  |  origin: {s.origin}  |" +
                    $"destination: {s.destination} departureDate: {s.departureDate}  |  departureTime: {s.departureTime}  |" +
                    $"ticketPrice: {s.ticketPrice} duration: {s.duration}  |  availableSeats: {s.availableSeats} |  status: {s.status} |");
            }
            Console.WriteLine("Enter Flight Id");
            int FlightIdInput = int.Parse(Console.ReadLine());

            //check Flight Id

            Flight checkFlightId = context.Flights.FirstOrDefault(p => p.flightId == FlightIdInput);
            if (checkFlightId == null)
            {
                Console.WriteLine("Invalid Flight Id ");
                return;
            }

            Console.WriteLine("Enter Booking Id");
            int bookingIdInput = int.Parse(Console.ReadLine());

            //check booking Id
            Booking bookingIdFound = context.Bookings.FirstOrDefault(p => p.bookingId == bookingIdInput 
                                                                       && p.status== "Confirmed");
            if (bookingIdFound == null)
            {
                Console.WriteLine("Invalid Booking Id ");
                return;
            }

            // status is set to Cancelled
            bookingIdFound.status = "Cancelled";
            //the seat is returned to the flight
            checkFlightId.availableSeats = checkFlightId.availableSeats + 1;

            Console.WriteLine("The Booking is Cancel Successful");
        }
        //8 Depart a Flight 
        public static void DepartFlight()
        {
            List<Flight> ScheduledFlight = context.Flights.Where(a => a.status == "Scheduled").ToList();
            if (ScheduledFlight.Count==0)
            {
                Console.WriteLine("Flight Departed Or Cancelled");
                return;
            }
            foreach (Flight f in ScheduledFlight)
            {
                Console.WriteLine($"flight Id:{f.flightId}| flight Code:{f.flightCode}");
            }
            Console.WriteLine("Enter Flight Id");
            int FlightIdInput = int.Parse(Console.ReadLine());

            //check Flight Id

            Flight checkFlightId = context.Flights.FirstOrDefault(p => p.flightId == FlightIdInput);
            if (checkFlightId == null)
            {
                Console.WriteLine("Invalid Flight Id ");
                return;
            }
            checkFlightId.status = "Departed";

            Console.WriteLine("Enter Pilot Id");
            int PilotIdInput = int.Parse(Console.ReadLine());

            Pilot pilotIdFound = context.Pilots.FirstOrDefault(p => p.pilotId == PilotIdInput);
            if (checkFlightId == null)
            {
                Console.WriteLine("Invalid Pilot Id ");
                return;
            }
            pilotIdFound.isAvailable = false;
            pilotIdFound.flightHours = pilotIdFound.flightHours + checkFlightId.duration;

            Console.WriteLine($"Flight {checkFlightId.flightCode} departed successfully.");
        }

        //9 Cancel a Flight
        public static void CancelFlight()
        {
            Console.WriteLine("===================== Cancel a Flight =====================");

       
            List<Flight> scheduledFlights = context.Flights
                                                   .Where(f => f.status == "Scheduled")
                                                   .ToList();

            if (scheduledFlights.Count == 0)
            {
                Console.WriteLine("There are no scheduled flights.");
                return;
            }

            foreach (Flight f in scheduledFlights)
            {
                Console.WriteLine($"Flight Id: {f.flightId} | Flight Code: {f.flightCode}");
            }

            Console.WriteLine("Enter Flight Id:");
            int flightIdInput = int.Parse(Console.ReadLine());

     
            Flight selectedFlight = context.Flights
                                           .FirstOrDefault(f => f.flightId == flightIdInput);

            if (selectedFlight == null)
            {
                Console.WriteLine("Invalid Flight Id.");
                return;
            }
            // flight is cancelled
            selectedFlight.status = "Cancelled";

            //e pilot assigned to that flight becomes available again
            Pilot assignedPilot = context.Pilots
                                         .FirstOrDefault(p => p.pilotId == selectedFlight.pilotId);

            if (assignedPilot != null)
            {
                assignedPilot.isAvailable = true;
            }

         
            List<Booking> affectedBookings = context.Bookings
                                                    .Where(b => b.flightId == selectedFlight.flightId
                                                             && b.status == "Confirmed")
                                                    .ToList();

            foreach (Booking booking in affectedBookings)
            {
                booking.status = "Cancelled";
            }

            //The system reports how many bookings were affected

            int affectedCount = affectedBookings.Count;

            Console.WriteLine($"Flight {selectedFlight.flightCode} was cancelled successfully.");
            Console.WriteLine($"{affectedCount} booking(s) were affected.");
        }

        //10 Passenger Booking History
        public static void PassengerBookingHistory()
        {
            Console.WriteLine("===================== Passenger Booking History =====================");

            Console.WriteLine("Enter Passenger Id");
            int PassengerIdInput = int.Parse(Console.ReadLine());

            Passenger checkPassengerId =
                context.Passengers.FirstOrDefault
                (p => p.passengerId == PassengerIdInput);

            if (checkPassengerId == null)
            {
                Console.WriteLine("Invalid Passenger Id");
                return;
            }

            List<Booking> bookingPassenger =
                context.Bookings
                .Where(b => b.passengerId == PassengerIdInput)
                .ToList();

            if (bookingPassenger.Count == 0)
            {
                Console.WriteLine("This passenger has no bookings.");
                return;
            }

            decimal totalSpent = 0;

            foreach (Booking f in bookingPassenger)
            {
                Flight flightIdFound =context.Flights.FirstOrDefault (a => a.flightId == f.flightId);

                if (flightIdFound == null)
                {
                    continue;
                }

              
                Console.WriteLine($"Flight Code: {flightIdFound.flightCode}");
                Console.WriteLine($"Origin: {flightIdFound.origin}");
                Console.WriteLine($"Destination: {flightIdFound.destination}");
                Console.WriteLine($"Departure Date: {flightIdFound.departureDate}");
                Console.WriteLine($"Seat Number: {f.seatNumber}");
                Console.WriteLine($"Price Paid: {f.totalPrice}");
                Console.WriteLine($"Booking Status: {f.status}");

                if (f.status == "Confirmed")
                {
                    totalSpent += f.totalPrice;
                }
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Total Amount Spent: {totalSpent}");
        }
        //Flight Revenue & Load Factor Report
        public static void FlightRevenueAndLoadFactorReport()
        {

        }
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
                        RegisterPassenger(); //Add,From List(Passengers)
                        break;
                    case 2:
                        AddAircraft();  //Add,From List(Aircrafts)

                        break;
                    case 3:
                        RegisterPilot(); //Add,From List(Pilots)
                        break;
                    case 4:
                        ViewAllFlights(); //Read ,From List(Flights)
                        break;
                    case 5:
                        ScheduleFlight(); //Add,internal read (Flights,Aircrafts,Pilots)
                        break;
                    case 6:
                        BookFlight(); //Add,internal read ,Update(Bookings,Flights,Aircrafts,Pilots)
                        break;
                    case 7:
                        CancelBooking();  //Internal Read,Update (Bookings)
                        break;

                    case 8:
                        DepartFlight();  // Update
                        break;
                    case 9:
                        CancelFlight(); //Internal Read,Update (Flights)
                        break;

                    case 10:
                        PassengerBookingHistory(); //Read,Update
                        break;
                    case 11:
                        FlightRevenueAndLoadFactorReport(); //Read
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

