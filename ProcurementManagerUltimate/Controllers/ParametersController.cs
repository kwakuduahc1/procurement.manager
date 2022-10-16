using System.Collections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManagerUltimate.Context;
using ProcurementManagerUltimate.Model;

namespace ProcurementManagerUltimate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("bStudioApps")]
    //[Authorize(Roles = "Developer, Exams, Principal")]
    public class ParametersController : Controller
    {
        private readonly ApplicationDbContext db;

        public ParametersController(DbContextOptions<ApplicationDbContext> options) => db = new ApplicationDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List(string id) => await db.ContractParameters.Where(x => x.Reference == id).ToListAsync();

        [HttpGet("{id}")]
        public async Task<IEnumerable> Find(string id) => await db.ContractParameters
            .Where(x => x.Reference == id)
            .Select(x => new
            {
                x.Parameter,
                x.ContractParametersID,
                x.Reference,
                x.Percentage,
                x.Amount,
                x.ExpectedDate,
                x.IsCompleted,
                x.DateCompleted
            })
            .ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody, Bind("ContractParameter", "ContractsID", "Percentage", "Amount")] ContractParameters parameter)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            if (await db.ContractParameters.AnyAsync(x => x.Reference == parameter.Reference && x.Parameter == parameter.Parameter))
                return BadRequest(new { Message = "Parameter already exists for this contract" });
            parameter.IsCompleted = 0;
            db.Add(parameter);
            await db.SaveChangesAsync();
            return Created($"/Parameters/Find?id={parameter.ContractParametersID}", parameter);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ContractParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            if (!await db.ContractParameters.AnyAsync(x => x.ContractParametersID == parameters.ContractParametersID))
                return base.BadRequest(new { Message = "Operation failed. Item was not found" });
            db.Entry(parameters).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Created($"/Parameters/Find?id={parameters.ContractParametersID}", parameters);
        }

        [HttpPut("Status")]
        public async Task<IActionResult> Status(ContractParameters param)
        {
            //var p = await db.ContractParameters.FindAsync(param.ContractParametersID);
            //if (p is null)
            //    return BadRequest(new { Message = "The parameter was not found" });
            //if (p.IsCompleted > 1)
            //    p.IsCompleted = 0;
            //else p.IsCompleted += 1;
            //p.DateCompleted = DateTime.UtcNow;
            //db.Entry(p).State = EntityState.Modified;
            var list = await db.ContractParameters.Where(x => x.Reference == param.Reference).ToListAsync();
            if (list.Any())
            {
                var date = DateTime.UtcNow;
                var obj = list.Where(x => x.ContractParametersID == param.ContractParametersID).FirstOrDefault();
                if (obj is null)
                    return BadRequest(new { Message = "Object changed whiles data processing was in progress" });
                if (obj.IsCompleted > 1)
                    obj.IsCompleted = 0;
                else obj.IsCompleted += 1;
                if (obj.IsCompleted == 2)
                    obj.DateCompleted = date;
                if (list.All(x => x.IsCompleted == 2))
                {
                    var con = await db.Contracts.Where(x => x.Reference == param.Reference).ToListAsync();
                    con.ForEach(u =>
                    {
                        u.IsCompleted = true;
                        u.DateCompleted = date;
                        db.Entry(u).State = EntityState.Modified;
                    });
                }
                await db.SaveChangesAsync();
                return Accepted(obj.IsCompleted);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ContractParameters parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            var par = await db.ContractParameters.FirstOrDefaultAsync(x => x.ContractParametersID != parameters.ContractParametersID);
            if (par is null)
                return BadRequest(new { Message = "Delete failed. Item was not found" });
            if (par.IsCompleted > 1)
                return BadRequest(new { Message = "Parameter already completed" });
            db.Entry(par).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Accepted(parameters);
        }
    }
}