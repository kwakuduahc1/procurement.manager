using System.Collections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcurementManagerUltimate.Context;
using ProcurementManagerUltimate.Model;

namespace ProcurementManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("bStudioApps")]
    //[Authorize(Roles = "Developer, Exams, Principal")]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public SuppliersController(DbContextOptions<ApplicationDbContext> options) => db = new ApplicationDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List() => await db.Suppliers.ToListAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(short id)
        {
            var sup = await db.Suppliers.FindAsync(id);
            return sup is null ?
                NotFound(new { Message = "Item not found" }) :
                Ok(sup);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Suppliers sup)
        {
            if (await db.Suppliers.AnyAsync(x => x.TIN == sup.TIN))
                return BadRequest(new { Message = $"TIN: {sup.TIN} already exists" });
            db.Add(sup);
            await db.SaveChangesAsync();
            return Created("", sup);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Suppliers Suppliers)
        {
            if (!await db.Suppliers.AnyAsync(x => x.SupplierID == Suppliers.SupplierID))
                return BadRequest(new { Message = $"{Suppliers.Supplier} does not exists" });
            db.Entry(Suppliers).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(Suppliers);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Suppliers Suppliers)
        {
            if (!await db.Suppliers.AnyAsync(x => x.SupplierID == Suppliers.SupplierID))
                return BadRequest(new { Message = $"{Suppliers.Supplier} does not exists" });
            db.Entry(Suppliers).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Ok(Suppliers);
        }
    }
}