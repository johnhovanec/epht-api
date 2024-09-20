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
    public class TabsController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public TabsController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab>>> GetTab()
        {
            return await _context.Config_Tab_Test.ToListAsync();
        }

        // GET: api/Tabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab>> GetTab(int id)
        {
            var tab = await _context.Config_Tab_Test.FindAsync(id);

            if (tab == null)
            {
                return NotFound();
            }

            return tab;
        }

        // PUT: api/Tabs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab(int id, Tab tab)
        {
            if (id != tab.Tab_ID)
            {
                return BadRequest();
            }

            _context.Entry(tab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TabExists(id))
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

        // POST: api/Tabs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tab>> PostTab(Tab tab)
        {
            _context.Config_Tab_Test.Add(tab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab", new { id = tab.Tab_ID }, tab);
        }

        // DELETE: api/Tabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab>> DeleteTab(int id)
        {
            var tab = await _context.Config_Tab_Test.FindAsync(id);
            if (tab == null)
            {
                return NotFound();
            }

            _context.Config_Tab_Test.Remove(tab);
            await _context.SaveChangesAsync();

            return tab;
        }

        private bool TabExists(int id)
        {
            return _context.Config_Tab_Test.Any(e => e.Tab_ID == id);
        }
    }
}
