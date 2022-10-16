using System;
using System.Collections;
using Dapper;
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
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ReportsController(DbContextOptions<ApplicationDbContext> options) => db = new ApplicationDbContext(options);

        [HttpGet("{start}/{end}")]
        public async Task<IActionResult> Monthly(DateTime start, DateTime end)
        {
            var uncompleted = await db.Contracts
                .Where(x => !x.IsCompleted)
                .Select(x => new
                {
                    x.Reference,
                    x.Subject,
                    x.Methods.Method,
                    x.DateSigned,
                    x.Sources.Source,
                    x.Amount
                }).Distinct().ToListAsync();

            var fresh = await db.Contracts
                .Where(x => !x.IsCompleted && x.DateSigned.Month >= start.Month && x.DateSigned.Date <= end)
                .Select(x => new
                {
                    x.ContractsID,
                    x.Sources.Source,
                    x.Methods.Method,
                    x.Items.Item,
                    x.Subject,
                    x.DateSigned,
                    x.Amount
                })
                .OrderBy(x => x.DateSigned)
                .Distinct()
                .ToListAsync();

            var completed = await db.Contracts
                .Where(x => x.IsCompleted && x.DateSigned.Date >= start && x.DateSigned.Date <= end)
                .OrderBy(t => t.DateCompleted)
                .Select(x => new
                {
                    x.Reference,
                    x.Subject,
                    x.Sources.Source,
                    x.Methods.Method,
                    x.DateSigned,
                    x.Amount,
                    x.DateCompleted
                })
                .Distinct()
                .ToListAsync();

            var minor = await db.Contracts
                .Where(x => x.IsMinor && x.DateSigned.Date >= start && x.DateSigned.Date <= end)
                .Select(x => new
                {
                    x.Reference,
                    x.Subject,
                    x.Suppliers.Supplier,
                    x.Sources.Source,
                    x.Methods.Method,
                    x.DateSigned,
                    x.Amount
                })
                .Distinct()
                .ToListAsync();

            var payments = await db.Contracts
                .Where(x => x.DateSigned.Date >= start && x.DateSigned.Date <= end)
                .Include(x => x.ContractParameters)
                .Select(x => new
                {
                    x.Reference,
                    x.Subject,
                    x.Suppliers.Supplier,
                    x.DateSigned,
                    Started = x.ContractParameters.Any(t => t.IsCompleted > 0),
                    Payment = x.ContractParameters.All(t => t.IsCompleted == 2),
                    x.DateCompleted,
                    x.Amount
                })
                .Distinct()
                .ToListAsync();

            return base.Ok(new { uncompleted, fresh, completed });
        }

        [HttpGet("{month}")]
        public async Task<IActionResult> Monthly(byte month)
        {
            var uncompleted = await db.Contracts
                .Where(x => !x.IsCompleted && x.DateSigned.Month <= month)
                .Select(x => new
                {
                    x.Reference,
                    x.Subject,
                    x.Methods.Method,
                    x.DateSigned,
                    x.Sources.Source,
                    x.Amount
                }).Distinct().ToListAsync();

            var fresh = await db.Contracts
                .Where(x => !x.IsCompleted && x.DateSigned.Year == DateTime.UtcNow.Year && x.DateSigned.Month == month)
                .Select(x => new
                {
                    x.ContractsID,
                    x.Sources.Source,
                    x.Methods.Method,
                    x.Items.Item,
                    x.Subject,
                    x.DateSigned,
                    x.Amount,
                    x.Reference,
                    x.DateAdded
                })
                .OrderBy(x => x.DateSigned)
                .Distinct()
                .ToListAsync();

            var completed = await db.Contracts
                .Where(x => x.IsCompleted && x.DateCompleted.Year == DateTime.UtcNow.Year && x.DateCompleted.Month == month)
                .OrderBy(t => t.DateCompleted)
                .Select(x => new
                {
                    x.Reference,
                    x.Subject,
                    x.Sources.Source,
                    x.Methods.Method,
                    x.DateSigned,
                    x.Amount,
                    x.DateCompleted
                })
                .Distinct()
                .ToListAsync();

            var minor = await db.Contracts
                .Where(x => x.IsMinor && x.DateSigned.Month >= month)
                .Select(x => new
                {
                    x.Reference,
                    x.Subject,
                    x.Suppliers.Supplier,
                    x.Sources.Source,
                    x.Methods.Method,
                    x.DateSigned,
                    x.Amount
                })
                .Distinct()
                .ToListAsync();

            var payments = await db.Database.GetDbConnection().QueryAsync(@"select MAX(p.IsCompleted) isCompleted, sum(p.Amount) amount, date(p.DateCompleted) [dateCompleted], c.reference, c.[subject], s.supplier, date(c.DateSigned) dateSigned
                from ContractParameters p
                inner join Contracts c on c.Reference = p.Reference
                inner join Suppliers s on s.SupplierID = c.SuppliersID
                where strftime('%m', p.DateCompleted) = @month and strftime('%Y',p.DateCompleted) = strftime('%Y', 'now')
                group by c.reference, c.Subject, supplier, date(p.DateCompleted), date(c.DateSigned)", param: new { month});

            return base.Ok(new { uncompleted, fresh, completed });
        }

        //[HttpGet("{Defaulting}")]
        //public async Task<IEnumerable> Defaulting() => await db.Contracts.Where(x => !x.IsCompleted && x.ExpectedDate.Date < DateTime.Now.Date)
        //    .Select(x => new
        //    {
        //        x.DateSigned,
        //        x.ContractsID,
        //        x.Amount,
        //        x.ExpectedDate,
        //        x.Items.Item,
        //        x.Methods.Method,
        //        x.Sources.Source,
        //        x.Subject,
        //        Progress = x.ContractParameters.Where(t => t.IsCompleted < 1).Sum(t => t.Percentage)
        //    }).ToListAsync();
    }
}