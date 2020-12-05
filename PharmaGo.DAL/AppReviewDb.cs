using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL
{
    /// <summary>
    /// App review interface for DI
    /// </summary>
    public interface IAppReviewDb
    {
        IEnumerable<AppReview> GetAppReviews();
        bool AddReview(AppReview review);
    }

    /// <summary>
    /// IAppReviewDb BAse Type 
    /// </summary>
    public class AppReviewDb : IAppReviewDb
    {
        PGADbContext dbContext;
        public AppReviewDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        /// <summary>
        /// Add review to db
        /// </summary>
        /// <param name="review"></param>
        /// <returns>add review to db operation result</returns>
        public bool AddReview(AppReview review)
        {
            try
            {
                dbContext.AppReviews.Add(review);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Return all review
        /// </summary>
        /// <returns>all reviews</returns>
        public IEnumerable<AppReview> GetAppReviews()
        {
            return dbContext.AppReviews;
        }
    }
}
