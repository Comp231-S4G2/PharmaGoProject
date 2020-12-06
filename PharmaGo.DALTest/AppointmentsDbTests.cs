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

        //[TestMethod()]
        //public void CreateAppointmentTest()
        //{
        //    Assert.Fail();
        //}
       
    }
}