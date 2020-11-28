using Microsoft.EntityFrameworkCore;
using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaGo.DAL
{
    public interface ITimeSlotsDb
    {
        IEnumerable<TimeSlot> GetTimeSlots();
        IEnumerable<TimeSlot> GetTimeSlotsByStore(long storeId);
        IEnumerable<TimeSlot> GetTimeSlotsByStoreAndDate(long storeId,DateTime date);
        TimeSlot GetTimeSlot(long id);
        bool AddTimeSlot(TimeSlot timeSlot);
        bool DeleteTimeSlot(long id);
        bool UpdateTimeSlot(TimeSlot timeSlot);
    }
    public class TimeSlotsDb : ITimeSlotsDb
    {
        PGADbContext dbContext;
        public TimeSlotsDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool AddTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                dbContext.TimeSlots.Add(timeSlot);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool DeleteTimeSlot(long id)
        {
            try
            {
                var timeSlot = dbContext.TimeSlots.Find(id);
                dbContext.TimeSlots.Remove(timeSlot);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TimeSlot GetTimeSlot(long id)
        {
            var timeSlot = dbContext.TimeSlots.Find(id);
            return timeSlot;
        }

        public IEnumerable<TimeSlot> GetTimeSlots()
        {
            return dbContext.TimeSlots;
        }

        public IEnumerable<TimeSlot> GetTimeSlotsByStore(long storeId)
        {
            return dbContext.TimeSlots.Where(x=>x.PharmacyId==storeId);
        }

        public IEnumerable<TimeSlot> GetTimeSlotsByStoreAndDate(long storeId, DateTime date)
        {
            return dbContext.TimeSlots.Where(x => x.PharmacyId == storeId&&x.Date.Equals(date))
                .Include(x=>x.Appointments);
        }

        public bool UpdateTimeSlot(TimeSlot timeSlot)
        {
            try
            {
                dbContext.Update<TimeSlot>(timeSlot);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
