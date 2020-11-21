using PharmaGo.BOL;
using PharmaGo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BLL
{
    public interface IAppReviewBS
    {
        IEnumerable<AppReview> GetAppReviews();
        bool AddReview(AppReview review);
    }
    public class AppReviewBS : IAppReviewBS
    {
        IAppReviewDb appReviewBS;
        public AppReviewBS(IAppReviewDb _appReviewBS)
        {
            appReviewBS = _appReviewBS;
        }
        public bool AddReview(AppReview review)
        {
            return appReviewBS.AddReview(review);
        }

        public IEnumerable<AppReview> GetAppReviews()
        {
            return appReviewBS.GetAppReviews();
        }
    }
}
