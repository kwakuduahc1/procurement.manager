using System.Collections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManagerUltimate.Context;

namespace ProcurementManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("bStudioApps")]
    //[Authorize(Roles = "Developer, Exams, Principal")]
    public class SourcesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public SourcesController(DbContextOptions<ApplicationDbContext> options) => db = new ApplicationDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List() => await db.Sources.Select(x=> new
        {
            x.Source,
            x.SourcesID
        }).ToListAsync();
    }
}