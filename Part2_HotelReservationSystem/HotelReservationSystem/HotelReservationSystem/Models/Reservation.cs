using HotelReservationSystem.NewFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem.Models
{
    public class Reservation
    {
        public int Id { get; }
        public DateTime CheckInTime { get; }
        public DateTime CheckOutTime { get; }

        public Room Room { get; set; }
        public Guest Guest { get; set; }

        public ReservationStatus Status { get; private set; }



        public Reservation(int Id, DateTime checkInTime, DateTime checkOutTime, Room room, Guest guest)

        {
            if(checkInTime >= checkOutTime)
            {
                throw new ArgumentException("Check-in time must be before check-out time.");
               
            }
            if (room.IsUnderMaintenance)
            {
                throw new InvalidOperationException("Room is not available for reservation.");
            }

           
            else
            {
                this.Id = Id;
                this.CheckInTime = checkInTime;
                this.CheckOutTime = checkOutTime;
                this.Room = room;
               
                this.Status = ReservationStatus.Pending;   
            }

           




        }


        public void Confirm()
        {
            if (!(Status == ReservationStatus.Pending))
            {
                throw new InvalidOperationException("Cannot check in. Reservation is not pending.");
                
            }
            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if (!(Status == ReservationStatus.Confirmed))
            {
                throw new InvalidOperationException("Cannot check in. Reservation is not confirmed.");

            }
            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (!(Status == ReservationStatus.CheckedIn))
            {
                throw new InvalidOperationException("Cannot check out. Reservation is not checked in.");

            }
            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if(!(Status == ReservationStatus.Pending || Status == ReservationStatus.Confirmed))
            {
                throw new InvalidOperationException("Cannot cancel. Reservation is already checked in or checked out.");
            }
            Status = ReservationStatus.Cancelled;
        }








    }
}
