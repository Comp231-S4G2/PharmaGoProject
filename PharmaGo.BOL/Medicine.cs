#region Header
//POCO class of medicine is created here
#endregion

namespace PharmaGo.BOL
{
    public class Medicine
    {
        public long MedId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
