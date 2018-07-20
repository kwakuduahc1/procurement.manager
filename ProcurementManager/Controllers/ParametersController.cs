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
    public class ParametersController : Controller
    {
        private readonly DbContextOptions<ApplicationDbContext> dco;

        public ParametersController(DbContextOptions<ApplicationDbContext> options) => dco = options;

        [HttpGet]
        public async Task<IEnumerable> List(string id) => await new ApplicationDbContext(dco).ContractParameters.Where(x => x.ContractsID == id).ToListAsync();

        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> Find(string id)
        {
            Contracts contract = await new ApplicationDbContext(dco).Contracts.FindAsync(id);
            return contract == null ? Ok(contract) : NotFound(new { Message = "Contract was not found" }) as IActionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody, Bind("ContractParameter", "ContractsID", "Percentage", "Amount")]ContractParameters parameter)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.ContractParameters.AnyAsync(x => x.ContractsID == parameter.ContractsID && x.ContractParameter == parameter.ContractParameter))
                    return BadRequest(new { Message = "Item already exists for this contract" });
                db.Add(parameter);
                await db.SaveChangesAsync();
            }
            return Created($"/Parameters/Find?id={parameter.ContractParametersID}", parameter);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]ContractParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.ContractParameters.AnyAsync(x => x.ContractParametersID != parameters.ContractParametersID))
                    return BadRequest(new { Message = "Operation failed. Item was not found" });
                db.Entry(parameters).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return Created($"/Parameters/Find?id={parameters.ContractParametersID}", parameters);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]ContractParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            using (var db = new ApplicationDbContext(dco))
            {
                if (await db.ContractParameters.AnyAsync(x => x.ContractParametersID != parameters.ContractParametersID))
                    return BadRequest(new { Message = "Delete failed. Item was not found" });
                db.Entry(parameters).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            }
            return Created($"/Contracts/Find?id={parameters.ContractsID}", parameters);
        }
    }
}