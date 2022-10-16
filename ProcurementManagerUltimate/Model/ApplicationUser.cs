using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProcurementManagerUltimate.Model;

public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(50, MinimumLength = 5)]
    public override string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [StringLength(30, MinimumLength = 6)]
    [NotMapped]
    public string Password { get; set; }
}
