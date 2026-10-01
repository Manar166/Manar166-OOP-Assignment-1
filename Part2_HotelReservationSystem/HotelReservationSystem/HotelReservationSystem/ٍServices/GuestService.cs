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
        GuestRepository guestRepository = new GuestRepository();
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

        public string GetGuestReservations(int id)
        {
            Console.WriteLine("Enter Guest ID");
            bool IsIdParsed = int.TryParse(Console.ReadLine(), out int GuestId);
            if (!IsIdParsed)
            {
                Console.WriteLine("Please Enter Vaild ID");
                return string.Empty;
            }
            var guest = guestRepository.GetGuestById(GuestId);
            if (guest is null)
            {
                Console.WriteLine("Guest not found.");
                return string.Empty;
            }
            if (guest.Reservations.Count == 0)
            {
                return $"No reservations found for guest {guest.FullName}.";
            }
            StringBuilder reservations = new StringBuilder();

            foreach (var item in guest.Reservations)
            {

                reservations.AppendLine($"Id={item.Id}## Check IN Date={item.CheckInTime},##Check_out_Date={item.CheckOutTime} ## Room Number={item.Room?.Number}## status={item.Status.ToString()}");

            }

            return reservations.ToString();


        }
    }
}
