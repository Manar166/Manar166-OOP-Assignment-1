using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem.Models
{
    public class Guest
    {
        public int Id { get; }
        public  string  FullName { get; }
        public string PhoneNumber { get; }

        private readonly List<Reservation> _reservations = new List<Reservation>();

        public Guest(int id, string fullName, string phoneNumber)
        {
            if (String.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be null or empty.");
            }
            if (String.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentException("Phone number cannot be null or empty.");
            }
            if(id<0)
                            {
                throw new ArgumentException("Id cannot be negative.");
            }
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public IReadOnlyList<Reservation> Reservations { get {return _reservations.AsReadOnly(); } }



    }
}
