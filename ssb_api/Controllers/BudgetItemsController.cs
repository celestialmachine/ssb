using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ssb_api.Models;
using ssb_api.Services;

namespace ssb_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetItemsController : ControllerBase
    {
        private readonly BudgetContext _context;

        public BudgetItemsController(BudgetContext context, EventService eventService)
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
        public async Task<ActionResult<BudgetItem>> GetBudgetItem(int id)
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
        public async Task<IActionResult> PutBudgetItem(int id, BudgetItem budgetItem)
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
            
            //item added to db context. 'Add' tracks changes made to budget item, including adding the newly created Id.
            _context.BudgetItems.Add(budgetItem);
            //changes made to db context are saved to the database
            await _context.SaveChangesAsync();
            //returns newly created item
            return CreatedAtAction(nameof(GetBudgetItem), new { id = budgetItem.Id }, budgetItem);
        }

        // DELETE: api/BudgetItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudgetItem(int id)
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

        private bool BudgetItemExists(int id)
        {
            return (_context.BudgetItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
