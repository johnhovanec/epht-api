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
    public class Tab_StratificationController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public Tab_StratificationController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tab_Stratification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_Stratification>>> GetTab_Stratification()
        {
            return await _context.Config_Tab_Stratification_Test.ToListAsync();
        }

        // GET: api/Tab_Stratification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab_Stratification>> GetTab_Stratification(int id)
        {
            var tab_Stratification = await _context.Config_Tab_Stratification_Test.FindAsync(id);

            if (tab_Stratification == null)
            {
                return NotFound();
            }

            return tab_Stratification;
        }

        // PUT: api/Tab_Stratification/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab_Stratification(int id, Tab_Stratification tab_Stratification)
        {
            if (id != tab_Stratification.Stratification_ID)
            {
                return BadRequest();
            }

            _context.Entry(tab_Stratification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tab_StratificationExists(id))
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

        // POST: api/Tab_Stratification
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tab_Stratification>> PostTab_Stratification(Tab_Stratification tab_Stratification)
        {
            _context.Config_Tab_Stratification_Test.Add(tab_Stratification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab_Stratification", new { id = tab_Stratification.Stratification_ID }, tab_Stratification);
        }

        // DELETE: api/Tab_Stratification/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab_Stratification>> DeleteTab_Stratification(int id)
        {
            var tab_Stratification = await _context.Config_Tab_Stratification_Test.FindAsync(id);
            if (tab_Stratification == null)
            {
                return NotFound();
            }

            _context.Config_Tab_Stratification_Test.Remove(tab_Stratification);
            await _context.SaveChangesAsync();

            return tab_Stratification;
        }

        private bool Tab_StratificationExists(int id)
        {
            return _context.Config_Tab_Stratification_Test.Any(e => e.Stratification_ID == id);
        }
    }
}
