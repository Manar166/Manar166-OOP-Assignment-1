using HotelReservationSystem.Models;
using HotelReservationSystem.Reposatories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem._ٍServices
{
    public class ReservationService
    {
        ReservationRepository reservationRepository=Program.reservationRepository;
        RoomRepository roomRepository = Program.roomRepository;
        GuestRepository guestRepository = Program.guestRepository;

        //public ReservationService()
        //{
        //    reservationRepository = new ReservationRepository(new RoomRepository(), new GuestRepository());
        //}

        public void CreateReservation()
        {
            Console.WriteLine("Enter Reservation ID:");
            bool isValidId = int.TryParse(Console.ReadLine(), out int id);
            if (!isValidId)
            {
                Console.WriteLine("Invalid reservation ID. Please enter a valid integer.");
                return;
            }
            Console.WriteLine("Enter Check-in Time (yyyy-MM-dd HH:mm):");
            bool isValidCheckIn = DateTime.TryParse(Console.ReadLine(), out DateTime CheckInTime);
            if (!isValidCheckIn)
            {
                Console.WriteLine("Invalid check-in time. Please enter a valid date and time.");
                return;
            }
            Console.WriteLine("Enter Check-out Time (yyyy-MM-dd HH:mm):");
            bool isValidCheckOut = DateTime.TryParse(Console.ReadLine(), out DateTime CheckOutTime);
            if (!isValidCheckOut)
            {
                Console.WriteLine("Invalid check-out time. Please enter a valid date and time.");
                return;
            }

            Console.WriteLine("Enter Room Number:");
            bool isValidRoomNumber = int.TryParse(Console.ReadLine(), out int roomNumber);
            if (!isValidRoomNumber)
            {
                Console.WriteLine("Invalid room number. Please enter a valid integer.");
                return;
            }

            Console.WriteLine("Enter Guest ID:");
            bool isValidGuestId = int.TryParse(Console.ReadLine(), out int guestId);
            if (!isValidGuestId)
            {
                Console.WriteLine("Invalid guest ID. Please enter a valid integer.");
                return;
            }

            try
            {

                reservationRepository.AddReservation(id, CheckInTime, CheckOutTime, roomNumber, guestId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating reservation: {ex.Message}");



            }
        }

        public void DisplayAllReservations()
        {
            var reservations = reservationRepository.GetReservations();
            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations found.");
                return;
            }
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Reservation ID: {reservation.Id}," +
                    $" Guest: {reservation.Guest?.FullName}, " +
                    $"\nRoom: {reservation.Room?.Number}, " +
                    $"\n Check-in: {reservation.CheckInTime}," +
                    $" \n Check-out: {reservation.CheckOutTime}, Status: {reservation.Status} total cost: {reservation.TotalCost}");
            }
        }

        public void FindReservationById()
        {
            Console.WriteLine("Enter Reservation ID to search:");
            bool isValidId = int.TryParse(Console.ReadLine(), out int id);
            if (!isValidId)
            {
                Console.WriteLine("Invalid reservation ID. Please enter a valid integer.");
                return;
            }
            Reservation? reservation = reservationRepository.GetReservationById(id);
            if (reservation == null)
            {
                Console.WriteLine($"Reservation with ID {id} not found.");
                return;
            }
            Console.WriteLine($"Reservation ID: {reservation.Id}, " +
                $"Guest: {reservation.Guest?.FullName}, Room: {reservation.Room?.Number}," +
                $" Check-in: {reservation.CheckInTime}, Check-out: {reservation.CheckOutTime}," +
                $" Status: {reservation.Status} total cost: {reservation.TotalCost}");
        }   

        public void FindReservationByGuestId()
        {
            Console.WriteLine("Enter Guest ID to search:");
            bool isValidId = int.TryParse(Console.ReadLine(), out int id);
            if (!isValidId)
            {
                Console.WriteLine("Invalid Guest ID. Please enter a valid integer.");
                return;
            }
            List<Reservation> reservations = reservationRepository.GetReservationByGuestId(id).ToList();
            if (reservations.Count==0)
            {
                Console.WriteLine($"Reservation for guest with ID {id} not found.");
                return;
            }
            
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"Reservation ID: {reservation.Id}, " +
                    $"Guest: {reservation.Guest?.FullName}, " +
                    $"\nRoom: {reservation.Room?.Number}, " +
                    $"\n Check-in: {reservation.CheckInTime}," +
                    $" \n Check-out: {reservation.CheckOutTime}, " +
                    $"Status: {reservation.Status} total cost: {reservation.TotalCost}");
            }
        }

    }
}
