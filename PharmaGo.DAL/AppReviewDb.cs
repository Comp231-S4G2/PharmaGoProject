using PharmaGo.BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.DAL
{
    public interface IAppReviewDb
    {
        IEnumerable<AppReview> GetAppReviews();
        bool AddReview(AppReview review);
    }
    public class AppReviewDb : IAppReviewDb
    {
        PGADbContext dbContext;
        public AppReviewDb(PGADbContext _dbContext)
        {
            dbContext = _dbContext;
        }
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

        public IEnumerable<AppReview> GetAppReviews()
        {
            return dbContext.AppReviews;
        }
    }
}
