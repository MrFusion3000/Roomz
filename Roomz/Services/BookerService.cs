using Roomz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomz.Services
{
    public class BookerService
    {
        private readonly ApplicationDbContext _db;
        public BookerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Booker GetBooker(int bookerId)
        {
            Booker obj = new Booker();
            return _db.Bookers.FirstOrDefault(u => u.Id == bookerId);
        }

        public List<Booker> GetBookers()
        {
            return _db.Bookers.ToList();
        }

        public bool CreateBooker(Booker objBooker)
        {
            _db.Bookers.Add(objBooker);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateBooker(Booker objBooker)
        {
            var ExistingBooker = _db.Bookers.FirstOrDefault(u => u.Id == objBooker.Id);
            if (ExistingBooker != null)
            {
                ExistingBooker.FirstName = objBooker.FirstName;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool DeleteBooker(Booker objBooker)
        {
            var ExistingBooker = _db.Bookers.FirstOrDefault(u => u.Id == objBooker.Id);
            if (ExistingBooker != null)
            {
                _db.Bookers.Remove(ExistingBooker);
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
