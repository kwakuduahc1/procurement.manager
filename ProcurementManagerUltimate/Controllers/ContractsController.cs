using System.Collections;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManagerUltimate.Context;
using ProcurementManagerUltimate.Model;
using Dapper;

namespace ProcurementManagerUltimate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("bStudioApps")]
    public class ContractsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ContractsController(DbContextOptions<ApplicationDbContext> options) => db = new ApplicationDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List()
        {
            var qry = @"select c.'reference' 'reference' , c.subject 'subject', sum(c.amount) amount, count(c.ItemsID) quantity, 
                        (select ifnull(sum(Percentage), 0) from ContractParameters where IsCompleted = 1) progress
                        from Contracts c
                        where c.IsCompleted = 0
                        group by c.Reference, c.Subject";
            return await db.Database.GetDbConnection().QueryAsync(qry);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(string id)
        {
            var cons = await db.Database.GetDbConnection().QueryAsync(@"SELECT x.Subject subject,
                               x.Amount amount,
                               x.ContractsID contractsID,
                               sp.Supplier supplier,
                               sp.TIN tin,
                               s.Source source,
                               i.Item item,
                               x.DateSigned dateSigned,
                               x.ExpectedDate expectedDate,
                               x.IsCompleted isCompleted,
                               m.Method method,
                               x.Quantity quantity,
                               x.Reference reference
                        from Contracts x
                        inner join Methods m on m.MethodsID = x.MethodsID
                        inner join Items i on i.ItemsID = x.ItemsID
                        inner join Sources s on s.SourcesID = x.SourcesID
                        inner join Suppliers sp on sp.SupplierID = x.SuppliersID
                         where x.reference = @id", param: new { id });
            return cons == null ? NotFound(new { Message = "Contract was not found" }) : Ok(cons);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Search(string id)
        //{
        //    var contract = await db.Contracts.Where(x => x.Subject.Contains(id)).Select(x => new
        //    {
        //        x.Subject,
        //        x.Amount,
        //        x.ContractsID,
        //        x.Sources.Source,
        //        x.Items.Item,
        //        x.DateSigned,
        //        x.ExpectedDate,
        //        x.IsApproved,
        //        x.IsCompleted,
        //        x.Methods.Method,
        //        x.MethodsID
        //    }).ToListAsync();
        //    return contract == null ? NotFound() : Ok(contract);
        //}

        //[HttpGet("Statuses")]
        //public async Task<IEnumerable> Statuses() => await db.Contracts.Select(x => new { x.Subject, Status = x.ContractParameters.Where(t => t.IsCompleted).Sum(t => t.Percentage) }).ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Create(List<Contracts> contracts)
        {
            if (await db.Contracts.AnyAsync(x => x.Reference == contracts[0].Reference))
                return BadRequest(new { Message = $"The ID: {contracts[0].Reference} has previously been used" });
            var date = DateTime.UtcNow;
            var num = await db.Contracts.CountAsync(x => x.DateSigned.Year == date.Year) + 1;
            foreach (var con in contracts)
            {
                con.DateAdded = DateTime.Now;
                con.IsApproved = true;
                con.IsCompleted = false;
                con.IsFlexible = true;
                db.Add(con);
            }
            await db.SaveChangesAsync();
            return Created($"/Contracts/Find?id={contracts[0].ContractsID}", contracts);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Contracts contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.Entry(contract).State = EntityState.Modified;
            db.UpdateRange(contract.ContractParameters);
            await db.SaveChangesAsync();
            return Created($"/Contracts/Find?id={contract.ContractsID}", contract);
        }

        [HttpPut("Close")]
        public async Task<IActionResult> Close([FromBody] Contracts contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            contract.IsCompleted = true;
            contract.ContractParameters.ToList().ForEach(x =>
            {
                x.IsCompleted = 2;
                x.DateCompleted = DateTime.UtcNow;
            });
            contract.DateCompleted = DateTime.UtcNow;
            db.Entry(contract).State = EntityState.Modified;
            db.UpdateRange(contract.ContractParameters);
            await db.SaveChangesAsync();
            return Created($"/Contracts/Find?id={contract.ContractsID}", contract);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Contracts contract)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Error = "Invalid data was submitted", Message = ModelState.Values.First(x => x.Errors.Count > 0).Errors.Select(t => t.ErrorMessage).First() });
            db.Entry(contract).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Created($"/Contracts/Find?id={contract.ContractsID}", contract);
        }
    }
}