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
    public class Tab_DefaultSetNameController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public Tab_DefaultSetNameController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tab_DefaultSetName
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_DefaultSetName>>> GetTab_DefaultSetName()
        {
            return await _context.Config_Tab_DefaultSetName_Test.ToListAsync();
        }

        // GET: api/Tab_DefaultSetName/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab_DefaultSetName>> GetTab_DefaultSetName(int id)
        {
            var tab_DefaultSetName = await _context.Config_Tab_DefaultSetName_Test.FindAsync(id);

            if (tab_DefaultSetName == null)
            {
                return NotFound();
            }

            return tab_DefaultSetName;
        }

        // PUT: api/Tab_DefaultSetName/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab_DefaultSetName(int id, Tab_DefaultSetName tab_DefaultSetName)
        {
            if (id != tab_DefaultSetName.DefaultSetName_ID)
            {
                return BadRequest();
            }

            _context.Entry(tab_DefaultSetName).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tab_DefaultSetNameExists(id))
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

        // POST: api/Tab_DefaultSetName
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tab_DefaultSetName>> PostTab_DefaultSetName(Tab_DefaultSetName tab_DefaultSetName)
        {
            _context.Config_Tab_DefaultSetName_Test.Add(tab_DefaultSetName);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab_DefaultSetName", new { id = tab_DefaultSetName.DefaultSetName_ID }, tab_DefaultSetName);
        }

        // DELETE: api/Tab_DefaultSetName/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab_DefaultSetName>> DeleteTab_DefaultSetName(int id)
        {
            var tab_DefaultSetName = await _context.Config_Tab_DefaultSetName_Test.FindAsync(id);
            if (tab_DefaultSetName == null)
            {
                return NotFound();
            }

            _context.Config_Tab_DefaultSetName_Test.Remove(tab_DefaultSetName);
            await _context.SaveChangesAsync();

            return tab_DefaultSetName;
        }

        private bool Tab_DefaultSetNameExists(int id)
        {
            return _context.Config_Tab_DefaultSetName_Test.Any(e => e.DefaultSetName_ID == id);
        }
    }
}
