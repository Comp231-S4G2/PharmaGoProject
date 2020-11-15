/// <summary>
/// Application User Class 
/// </summary>

namespace PharmaGo.BOL
{
    public class GPAUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public long? PharmaId { get; set; }
    }
}
