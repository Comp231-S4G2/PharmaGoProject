#region Header
//POCO class of medicine is created here
#endregion

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaGo.BOL
{
    /// <summary>
    /// Medicine POCO
    /// </summary>
    
    [Table("Medicines")]
    public class Medicine
    {
        [Key]
        public long MedicineId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
