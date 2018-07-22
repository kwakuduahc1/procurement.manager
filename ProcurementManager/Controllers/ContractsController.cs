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
    public class ContractsController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ContractsController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Contracts.Where(x => !x.IsCompleted).Select(x => new
        {
            x.Amount,
            x.Concurrency,
            x.Contractor,
            x.ContractParameters,
            x.ContractsID,
            x.Methods.Method,
            x.MethodsID,
            x.Subject,
            x.ExpectedDate,
            x.DateSigned,
            Percentage = x.ContractParameters.Where(t => t.IsCompleted).Sum(t => t.Percentage),
            count = x.ContractParameters.Count
        }).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(string id)
        {
            var contract = await new ApplicationDbContext(dco).Contracts.Select(x => new
            {
                x.Subject,
                x.Amount,
                x.Concurrency,
                x.Contractor,
                x.ContractsID,
                DatteAddd = x.DateAdded.Date,
                DateSigned = x.DateSigned.Date,
                ExpectedDate = x.ExpectedDate.Date,
                x.IsApproved,
                x.IsCompleted,
                x.IsFlexible,
                x.MethodsID,
                ContractParameters = x.ContractParameters.Select(t => new { t.Amount, t.Concurrency, t.ContractParameter, t.ContractParametersID, t.ContractsID, ExpectedDate = t.ExpectedDate.Date, t.IsCompleted, t.Percentage }).OrderBy(y => y.ExpectedDate)
            }).SingleOrDefaultAsync(x => x.ContractsID == id);
            return contract == null ? NotFound(new { Message = "Contract was not found" }) as IActionResult : Ok(contract);
        }

        [HttpGet]
        public async Task<IEnumerable> Statuses() => await new ApplicationDbContext(dco).Contracts.Select(x => new { x.Subject, Status = x.ContractParameters.Where(t => t.IsCompleted).Sum(t => t.Percentage) }).ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Contracts contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                int count = await db.Contracts.CountAsync();
                contract.ContractsID = $"COHAS/PROC/{count++}";
                contract.DateAdded = DateTime.Now;
                db.Add(contract);
                await db.SaveChangesAsync();
            }
            return Created($"/Contracts/Find?id={contract.ContractsID}", new { contract.MethodsID, contract.Amount, contract.Contractor, contract.Subject });
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Contracts contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                db.Entry(contract).State = EntityState.Modified;
                db.UpdateRange(contract.ContractParameters);
                await db.SaveChangesAsync();
            }
            return Created($"/Contracts/Find?id={contract.ContractsID}", new { contract.MethodsID });
        }

        [HttpPut]
        public async Task<IActionResult> Close([FromBody]Contracts contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            contract.IsCompleted = true;
            contract.ContractParameters.ToList().ForEach(x => { x.IsCompleted = true; x.DateCompleted = DateTime.Now.Date; });
            contract.DateCompleted = DateTime.Now;
            using (var db = new ApplicationDbContext(dco))
            {
                db.Entry(contract).State = EntityState.Modified;
                db.UpdateRange(contract.ContractParameters);
                await db.SaveChangesAsync();
            }
            return Created($"/Contracts/Find?id={contract.ContractsID}", new { contract.MethodsID });
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]Contracts contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                db.Entry(contract).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            return Created($"/Contracts/Find?id={contract.ContractsID}", contract);
        }
    }
}