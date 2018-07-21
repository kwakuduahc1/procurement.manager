using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManager.Context;

namespace ProcurementManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> context;

        public HomeController(DbContextOptions<ApplicationDbContext> dbContextOptions) => context = dbContextOptions;
        public async Task<IActionResult> Index()
        {
            await CreateDatabase();
            return View();
        }

        private async Task CreateDatabase() => await new ApplicationDbContext(context).Database.EnsureCreatedAsync();

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
