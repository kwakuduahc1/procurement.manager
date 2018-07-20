using System;
using System.Collections;
using System.Collections.Generic;
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
        public async Task<IEnumerable> List() => await new ApplicationDbContext(dco).Contracts.Where(x => !x.IsCompleted).ToListAsync();

        [HttpGet]
        public async Task<IActionResult> Find(string id)
        {
            Contracts contract = await new ApplicationDbContext(dco).Contracts.FindAsync(id);
            return contract == null ? Ok(contract) : NotFound(new { Message = "Contract was not found" }) as IActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody][Bind("Subject", "MethodsID", "Contractor", "Amount", "IsFlexible", "ExpectedDate", "DateSigned", "ContractParameter", "Percentage", "Amount")]Contracts contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                int count = await db.Contracts.CountAsync();
                string id = $"COHAS/PROC/{count++}";
                contract.DateAdded = DateTime.Now;
                contract.ContractParameters.ToList().ForEach(x => x.ContractsID = id);
                db.Add(contract);
                await db.SaveChangesAsync();
            }
            return Created($"/Contracts/Find?id={contract.ContractsID}", contract);
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
            return Created($"/Contracts/Find?id={contract.ContractsID}", contract);
        }

        [HttpDelete]
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