using System.Collections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManagerUltimate.Context;

namespace AdmissionPortal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("bStudioApps")]
    //[Authorize(Roles = "Developer, Administration, Principal")]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public RolesController(DbContextOptions<ApplicationDbContext> options) => db = new ApplicationDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List()
        {
            var rle = (User.IsInRole("Developer") || User.IsInRole("Principal"));
            var roles = await db.Roles.Select(x => new { x.Id, x.Name }).ToListAsync();
            return (User.IsInRole("Developer") | User.IsInRole("Principal"))? roles : roles.Where(x => x.Name != "Principal" && x.Name != "Developer").ToList();
        }
    }
}