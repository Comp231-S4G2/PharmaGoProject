using Microsoft.EntityFrameworkCore;
using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaGo.DAL
{
    public interface IAppointmentsDb
    {
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointmentsByStore(long storeId);
        Appointment GetAppointment(long appointmentId);
        bool CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment);
        bool DeleteAppointment(long appointmentId);
    }
    public class AppointmentsDb : IAppointmentsDb
    {
        PGADbContext dbContext;
        public AppointmentsDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool CreateAppointment(Appointment appointment)
        {
            try
            {
                dbContext.Appointments.Add(appointment);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAppointment(long appointmentId)
        {
            try
            {
                var appointment = dbContext.Appointments.Find(appointmentId);
                dbContext.Appointments.Remove(appointment);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Appointment GetAppointment(long appointmentId)
        {
            var appointment = dbContext.Appointments.Find(appointmentId);
            return appointment;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return dbContext.Appointments.Include(x=>x.TimeSlot.Pharmacy);
        }

        public IEnumerable<Appointment> GetAppointmentsByStore(long storeId)
        {
            return dbContext.Appointments.Where(x => x.StoreId == storeId);
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            try
            {
                dbContext.Update<Appointment>(appointment);
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
