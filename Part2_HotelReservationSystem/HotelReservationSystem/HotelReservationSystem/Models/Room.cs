using HotelReservationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem.Models
{
    public class Room
    {
        public Room(int number, string type, decimal nightlyRate, bool isUnderMaintenance)
        {
            if(nightlyRate <= 0)
            {
                throw new ArgumentException("Nightly rate cannot be zero or negative.");
            }
            Number = number;
            Type = type;
            NightlyRate = nightlyRate;
            IsUnderMaintenance = isUnderMaintenance;
            IsOccupied = true;
        }

        public int Number { get; init; }
        public string Type { get; }
        public decimal NightlyRate { get; private set; }
        public bool IsUnderMaintenance { get; private set; }
        public bool IsOccupied { get; private set; }


        private void UpdateNightlyRate(decimal newRate)
        {
            if (newRate <= 0)
            {
                throw new ArgumentException("Nightly rate cannot be zero or negative.");
            }
            NightlyRate = newRate;  
        }


    }
}
