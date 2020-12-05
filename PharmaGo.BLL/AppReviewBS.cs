#region Namespaces

using PharmaGo.BOL;
using PharmaGo.DAL;
using System.Collections.Generic;

#endregion

namespace PharmaGo.BLL
{
    /// <summary>
    /// App Review Interface for DI
    /// </summary>
    public interface IAppReviewBS
    {
        IEnumerable<AppReview> GetAppReviews();
        bool AddReview(AppReview review);
    }

    /// <summary>
    /// App Review Class for type mapping 
    /// </summary>
    public class AppReviewBS : IAppReviewBS
    {
        IAppReviewDb appReviewBS;
        /// <summary>
        /// Db Context LAyer DI injected
        /// </summary>
        /// <param name="_appReviewBS"></param>
        public AppReviewBS(IAppReviewDb _appReviewBS)
        {
            appReviewBS = _appReviewBS;
        }

        /// <summary>
        /// Add Review
        /// </summary>
        /// <param name="review"></param>
        /// <returns>Add Review Operation</returns>
        public bool AddReview(AppReview review)
        {
            return appReviewBS.AddReview(review);
        }

        /// <summary>
        /// Get All reviews
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppReview> GetAppReviews()
        {
            return appReviewBS.GetAppReviews();
        }
    }
}
