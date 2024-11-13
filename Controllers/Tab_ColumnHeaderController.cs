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
    public class Tab_ColumnHeaderController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public Tab_ColumnHeaderController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tab_ColumnHeader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_ColumnHeader>>> GetTab_ChartColumnHeader()
        {
            return await _context.Config_Tab_ColumnHeader_Test.ToListAsync();
        }

        // GET: api/Tab_ColumnHeader/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab_ColumnHeader>> GetTab_ChartColumnHeader(int id)
        {
            var tab_ChartColumnHeader = await _context.Config_Tab_ColumnHeader_Test.FindAsync(id);

            if (tab_ChartColumnHeader == null)
            {
                return NotFound();
            }

            return tab_ChartColumnHeader;
        }

        // PUT: api/Tab_ColumnHeader/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab_ChartColumnHeader(int id, Tab_ColumnHeader tab_ChartColumnHeader)
        {
            if (id != tab_ChartColumnHeader.ColumnHeader_ID)
            {
                return BadRequest();
            }

            _context.Entry(tab_ChartColumnHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tab_ChartColumnHeaderExists(id))
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

        // POST: api/Tab_ColumnHeader
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tab_ColumnHeader>> PostTab_ChartColumnHeader(Tab_ColumnHeader tab_ChartColumnHeader)
        {
            _context.Config_Tab_ColumnHeader_Test.Add(tab_ChartColumnHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab_ChartColumnHeader", new { id = tab_ChartColumnHeader.ColumnHeader_ID }, tab_ChartColumnHeader);
        }

        // DELETE: api/Tab_ColumnHeader/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab_ColumnHeader>> DeleteTab_ChartColumnHeader(int id)
        {
            var tab_ChartColumnHeader = await _context.Config_Tab_ColumnHeader_Test.FindAsync(id);
            if (tab_ChartColumnHeader == null)
            {
                return NotFound();
            }

            _context.Config_Tab_ColumnHeader_Test.Remove(tab_ChartColumnHeader);
            await _context.SaveChangesAsync();

            return tab_ChartColumnHeader;
        }

        private bool Tab_ChartColumnHeaderExists(int id)
        {
            return _context.Config_Tab_ColumnHeader_Test.Any(e => e.ColumnHeader_ID == id);
        }
    }
}
