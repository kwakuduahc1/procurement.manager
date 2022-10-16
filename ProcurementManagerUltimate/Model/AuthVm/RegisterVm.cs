using System.ComponentModel.DataAnnotations;

namespace ProcurementManagerUltimate.Model.AuthVm;

public class RegisterVm
{
    [Required]
    [StringLength(20)]
    public string UserName { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 6)]
    public string Password { get; set; }

    [Required]
    [StringLength(15, MinimumLength = 6)]
    public string ConfirmPassword { get; set; }

    [Required]
    public bool RememberMe { get; set; }

    [Required]
    public string Role { get; set; }

    internal ApplicationUser Transform => new() { UserName = UserName, Password = Password };
}
