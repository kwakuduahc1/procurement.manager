using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProcurementManager.Model
{
    public class Items
    {
        [Key]
        public short  ItemsID { get; set; }

        [Required]
        [StringLength(100)]
        public string Item { get; set; }

        [Required]
        [StringLength(5,MinimumLength =3)]
        public string ShortName { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
