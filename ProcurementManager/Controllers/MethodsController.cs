using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManager.Context;

namespace ProcurementManager.Controllers
{
    public class MethodsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public MethodsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Methods.OrderBy(o => o.MethodsID).Select(x => new { x.Concurrency, x.Method, x.MethodsID }).ToListAsync();
    }
}