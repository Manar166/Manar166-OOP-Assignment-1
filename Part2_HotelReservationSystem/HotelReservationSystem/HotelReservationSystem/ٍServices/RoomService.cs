using HotelReservationSystem.Enums;
using HotelReservationSystem.Reposatories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem._ٍServices
{
    public class RoomService
    {
        RoomRepository roomRepository;
        public RoomService(RoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public void UpdateRoomRate()
        {
            Console.WriteLine("Enter Room Number to update rate:");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int number);
            if (!isValidNumber)
            {
                Console.WriteLine("Invalid room number. Please enter a valid integer.");
                return;
            }
            Console.WriteLine("Enter New Nightly Rate:");
            bool isValidRate = decimal.TryParse(Console.ReadLine(), out decimal newRate);
            if (!isValidRate)
            {
                Console.WriteLine("Invalid nightly rate. Please enter a valid decimal number.");
                return;
            }
            try
            {
                roomRepository.UpdateRoomRate(number, newRate);
                Console.WriteLine($"Room {number} nightly rate updated to {newRate}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating room rate: {ex.Message}");
            }
        }
        public void AddRoom()
        {
            Console.WriteLine("Enter Room Number:");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int number);
            if (!isValidNumber)
            {
                Console.WriteLine("Invalid room number. Please enter a valid integer.");
                return;
            }

            Console.WriteLine("Choose Room Type:");
            Console.WriteLine("1. Single");
            Console.WriteLine("2. Double");
            Console.WriteLine("3. Suite");
            Console.Write("Enter your choice (1-3): ");

            string? TypeInput = Console.ReadLine();
            RoomType type;
            switch (TypeInput)
            {
                case "1":
                    type = RoomType.Single;
                    break;
                case "2":
                    type = RoomType.Double;
                    break;
                case "3":
                    type = RoomType.Suite;
                    break;

                default:
                    Console.WriteLine("Invalid room type selection. Please enter a number between 1 and 3.");
                    return;
            }


            Console.WriteLine("Enter Nightly Rate:");
            bool isValidRate = decimal.TryParse(Console.ReadLine(), out decimal nightlyRate);

            if (!isValidRate)
            {
                Console.WriteLine("Invalid nightly rate. Please enter a valid decimal number.");
                return;
            }
            try
            {
                roomRepository.AddRoom(number, type, nightlyRate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding room: {ex.Message}");
            }
        }

        public void DisplayAllRooms()
        {
            var rooms = roomRepository.GetAllRooms();
            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms available.");
                return;
            }
            Console.WriteLine("Available Rooms:");
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room Number: {room.Number}, Type: {room.Type}, Nightly Rate: {room.NightlyRate}");
            }
        }

        public void FindRoomByNumber()
        {
            Console.WriteLine("Enter Room Number to search:");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int number);
            if (!isValidNumber)
            {
                Console.WriteLine("Invalid room number. Please enter a valid integer.");
                return;
            }
            var room = roomRepository.FindRoomByNumber(number);
            if (room == null)
            {
                Console.WriteLine($"Room with number {number} not found.");
                return;
            }
            Console.WriteLine($"Room Number: {room.Number}, Type: {room.Type}, Nightly Rate: {room.NightlyRate}");
        }


        public void StartRoomMaintenance()
        {
            Console.WriteLine("Enter Room Number to start maintenance:");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int number);
            if (!isValidNumber)
            {
                Console.WriteLine("Invalid room number. Please enter a valid integer.");
                return;
            }
            try
            {
                roomRepository.StartRoomMaintenance(number);
                Console.WriteLine($"Room {number} is now under maintenance.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting maintenance: {ex.Message}");
            }
        }

        public void EndRoomMaintenance()
        {
            Console.WriteLine("Enter Room Number to end maintenance:");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int number);
            if (!isValidNumber)
            {
                Console.WriteLine("Invalid room number. Please enter a valid integer.");
                return;
            }
            try
            {
                roomRepository.EndRoomMaintenance(number);
                Console.WriteLine($"Room {number} is now available.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error ending maintenance: {ex.Message}");
            }
        }


    }
}
