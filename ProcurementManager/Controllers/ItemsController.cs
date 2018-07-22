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
    public class ItemsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ItemsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Items.Select(x => new { x.Concurrency, x.Item, x.ItemsID, x.ShortName }).ToListAsync();
    }
}