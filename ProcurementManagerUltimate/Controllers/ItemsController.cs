using System.Collections;
using Microsoft.AspNetCore.Authorization;
using System.Data;
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
    public class ItemsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ItemsController(DbContextOptions<ApplicationDbContext> options) => db = new ApplicationDbContext(options);

        [HttpGet]
        public async Task<IEnumerable> List() => await db.Items.Select(x => new
        {
            x.ItemsID,
            x.Unit,
            x.Item
        }).ToListAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> Find(short id)
        {
            var item = await db.Items.FindAsync(id);
            return item is null ? 
                NotFound(new { Message = "Item not found" }) :
                Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Items item)
        {
            if (await db.Items.AnyAsync(x => x.Item == item.Item))
                return BadRequest(new { Message = $"{item.Item} already exists" });
            db.Add(item);
            await db.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Items items)
        {
            if (!await db.Items.AnyAsync(x => x.ItemsID == items.ItemsID))
                return BadRequest(new { Message = $"{items.Item} does not exists" });
            db.Entry(items).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(items);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Items items)
        {
            if (!await db.Items.AnyAsync(x => x.ItemsID == items.ItemsID))
                return BadRequest(new { Message = $"{items.Item} does not exists" });
            db.Entry(items).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Ok(items);
        }
    }
}