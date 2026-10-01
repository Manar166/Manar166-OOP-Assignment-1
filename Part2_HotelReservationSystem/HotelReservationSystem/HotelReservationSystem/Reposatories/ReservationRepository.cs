using HotelReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem.Reposatories
{
    public class ReservationRepository
    {
        List<Reservation> reservations = new List<Reservation>();
        public void AddReservation(int id, DateTime checkInTime, DateTime checkOutTime, Room room, Guest guest)
        {
            try
            {
                Reservation reservation = new Reservation(id, checkInTime, checkOutTime, room, guest);

                reservations.Add(reservation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding reservation: {ex.Message}");

            }
        }   


        public List<Reservation> GetReservations()
        {
            return reservations;
        }

        public Reservation? GetReservationById(int id)
        {
            return reservations.Find(r => r.Id == id);
        }
        public Reservation? GetReservationByGuestId(int guestId)
        {
            return reservations.Find(r => r.Guest.Id == guestId);
        }
    }
}
