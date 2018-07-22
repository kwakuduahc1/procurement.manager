using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManager.Context;

namespace ProcurementManager.Controllers
{
    public class ReportsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ReportsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IActionResult> Monthly(DateTime period)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                var uncompleted = await db.Contracts.Where(x => !x.IsCompleted).Select(x => new { x.ContractsID, x.Subject, x.Methods.Method, x.DateSigned, x.Sources.Source, x.Items.Item, x.Amount }).ToListAsync();
                var fresh = await db.Contracts.Where(x => x.DateSigned.Year == period.Year && x.DateSigned.Month == period.Date.Month).Select(x => new { x.ContractsID, x.Sources.Source, x.Items.Item, x.Subject, x.Contractor, x.DateSigned, x.Amount }).ToListAsync();
                var completed = await db.Contracts.Where(x => x.DateSigned.Year == period.Year && x.DateSigned.Month == period.Date.Month && x.IsCompleted).Select(x => new { x.ContractsID, x.Subject, x.Sources.Source, x.Items.Item, x.Methods.Method, x.DateSigned, x.Amount, x.DateCompleted }).ToListAsync();
                return Ok(new { uncompleted, fresh, completed });
            }
        }
    }
}