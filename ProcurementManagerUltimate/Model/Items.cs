using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementManagerUltimate.Model
{
    public class Items
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ItemsID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Item { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 1)]
        [DefaultValue("n/a")]
        public string Unit { get; set; }

        //[Timestamp, ConcurrencyCheck]
        //public byte[] Concurrency { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
