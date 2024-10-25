using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using epht_api.Data;
using epht_api.Models;

namespace epht_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tab_MapSetController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public Tab_MapSetController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tab_MapSet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_MapSet>>> GetTab_MapSet()
        {
            return await _context.Config_Tab_MapSet_Test.ToListAsync();
        }

        // GET: api/Tab_MapSet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab_MapSet>> GetTab_MapSet(int id)
        {
            var tab_MapSet = await _context.Config_Tab_MapSet_Test.FindAsync(id);

            if (tab_MapSet == null)
            {
                return NotFound();
            }

            return tab_MapSet;
        }

        // PUT: api/Tab_MapSet/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab_MapSet(int id, Tab_MapSet tab_MapSet)
        {
            if (id != tab_MapSet.MapSet_ID)
            {
                return BadRequest();
            }

            _context.Entry(tab_MapSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tab_MapSetExists(id))
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

        // POST: api/Tab_MapSet
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tab_MapSet>> PostTab_MapSet(Tab_MapSet tab_MapSet)
        {
            _context.Config_Tab_MapSet_Test.Add(tab_MapSet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab_MapSet", new { id = tab_MapSet.MapSet_ID }, tab_MapSet);
        }

        // DELETE: api/Tab_MapSet/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab_MapSet>> DeleteTab_MapSet(int id)
        {
            var tab_MapSet = await _context.Config_Tab_MapSet_Test.FindAsync(id);
            if (tab_MapSet == null)
            {
                return NotFound();
            }

            _context.Config_Tab_MapSet_Test.Remove(tab_MapSet);
            await _context.SaveChangesAsync();

            return tab_MapSet;
        }

        private bool Tab_MapSetExists(int id)
        {
            return _context.Config_Tab_MapSet_Test.Any(e => e.MapSet_ID == id);
        }
    }
}
