using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProcurementManagerUltimate.Model
{
    public class ContractParameters
    {
        [Key]
        public short ContractParametersID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Parameter { get; set; }

        [StringLength(30, MinimumLength = 10)]
        [Required]
        public string Reference { get; set; }

        [Required]
        [Range(1, 100)]
        public byte Percentage { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Amount { get; set; }

        [DefaultValue(0)]
        public byte IsCompleted { get; set; }

        public DateTime ExpectedDate { get; set; }

        public DateTime DateCompleted { get; set; }

        //[Timestamp, ConcurrencyCheck]
        //public byte[] Concurrency { get; set; }
    }
}
