using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManagerUltimate.Context;
using ProcurementManagerUltimate.Model;
using ProcurementManagerUltimate.Model.AuthVm;
using System.Security.Claims;

namespace ProcurementManagerUltimate.Controllers
{
    //[AutoValidateAntiforgeryToken]

    [Route("[controller]")]
    [ApiController]
    [EnableCors("bStudioApps")]
    // [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext db;
        private readonly AppFeatures appFeatures;
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, DbContextOptions<ApplicationDbContext> contextOptions, AppFeatures features)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            db = new ApplicationDbContext(contextOptions);
            appFeatures = features;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVm user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var _user = await _userManager.FindByNameAsync(user.UserName);
            if (_user == null)
                return Unauthorized(new { Message = "Invalid user name or password" });
            if (!await _userManager.CheckPasswordAsync(_user, user.Password))
                return Unauthorized();
            await _signInManager.SignInAsync(_user, false);
            var claims = await _userManager.GetClaimsAsync(_user);
            var token = new AuthHelper(claims, appFeatures).Key;
            return Ok(new { Token = token });
        }

        [HttpPost("Register")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register([FromBody] RegisterVm reg)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            ApplicationUser user = reg.Transform;
            var result = await _userManager.CreateAsync(user, user.Password);
            if (!result.Succeeded)
                return BadRequest(new { Message = result.Errors.First().Description });
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Name, user.UserName));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "User"));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, reg.Role));
            var _user = await _userManager.FindByIdAsync(user.Id);
            await _signInManager.SignInAsync(_user, true);
            await db.SaveChangesAsync();
            return Created("", new { user.UserName, user.PhoneNumber, user.Email });
        }

        [HttpPost]
        [Authorize]
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Accepted();
        }

    }
}