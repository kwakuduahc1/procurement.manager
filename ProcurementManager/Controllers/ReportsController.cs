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
    public class ReportsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ReportsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IActionResult> Monthly(byte month, short year)
        {
            using (var db = new ApplicationDbContext(dco))
            {
                var uncompleted = await db.Contracts.Where(x => !x.IsCompleted).Select(x => new { x.ContractsID, x.Subject, x.Methods.Method, x.DateSigned, x.Sources.Source, x.Items.Item, x.Amount, Progress = x.ContractParameters.Where(t => t.IsCompleted).Sum(t => t.Percentage) }).OrderBy(x => x.Progress).ToListAsync();
                var fresh = await db.Contracts.Where(x => x.DateSigned.Year == year && x.DateSigned.Month == month).Select(x => new { x.ContractsID, x.Sources.Source, x.Methods.Method, x.Items.Item, x.Subject, x.Contractor, x.DateSigned, x.Amount }).OrderBy(x => x.DateSigned).ToListAsync();
                var completed = await db.Contracts.Where(x => x.DateCompleted.Year == year && x.DateCompleted.Month == month).Select(x => new { x.ContractsID, x.Subject, x.Sources.Source, x.Items.Item, x.Methods.Method, x.DateSigned, x.Amount, x.DateCompleted }).OrderBy(t => t.DateCompleted).ToListAsync();
                return Ok(new { uncompleted, fresh, completed });
            }
        }

        [HttpGet]
        public async Task<IEnumerable> Defaulting() => await new ApplicationDbContext(dco).Contracts.Where(x => !x.IsCompleted && x.ExpectedDate.Date < DateTime.Now.Date)
            .Select(x => new
            {
                x.DateSigned,
                x.ContractsID,
                x.Amount,
                x.ExpectedDate,
                x.Items.Item,
                x.Items.ShortName,
                x.Methods.Method,
                x.Sources.Source,
                x.Subject,
                Progress = x.ContractParameters.Where(t => t.IsCompleted).Sum(t => t.Percentage)
            }).ToListAsync();
    }
}