using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementManagerUltimate.Model
{
    public class Contracts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractsID { get; set; }

        [StringLength(30, MinimumLength = 10)]
        public string Reference { get; set; }

        [Required]
        public short ItemsID { get; set; }

        [Required]
        public short SourcesID { get; set; }

        [StringLength(150, MinimumLength = 5)]
        [Required]
        public string Subject { get; set; }

        [Required]
        public short MethodsID { get; set; }

        [Required]
        public short SuppliersID { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        public double Quantity { get; set; }

        [DefaultValue(false)]
        public bool IsFlexible { get; set; }

        [DefaultValue(false)]
        public bool IsApproved { get; set; }

        [Required]
        public DateTime DateSigned { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        [DefaultValue(false)]
        public bool IsMinor { get; set; }

        [Required]
        public DateTime ExpectedDate { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateCompleted { get; set; }

        [StringLength(30, MinimumLength =5)]
        public string Receipt { get; set; }

        //[Timestamp, ConcurrencyCheck]
        //public byte[] Concurrency { get; set; }

        public virtual ICollection<ContractParameters> ContractParameters { get; set; }

        public virtual Methods Methods { get; set; }

        public virtual Items Items { get; set; }

        public virtual Sources Sources { get; set; }

        public virtual Suppliers Suppliers { get; set; }
    }
}
