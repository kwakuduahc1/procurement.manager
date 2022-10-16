using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementManagerUltimate.Model
{
    public class Timelines
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimelinesID { get; set; }

        [Required]
        public short ContractParametersID { get; set; }

        [Required]
        public DateTime DateDone { get; set; }

        [StringLength(50, MinimumLength = 10)]
        public string Comments { get; set; }

        //[Timestamp]
        //public byte[] Concurrency { get; set; }

        public virtual ContractParameters ContractParameters { get; set; }
    }
}
