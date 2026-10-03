using System;
using System.Collections.Generic;
using System.Text;



using HotelReservationSystem.Models;
using System.Xml;
using HotelReservationSystem.Reposatories;

namespace HotelReservationSystem._ٍServices
{
    public class GuestService
    {
        GuestRepository guestRepository = Program.guestRepository;
        public void AddGuest()
        {
            Console.WriteLine("Enter Guest ID");
            bool IsIdParsed = int.TryParse(Console.ReadLine(), out int Id);
            if (!IsIdParsed)
            {
                Console.WriteLine("Please Enter Vaild ID");
                return;
            }
            Console.WriteLine("Enter FullName");
            string? Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Please Enter Vaild Name");
                return;
            }
            Console.WriteLine("Enter PhoneNumber");

            string? PhoneNumber = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                Console.WriteLine("Please Enter Vaild PhoneNumber");
                return;
            }
            try
            {
                guestRepository.AddGuest(Id, Name, PhoneNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);




            }
        }

        //public string GetGuestReservations(int id)
        //{
        //    Console.WriteLine("Enter Guest ID");
        //    bool IsIdParsed = int.TryParse(Console.ReadLine(), out int GuestId);
        //    if (!IsIdParsed)
        //    {
        //        Console.WriteLine("Please Enter Vaild ID");
        //        return string.Empty;
        //    }
        //    var guest = guestRepository.GetGuestById(GuestId);
        //    if (guest is null)
        //    {
        //        Console.WriteLine("Guest not found.");
        //        return string.Empty;
        //    }
        //    if (guest.Reservations.Count == 0)
        //    {
        //        return $"No reservations found for guest {guest.FullName}.";
        //    }
        //    StringBuilder reservations = new StringBuilder();

        //    foreach (var item in guest.Reservations)
        //    {

        //        reservations.AppendLine($"Id={item.Id}## Check IN Date={item.CheckInTime},##Check_out_Date={item.CheckOutTime} ## Room Number={item.Room?.Number}## status={item.Status.ToString()}");

        //    }

        //    return reservations.ToString();


        //}


        public void DisplayAllGuests()
        {
            var guests = guestRepository.GetAllGuests();
            if (guests.Count == 0)
            {
                Console.WriteLine("No guests found.");
                return;
            }
            foreach (var guest in guests)
            {
                Console.WriteLine($"Guest ID: {guest.Id}, Name: {guest.FullName}, Phone: {guest.PhoneNumber}");
            }
        }

        public void DisplayGuestReservations()
        {
            Console.WriteLine("Enter Guest ID to view reservations:");
            bool isValidId = int.TryParse(Console.ReadLine(), out int id);
            if (!isValidId)
            {
                Console.WriteLine("Invalid Guest ID. Please enter a valid integer.");
                return;
            }
            var guest = guestRepository.GetGuestById(id);
            if (guest is null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }
            if (guest.Reservations.Count == 0)
            {
                Console.WriteLine($"No reservations found for guest {guest.FullName}.");
                return;
            }
            Console.WriteLine($"Reservations for guest {guest.FullName}:");
            foreach (var reservation in guest.Reservations)
            {
                Console.WriteLine($"Reservation ID: {reservation.Id}, Room Number: {reservation.RoomId}, Check-In: {reservation.CheckInTime}, Check-Out: {reservation.CheckOutTime}, Status: {reservation.Status}");
            }

        }
        public void FindGuestById()
        {
            Console.WriteLine("Enter Guest ID to search:");
            bool isValidId = int.TryParse(Console.ReadLine(), out int id);
            if (!isValidId)
            {
                Console.WriteLine("Invalid Guest ID. Please enter a valid integer.");
                return;
            }
            var guest = guestRepository.GetGuestById(id);
            if (guest is null)
            {
                Console.WriteLine($"Guest with ID {id} not found.");
                return;
            }
            Console.WriteLine($"Guest ID: {guest.Id}, Name: {guest.FullName}, Phone: {guest.PhoneNumber}");
            if(guest.Reservations.Count > 0)
            {
                Console.WriteLine("Reservations:");
                foreach (var reservation in guest.Reservations)
                {
                    Console.WriteLine($"Reservation ID: {reservation.Id}, Room Number: {reservation.RoomId}, Check-In: {reservation.CheckInTime}, Check-Out: {reservation.CheckOutTime}, Status: {reservation.Status}");
                }
            }
            else
            {
                Console.WriteLine("No reservations found for this guest.");
            }   
        }

    }
}

        
    
