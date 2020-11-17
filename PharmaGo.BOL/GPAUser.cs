
using Microsoft.AspNetCore.Identity;
/// <summary>
/// Application User Class 
/// </summary>
namespace PharmaGo.BOL
{
    public class GPAUser:IdentityUser
    {
        public long? PharmaId { get; set; }
       // public Pharmacy Pharmacy { get; set; }
    }
}
