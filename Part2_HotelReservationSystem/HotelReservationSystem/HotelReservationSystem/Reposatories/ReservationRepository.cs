using HotelReservationSystem.Models;
using HotelReservationSystem.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem.Reposatories
{
    public class ReservationRepository
    {
        RoomRepository _roomRepository = Program.roomRepository;
        GuestRepository _guestRepository = Program.guestRepository;

        List<Reservation> reservations = Program.Reservations;




        public void AddReservation(int id, DateTime checkInTime, DateTime checkOutTime, int roomNumber, int guestId)
        {
            if(reservations.Exists(n=>n.Id== id))
            {
                throw new Exception($"Reservation with ID {id} already exists.");
            }
            Room? room = _roomRepository.FindRoomByNumber(roomNumber);
            if(room == null)
            {
                throw new Exception($"Room with number {roomNumber} not found.");
               
              
            }
            
            Guest? guest = _guestRepository.GetGuestById(guestId);
            if (guest is null)
            {

                throw new Exception($"Guest with ID {guestId} not found.");
              

            }

            bool isDoubleBooked = reservations.Any(n=>n.RoomId==roomNumber&&
                                                     n.Status!= ReservationStatus.Cancelled && 
                                                     n.Status!= ReservationStatus.CheckedOut&&
                                                     n.CheckOutTime > checkInTime&&
                                                     n.CheckInTime < checkOutTime);

            if (isDoubleBooked)
            {
                throw new InvalidOperationException($"Room {roomNumber} is already booked for the selected date range.");
            }
            Reservation reservation = new Reservation(id, checkInTime, checkOutTime, room, guest);
          

            reservations.Add(reservation);
          
          

        }   


        public List<Reservation> GetReservations()
        {
            return reservations;
        }

        public Reservation? GetReservationById(int id)
        {
            return reservations.Find(r => r.Id == id);
        }
        public List<Reservation> GetReservationByGuestId(int guestId)
        {

            return reservations.FindAll(r => r.Guest.Id == guestId);
        }



    }
}
