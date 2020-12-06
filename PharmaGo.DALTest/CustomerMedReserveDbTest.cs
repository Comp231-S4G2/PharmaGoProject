using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PharmaGo.BOL;
using PharmaGo.DAL;

namespace PharmaGo.DALTest
{
    /// <summary>
    /// class is responsible to test the CustomerMedReserveDb Layer
    /// </summary>
    [TestClass]
    public class CustomerMedReserveDbTest
    {
        [TestMethod]
        public void GetCustomerMedReserves_Assert_If_element_is_Not_Null()
        {
            var mockSet = new Mock<DbSet<CustomerMedReserve>>();

            var mockContext = new Mock<PGADbContext>();
            mockContext.Setup(m => m.CustomerMedReserves).Returns(mockSet.Object);
            var service = new CustomerMedReserveDb(mockContext.Object);
            Assert.IsNotNull(service);
        }
    }
}
