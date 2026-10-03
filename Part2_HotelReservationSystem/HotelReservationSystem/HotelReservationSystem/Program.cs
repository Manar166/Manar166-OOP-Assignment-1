using HotelReservationSystem._ٍServices;
using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Reposatories;
using HotelReservationSystem.Models;

namespace HotelReservationSystem
{
    public class Program
    {
        public static List<Room> rooms = new List<Room>();

        public static List<Guest> Guests = new List<Guest>();

        public static List<Reservation> Reservations = new List<Reservation>();

        public static RoomRepository roomRepository = new RoomRepository();
        public static GuestRepository guestRepository = new GuestRepository();
        public static ReservationRepository reservationRepository = new ReservationRepository();

        //ReservationRepository reservationRepository = new ReservationRepository(roomRepository ,new GuestRepository());
        public static GuestService guestService = new GuestService();
        public static RoomService roomService = new RoomService(roomRepository);
        public static ReservationService reservationService = new ReservationService();
        static void Main(string[] args)
        {
            SeedData();
            MainMenu();


        }

        private static void SeedData()
        {
            // 🎯 إضافة غرف تجريبية
            roomRepository.AddRoom(101, RoomType.Single, 100m);
            roomRepository.AddRoom(102, RoomType.Double, 150m);
            roomRepository.AddRoom(201, RoomType.Suite, 300m);

            // 🎯 إضافة نزلاء تجريبيين (مع التأكد من وجود Constructor مناسب لكلاس Guest)
            guestRepository.AddGuest(1, "Ahmed Hassan", "01012345678");
            guestRepository.AddGuest(2, "Sara Ali", "01198765432");

            // 🎯 إضافة حجز تجريبي للـ Testing
            //reservationService.CreateReservation(
            //   I: 1,
            //    checkInTime: DateTime.Now.AddDays(1),
            //    checkOutTime: DateTime.Now.AddDays(4),
            //    roomNumber: 101,
            //    guestId: 1
            //);

            Console.WriteLine("✅ Initial Seed Data Added Successfully!\n");
        }

        public static void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=============================================");
                Console.WriteLine("     Hotel Reservation    ");
                Console.WriteLine("=============================================");
                Console.ResetColor();
                Console.WriteLine("1. Room Menu (Rooms)");
                Console.WriteLine("2. Guest Menu (Guests)");
                Console.WriteLine("3. Reservation Menu (Reservations)");
                Console.WriteLine("4. Exit");
                Console.WriteLine("=============================================");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            RoomMenu();
                            break;
                        case "2":
                            GuestMenu();
                            break;
                        case "3":
                            ReservationMenu();
                            break;
                        case "4":
                            exit = true;
                            Console.WriteLine("Thank you for using the system!");
                            break;
                        default:
                            Console.WriteLine("Invalid option, press Enter to try again.");
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"خطأ: {ex.Message}");
                }
            }
        }

        private static void RoomMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Room Menu ---");


                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add New Room");
                Console.WriteLine("2. Display All Rooms");
                Console.WriteLine("3. Display Room by Number");
                Console.WriteLine("4. Update Room Rate");
                Console.WriteLine("5. Start Room Maintenance");
                Console.WriteLine("6. End Room Maintenance");
                Console.WriteLine("7. Return to Main Menu");

                Console.Write("Choose an option: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        roomService.AddRoom();
                        Console.ReadKey();
                        break;
                    case "2":
                        roomService.DisplayAllRooms();
                        Console.ReadKey();
                        break;
                    case "3":
                        roomService.FindRoomByNumber();
                        Console.ReadKey();
                        break;
                    case "4":
                        roomService.UpdateRoomRate();
                        Console.ReadKey();
                        break;
                    case "5":
                        roomService.StartRoomMaintenance();
                        Console.ReadKey();
                        break;
                    case "6":
                        roomService.EndRoomMaintenance();
                        Console.ReadKey();
                        break;
                    case "7":
                        return;
                }
            }
        }
        private static void GuestMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Guest Menu ---");


                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add New Guest");
                Console.WriteLine("2. Display All Guests");
                Console.WriteLine("3. Display Guest by ID");
              
                Console.WriteLine("5. Return to Main Menu");

                Console.Write("Choose an option: ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        guestService.AddGuest();
                        Console.ReadKey();
                        break;
                    case "2":
                        guestService.DisplayAllGuests();
                        Console.ReadKey();
                        break;
                    case "3":
                        guestService.FindGuestById();
                        Console.ReadKey();
                        break;
                  

                    case "5":
                        return;
                }
            }
        }

        private static void ReservationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- Reservation Menu ---");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Create New Reservation");
                Console.WriteLine("2. Display All Reservations");
                Console.WriteLine("3. Display Reservation by Guest ID");

                Console.WriteLine("4. Return to Main Menu");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        reservationService.CreateReservation();
                        Console.ReadKey();
                        break;
                    case "2":
                        reservationService.DisplayAllReservations();
                        Console.ReadKey();
                        break;
                    case "3":
                        reservationService.FindReservationByGuestId();
                        Console.ReadKey();
                        break;

                        break;
                    case "4":
                        return;
                }
            }

        }
    }
}
