using System;
using System.Collections.Generic;
using System.Text;

namespace PharmaGo.BOL
{
    public class AppReview
    {
        public long Id { get; set; }
        public int FluShotServices { get; set; }
        public int ApplicationPerformance { get; set; }
        public int TechnicalAssistanceResponse { get; set; }
        public int OverallReview { get; set; }
        public string UserId { get; set; }
    }
}
