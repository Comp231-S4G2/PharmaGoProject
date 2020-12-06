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
    public class AppReviewDbTests
    {
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