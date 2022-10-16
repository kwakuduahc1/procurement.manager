using System.Collections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManagerUltimate.Context;

namespace ProcurementManagerUltimate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("bStudioApps")]
    //[Authorize(Roles = "Developer, Exams, Principal")]
    public class MethodsController : Controller
    {
        private readonly ApplicationDbContext db;

        public MethodsController(DbContextOptions<ApplicationDbContext> options) => db = new ApplicationDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List() => await db.Methods.Select(x => new { x.MethodsID, x.Method }).ToListAsync();
    }
}