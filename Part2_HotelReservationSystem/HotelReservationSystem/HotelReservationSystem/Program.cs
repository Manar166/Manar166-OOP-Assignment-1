using HotelReservationSystem._ٍServices;

namespace HotelReservationSystem
{
    internal class Program
    {
       static GuestService guestService = new GuestService();
        static void Main(string[] args)
        {
            guestService.AddGuest();
        }
    }
}
