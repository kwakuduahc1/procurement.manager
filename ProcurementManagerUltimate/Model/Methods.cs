using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementManagerUltimate.Model
{
    public class Methods
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short MethodsID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Method { get; set; }

        //[Timestamp]
        //public byte[] Concurrency { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }

    }
}
