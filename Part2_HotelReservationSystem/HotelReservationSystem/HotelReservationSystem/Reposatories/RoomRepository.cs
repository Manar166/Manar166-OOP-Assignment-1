using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem.Reposatories
{
    public class RoomRepository
    {
        public static List<Room> rooms = Program.rooms;
        //public void AddRoom(int number, RoomType type, decimal price)
        //{
        //    if(rooms.Exists(r => r.Number == number))
        //    {
        //        throw new InvalidOperationException($"Room with number {number} already exists.");
        //    }
        //    try
        //    {
        //        Room room = new Room(number, type, price);
        //        rooms.Add(room);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine( $"Error adding room: {ex.Message}" );
        //        throw ;
        //    }
        //}

        public void AddRoom(int number, RoomType type, decimal price)
        {
            if (rooms.Exists(r => r.Number == number))
            {
                throw new InvalidOperationException($"Room with number {number} already exists.");
            }

            Room room = new Room(number, type, price);  
            rooms.Add(room);
        }
        public List<Room> GetAllRooms()
        {
            return rooms;
        }

        public Room FindRoomByNumber(int number)
        
        { 
            return rooms.Find(r => r.Number == number);
        }

        public void UpdateRoomRate(int number, decimal newRate)
        {
            Room room = FindRoomByNumber(number);
            if (room == null)
            {
                throw new InvalidOperationException($"Room with number {number} not found.");
            }
            room.UpdateNightlyRate(newRate);
        }

        public void StartRoomMaintenance(int number)
        {
            Room room = FindRoomByNumber(number);
            if (room == null)
            {
                throw new InvalidOperationException($"Room with number {number} not found.");
            }
            if(room.IsUnderMaintenance)
            {
                throw new InvalidOperationException($"Room with number {number} is already under maintenance.");
            }
            room.StartMaintenance();
        }

        public void EndRoomMaintenance(int number)
        {
            Room room = FindRoomByNumber(number);
            if (room == null)
            {
                throw new InvalidOperationException($"Room with number {number} not found.");
            }
            if (!room.IsUnderMaintenance)
            {
                throw new InvalidOperationException($"Room with number {number} is not under maintenance.");
            }
            room.EndMaintenance();
        }
    }
}
