using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL.Tests
{
    [TestClass()]
    public class AppointmentsDbTests
    {
        /// <summary>
        /// Test if objected is created successfully
        /// </summary>
        [TestMethod]
        public void GetAppointmentsTest_Assert_If_DbSet_is_Not_Null()
        {
            var mockSet = new Mock<DbSet<Appointment>>();

            var mockContext = new Mock<PGADbContext>();
            mockContext.Setup(m => m.Appointments).Returns(mockSet.Object);
            var service = new AppointmentsDb(mockContext.Object);
            Assert.IsNotNull(service);
        }

        /// <summary>
        /// Inserts Appointment in DB and checks if its suceeded
        /// </summary>
        [TestMethod()]
        public void CreateAppointmentTest_Check_Insertion_Result_True()
        {
            //create object of Appointment
            var a = new Appointment()
            {
                TimeSlot = new TimeSlot(),
                TimeSlotId = 1,
                Customer = new GPAUser(),
                CustomerId = "DXS DSER HGS",
                ApptTime = new DateTime(),
                StoreId = 1
            };
            //mocking the DAL layer
            var mockSet = new Mock<DbSet<Appointment>>();
            var mockContext = new Mock<PGADbContext>();
            mockContext.Setup(m => m.Appointments).Returns(mockSet.Object);
            var service = new AppointmentsDb(mockContext.Object);
            //Insert appointment
            var result= service.CreateAppointment(a);
            //check statement
            Assert.IsTrue(result);
        }


    }
}