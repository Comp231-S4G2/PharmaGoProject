using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PharmaGo.BLL
{
    public interface IAppointmentBS
    {
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointmentsByStore(long storeId);
        IEnumerable<Appointment> GetAppointmentsByPatient(string patientId);
        Appointment GetAppointment(long appointmentId);
        bool CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment);
        bool DeleteAppointment(long appointmentId);
    }
    public class AppointmentsBS : IAppointmentBS
    {
        IAppointmentsDb AppointmentsDb;
        public AppointmentsBS(IAppointmentsDb _AppointmentsDb)
        {
            AppointmentsDb = _AppointmentsDb;
        }
        public bool CreateAppointment(Appointment appointment)
        {
            return AppointmentsDb.CreateAppointment(appointment);
        }

        public bool DeleteAppointment(long appointmentId)
        {
            return AppointmentsDb.DeleteAppointment(appointmentId);
        }

        public Appointment GetAppointment(long appointmentId)
        {
            return AppointmentsDb.GetAppointment(appointmentId);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return AppointmentsDb.GetAppointments();
        }

        public IEnumerable<Appointment> GetAppointmentsByPatient(string patientId)
        {
            return GetAppointments().Where(x=>x.CustomerId==patientId);
        }

        public IEnumerable<Appointment> GetAppointmentsByStore(long storeId)
        {
            return AppointmentsDb.GetAppointmentsByStore(storeId);
        }

        public bool UpdateAppointment(Appointment appointment)
        {
            return AppointmentsDb.UpdateAppointment(appointment);
        }
    }
}
