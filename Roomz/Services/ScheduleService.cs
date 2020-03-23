using Roomz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Roomz.Services
{
    public class ScheduleService
    {
        //Connect to Database
        private readonly ApplicationDbContext _db;

        public ScheduleService(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get Reservation items list from database
        public List<Schedule> GetSchedules()
        {
            return _db.Schedules.Include(u => u.Room).Include(x => x.Booker).OrderBy(c => c.AppointmentDateStart).ToList();
        }

        // Get Reservation items list from database based on RoomID
        public List<Schedule> GetSchedulesFromRoom(int roomId)
        {            
            return _db.Schedules.Include(u => u.Room).Include(x => x.Booker).OrderBy(c => c.AppointmentDateStart).Where(b => b.RoomId == roomId).ToList();
        }

        public Schedule GetCurrentSchedule(int roomId, DateTime AppStart)
        {
            var schedules = _db.Schedules.Include(u => u.Room).Include(x => x.Booker).OrderBy(c => c.AppointmentDateStart).Where(b => b.AppointmentDateStart < AppStart).Where(b => b.AppointmentDateEnd > AppStart).Where(b => b.AppointmentDateEnd > AppStart).Where(d => d.RoomId == roomId);
            var currentSchedule = schedules.FirstOrDefault();
            return currentSchedule;
        }

        public Schedule GetNextSchedule(int roomId, DateTime AppStart)
        {
            var schedules = _db.Schedules.Include(u => u.Room).Include(x => x.Booker).OrderBy(c => c.AppointmentDateStart).Where(b => b.AppointmentDateStart >= AppStart).Where(d => d.RoomId == roomId);
            var nextSchedule = schedules.FirstOrDefault();
            return nextSchedule;
        }

        //public Schedule GetFirstScheduleFromStart(int roomId, DateTime AppStart)
        //{
        //    var schedules = _db.Schedules.Include(u => u.Room).Include(x => x.Booker).OrderBy(c => c.AppointmentDateStart).Where(b => b.AppointmentDateStart < AppStart).Where( b => b.AppointmentDateEnd > AppStart).Where(d => d.RoomId == roomId);
        //    var firstSchedule = schedules.FirstOrDefault();
        //    return firstSchedule;
        //}

        // Confirm Reservation
        public bool ConfirmSchedule(Schedule objSchedule)
        {
            var ExistingSchedule = _db.Schedules.FirstOrDefault(x => x.Id == objSchedule.Id);
            if (ExistingSchedule != null)
            {
                ExistingSchedule.IsConfirmed = true;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        // Create New Reservation 
        public bool CreateSchedule(Schedule schedule)
        {
            //schedule.RoomId = schedule.Room.Id;
            //schedule.Room = null;
            _db.Schedules.Add(schedule);
            _db.SaveChanges();
            return true;
        }

        // Update Schedule
        public bool UpdateSchedule(Schedule objSchedule)
        {
            var ExistingSchedule = _db.Schedules.FirstOrDefault(x => x.Id == objSchedule.Id);
            if (ExistingSchedule != null)
            {                
                _db.Schedules.Update(objSchedule);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteSchedule(Schedule objSchedule)
        {
            var ExistingSchedule = _db.Schedules.FirstOrDefault(x => x.Id == objSchedule.Id);
            if (ExistingSchedule != null)
            {
                _db.Schedules.Remove(ExistingSchedule);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteSchedulesFromDate(DateTime objDateTime)
        {
            var result = _db.Schedules.Where(x => x.AppointmentDateEnd <= objDateTime).ToList();            
            if (result != null)
            {
                _db.Schedules.RemoveRange(result);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        // Get Room item from database based on RoomId
        public Room GetRoom(int roomId)
        {
            Room obj = new Room();
            return _db.Rooms.FirstOrDefault(u => u.Id == roomId);
        }

        // Get Rooms list from database
        public List<Room> GetRooms()
        {
            return _db.Rooms.ToList();
        }

    }
}
