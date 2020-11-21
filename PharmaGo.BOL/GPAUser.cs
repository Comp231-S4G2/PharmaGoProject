
using Microsoft.AspNetCore.Identity;
/// <summary>
/// Application User Class 
/// </summary>
namespace PharmaGo.BOL
{
    public class GPAUser:IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long? PharmaId { get; set; }
       // public Pharmacy Pharmacy { get; set; }
    }
}
