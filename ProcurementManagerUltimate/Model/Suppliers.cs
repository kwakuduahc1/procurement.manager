using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementManagerUltimate.Model
{
    public class Suppliers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short SupplierID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Supplier { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string TIN { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
    }
}
