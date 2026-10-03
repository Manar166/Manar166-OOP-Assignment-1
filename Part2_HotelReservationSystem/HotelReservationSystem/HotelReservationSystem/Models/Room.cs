using HotelReservationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem.Models
{
    public class Room
    {
        public Room(int number, RoomType type, decimal nightlyRate)
        {
            if(nightlyRate <= 0)
            {
                throw new ArgumentException("Nightly rate cannot be zero or negative.");
            }
            Number = number;
            Type = type;
            NightlyRate = nightlyRate;
            
          
        }

        public int Number { get; init; }
        public RoomType Type { get; }
        public decimal NightlyRate { get; private set; }
        public bool IsUnderMaintenance { get; private set; }
       


        public void UpdateNightlyRate(decimal newRate)
        {
            if (newRate <= 0)
            {
                throw new ArgumentException("Nightly rate cannot be zero or negative.");
            }
            NightlyRate = newRate;  
        }

        public void StartMaintenance()
        {
            IsUnderMaintenance = true;
        }

        public void EndMaintenance()
        {
            IsUnderMaintenance = false;
        }


    }
}
