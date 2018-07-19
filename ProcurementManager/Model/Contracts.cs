using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProcurementManager.Model
{
    public class Contracts
    {
        [Key]
        public string ContractsID { get; set; }

        [StringLength(150, MinimumLength = 20)]
        [Required]
        public string Subject { get; set; }

        [Required]
        public short MethodsID { get; set; }

        [StringLength(200, MinimumLength = 10)]
        [Required]
        public string Contractor { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        [DefaultValue(false)]
        public bool IsFlexible { get; set; }

        [DefaultValue(false)]
        public bool IsApproved { get; set; }

        [Required]
        public DateTime DateSigned { get; set; }

        [DefaultValue(false)]
        public bool IsExecuted { get; set; }

        [Required]
        public DateTime ExpectedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<ContractParameters> ContractParameters { get; set; }

        public virtual Methods Methods { get; set; }
    }
}
