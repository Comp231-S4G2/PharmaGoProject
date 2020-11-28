using PharmaGo.BOL;
using System;
using System.Collections.Generic;
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
        public bool AddTimeSlot(TimeSlot timeSlot)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTimeSlot(long id)
        {
            throw new NotImplementedException();
        }

        public TimeSlot GetTimeSlot(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimeSlot> GetTimeSlots()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimeSlot> GetTimeSlotsByStore(long storeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TimeSlot> GetTimeSlotsByStoreAndDate(long storeId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTimeSlot(TimeSlot timeSlot)
        {
            throw new NotImplementedException();
        }
    }
}
