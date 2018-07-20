using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProcurementManager.Model
{
    public class Methods
    {
        [Key]
        public short MethodsID { get; set; }

        [Required]
        [StringLength(50)]
        public string Method { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }

    }
}
