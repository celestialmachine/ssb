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
    public class BudgetEventsController : ControllerBase
    {
        private readonly BudgetContext _context;

        public BudgetEventsController(BudgetContext context)
        {
            _context = context;
        }

        // GET: api/BudgetEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BudgetEvent>>> GetBudgetEvents()
        {
          if (_context.BudgetEvents == null)
          {
              return NotFound();
          }
            return await _context.BudgetEvents.ToListAsync();
        }

        // GET: api/BudgetEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BudgetEvent>> GetBudgetEvent(int id)
        {
          if (_context.BudgetEvents == null)
          {
              return NotFound();
          }
            var budgetEvent = await _context.BudgetEvents.FindAsync(id);

            if (budgetEvent == null)
            {
                return NotFound();
            }

            return budgetEvent;
        }

        // PUT: api/BudgetEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBudgetEvent(int id, BudgetEvent budgetEvent)
        {
            if (id != budgetEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(budgetEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetEventExists(id))
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

        // POST: api/BudgetEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BudgetEvent>> PostBudgetEvent(BudgetEvent budgetEvent)
        {
          if (_context.BudgetEvents == null)
          {
              return Problem("Entity set 'BudgetContext.BudgetEvents'  is null.");
          }
            _context.BudgetEvents.Add(budgetEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBudgetEvent", new { id = budgetEvent.Id }, budgetEvent);
        }

        // DELETE: api/BudgetEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudgetEvent(int id)
        {
            if (_context.BudgetEvents == null)
            {
                return NotFound();
            }
            var budgetEvent = await _context.BudgetEvents.FindAsync(id);
            if (budgetEvent == null)
            {
                return NotFound();
            }

            _context.BudgetEvents.Remove(budgetEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BudgetEventExists(int id)
        {
            return (_context.BudgetEvents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
