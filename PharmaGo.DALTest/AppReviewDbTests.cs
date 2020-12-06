#region Namespaces

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PharmaGo.BOL;

#endregion

namespace PharmaGo.DAL.Tests
{
    /// <summary>
    /// class is responsible to test the GetAppReviewsDb Layer
    /// </summary>
    [TestClass()]
    public class AppReviewDbTests
    {
        /// <summary>
        /// Test if objected is created successfully
        /// </summary>
        [TestMethod]
        public void GetAppReviewsTest_Assert_If_element_is_Not_Null()
        {
            var mockSet = new Mock<DbSet<AppReview>>();

            var mockContext = new Mock<PGADbContext>();
            mockContext.Setup(m => m.AppReviews).Returns(mockSet.Object);
            var service = new AppReviewDb(mockContext.Object);
            Assert.IsNotNull(service);
        }

        /// <summary>
        /// Tests if GetAppReviews() is returning values
        /// </summary>
        [TestMethod()]
        public void GetAppReviewsTest()
        {
            var mockSet = new Mock<DbSet<AppReview>>();

            var mockContext = new Mock<PGADbContext>();
            mockContext.Setup(m => m.AppReviews).Returns(mockSet.Object);
            var service = new AppReviewDb(mockContext.Object);
            Assert.IsNotNull(service.GetAppReviews());
        }
    }
}