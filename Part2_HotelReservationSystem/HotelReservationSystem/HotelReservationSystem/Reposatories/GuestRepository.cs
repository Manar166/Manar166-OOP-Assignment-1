using System;
using System.Collections.Generic;
using System.Text;
using HotelReservationSystem.Models;
namespace HotelReservationSystem.Reposatories
{
    public class GuestRepository
    {
        List<Guest>  Guests = new List<Guest>();

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
    }
}
