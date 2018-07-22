using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManager.Context;
using ProcurementManager.Model;

namespace ProcurementManager.Controllers
{
    public class SourcesController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public SourcesController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Sources.Select(x => new { x.Concurrency, x.Source, x.SourcesID }).ToListAsync();

    }
}