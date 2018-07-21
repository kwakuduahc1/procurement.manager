using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProcurementManager.Model
{
    public class ContractParameters
    {
        [Key]
        public short ContractParametersID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        public string ContractParameter { get; set; }

        [Required]
        public string ContractsID { get; set; }

        [Required]
        [Range(1, 100)]
        public byte Percentage { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Amount { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        public DateTime ExpectedDate { get; set; }

        public DateTime DateCompleted { get; set; }

        [Timestamp]
        public byte[] Concurrency { get; set; }

        public virtual Contracts Contracts { get; set; }
    }
}
