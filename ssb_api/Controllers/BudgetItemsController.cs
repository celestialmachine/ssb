using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ssb_api.Models;

namespace ssb_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetItemsController : ControllerBase
    {
        private readonly BudgetContext _context;

        public BudgetItemsController(BudgetContext context)
        {
            _context = context;
        }

        // GET: api/BudgetItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BudgetItem>>> GetBudgetItems()
        {
          if (_context.BudgetItems == null)
          {
              return NotFound();
          }
            return await _context.BudgetItems.ToListAsync();
        }

        // GET: api/BudgetItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetItem>> GetBudgetItem(long id)
        {
          if (_context.BudgetItems == null)
          {
              return NotFound();
          }
            var budgetItem = await _context.BudgetItems.FindAsync(id);

            if (budgetItem == null)
            {
                return NotFound();
            }

            return budgetItem;
        }

        // PUT: api/BudgetItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudgetItem(long id, BudgetItem budgetItem)
        {
            if (id != budgetItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(budgetItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BudgetItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BudgetItem>> PostBudgetItem(BudgetItem budgetItem)
        {
          if (_context.BudgetItems == null)
          {
              return Problem("Entity set 'BudgetContext.BudgetItems'  is null.");
          }
            _context.BudgetItems.Add(budgetItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBudgetItem", new { id = budgetItem.Id }, budgetItem);
        }

        // DELETE: api/BudgetItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudgetItem(long id)
        {
            if (_context.BudgetItems == null)
            {
                return NotFound();
            }
            var budgetItem = await _context.BudgetItems.FindAsync(id);
            if (budgetItem == null)
            {
                return NotFound();
            }

            _context.BudgetItems.Remove(budgetItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BudgetItemExists(long id)
        {
            return (_context.BudgetItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
