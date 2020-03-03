using Roomz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Roomz.Services
{
    public class RoomService
    {
        //Connect to Database
        private readonly ApplicationDbContext _db;
        public RoomService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get Room item from database
        public Room GetRoom(int roomId)
        {
            Room obj = new Room();
            return _db.Rooms.FirstOrDefault(u => u.Id == roomId);
        }

        // Get Room items list from database
        public List<Room> GetRooms()
        {
            return _db.Rooms.ToList();
        }

        // Get Category items list from database
        //public List<User> GetCategoryList()
        //{
        //    return _db.Categories.ToList();
        //}

        // Create New Room
        public bool CreateRoom(Room objRoom)
        {
            _db.Rooms.Add(objRoom);
            _db.SaveChanges();
            return true;
        }

        // Update Room
        public bool UpdateRoom(Room objRoom)
        {
            var ExistingRoom = _db.Rooms.FirstOrDefault(u => u.Id == objRoom.Id);
            if (ExistingRoom != null)
            {
                //if (objRoom.Image == null)
                //{
                //    objRoom.Image = ExistingRoom.Image;
                //}
                _db.Rooms.Update(objRoom);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteRoom(Room objRoom)
        {
            var ExistingRoom = _db.Rooms.FirstOrDefault(u => u.Id == objRoom.Id);
            if (ExistingRoom != null)
            {
                _db.Rooms.Remove(ExistingRoom);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;

        }
    }
}
