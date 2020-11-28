using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BLL
{
    public interface ITimeSlotsBS
    {
        IEnumerable<TimeSlot> GetTimeSlots();
        IEnumerable<TimeSlot> GetTimeSlotsByStore(long storeId);
        IEnumerable<TimeSlot> GetTimeSlotsByStoreAndDate(long storeId, DateTime date);
        TimeSlot GetTimeSlot(long id);
        bool AddTimeSlot(TimeSlot timeSlot);
        bool DeleteTimeSlot(long id);
        bool UpdateTimeSlot(TimeSlot timeSlot);
    }
    public class TimeSlotsBS : ITimeSlotsBS
    {
        ITimeSlotsDb ITimeSlotsBS;
        public TimeSlotsBS(ITimeSlotsDb _ITimeSlotsBS)
        {
            ITimeSlotsBS = _ITimeSlotsBS;
        }
        public bool AddTimeSlot(TimeSlot timeSlot)
        {
            return ITimeSlotsBS.AddTimeSlot(timeSlot);
        }

        public bool DeleteTimeSlot(long id)
        {
            return ITimeSlotsBS.DeleteTimeSlot(id);
        }

        public TimeSlot GetTimeSlot(long id)
        {
            return ITimeSlotsBS.GetTimeSlot(id);
        }

        public IEnumerable<TimeSlot> GetTimeSlots()
        {
            return ITimeSlotsBS.GetTimeSlots();
        }

        public IEnumerable<TimeSlot> GetTimeSlotsByStore(long storeId)
        {
            return ITimeSlotsBS.GetTimeSlotsByStore(storeId);
        }

        public IEnumerable<TimeSlot> GetTimeSlotsByStoreAndDate(long storeId, DateTime date)
        {
            return ITimeSlotsBS.GetTimeSlotsByStoreAndDate(storeId,date);
        }

        public bool UpdateTimeSlot(TimeSlot timeSlot)
        {
            return ITimeSlotsBS.UpdateTimeSlot(timeSlot);
        }
    }
}
