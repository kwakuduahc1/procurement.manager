using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementManagerUltimate.Model
{
    public class Sources
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short SourcesID { get; set; }

        [Required]
        [StringLength(50)]
        public string Source { get; set; }

        //[Timestamp]
        //public byte[] Concurrency { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
