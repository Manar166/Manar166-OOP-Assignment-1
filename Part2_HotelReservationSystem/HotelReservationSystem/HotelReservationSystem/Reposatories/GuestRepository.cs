using System;
using System.Collections.Generic;
using System.Text;
using HotelReservationSystem.Models;
namespace HotelReservationSystem.Reposatories
{
    public class GuestRepository
    {
        List<Guest> Guests = Program.Guests;

        public void AddGuest(int id, string fullName, string phoneNumber)
        {
            
            if(Guests.Exists(n=>n.Id == id))
            {
                throw new InvalidOperationException($"Guest with ID {id} already exists.");
            }
            try
            {
                Guests.Add(new Guest(id, fullName, phoneNumber));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

       

        public Guest? GetGuestById(int id)
        {
          
            return Guests.Find(n => n.Id == id);
        }

        public List<Guest> GetAllGuests()
        {
            return Guests;
        }

        //public void GetGuestReservations(int guestId)
        //{
        //    Guest? guest = GetGuestById(guestId);
        //    if (guest is null)
        //    {
        //        throw new Exception($"Guest with ID {guestId} not found.");
        //    }
        //    var reservations = guest.Reservations;
        //    if (reservations.Count == 0)
        //    {
        //        Console.WriteLine($"No reservations found for guest {guest.FullName}.");
        //        return;
        //    }
        //    Console.WriteLine($"Reservations for guest {guest.FullName}:");
        //    foreach (var reservation in reservations)
        //    {
        //        Console.WriteLine($"Reservation ID: {reservation.Id}, Room Number: {reservation.RoomId}, Check-In: {reservation.CheckInTime}, Check-Out: {reservation.CheckOutTime}, Status: {reservation.Status}");
        //    }
        //}
    }
}
