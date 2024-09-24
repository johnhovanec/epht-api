using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using epht_api.Data;
using epht_api.Models;

namespace epht_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartConfigController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public ChartConfigController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tab_ChartConfig
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_ChartConfig>>> GetTab_ChartConfig()
        {
            return await _context.Config_Tab_ChartConfig_Test.ToListAsync();
        }

        // GET: api/Tab_ChartConfig/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab_ChartConfig>> GetTab_ChartConfig(int id)
        {
            var tab_ChartConfig = await _context.Config_Tab_ChartConfig_Test.FindAsync(id);

            if (tab_ChartConfig == null)
            {
                return NotFound();
            }

            return tab_ChartConfig;
        }

        // PUT: api/Tab_ChartConfig/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab_ChartConfig(int id, Tab_ChartConfig tab_ChartConfig)
        {
            if (id != tab_ChartConfig.ChartConfig_ID)
            {
                return BadRequest();
            }

            _context.Entry(tab_ChartConfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tab_ChartConfigExists(id))
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

        // POST: api/Tab_ChartConfig
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tab_ChartConfig>> PostTab_ChartConfig(Tab_ChartConfig tab_ChartConfig)
        {
            _context.Config_Tab_ChartConfig_Test.Add(tab_ChartConfig);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab_ChartConfig", new { id = tab_ChartConfig.ChartConfig_ID }, tab_ChartConfig);
        }

        // DELETE: api/Tab_ChartConfig/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab_ChartConfig>> DeleteTab_ChartConfig(int id)
        {
            var tab_ChartConfig = await _context.Config_Tab_ChartConfig_Test.FindAsync(id);
            if (tab_ChartConfig == null)
            {
                return NotFound();
            }

            _context.Config_Tab_ChartConfig_Test.Remove(tab_ChartConfig);
            await _context.SaveChangesAsync();

            return tab_ChartConfig;
        }

        private bool Tab_ChartConfigExists(int id)
        {
            return _context.Config_Tab_ChartConfig_Test.Any(e => e.ChartConfig_ID == id);
        }
    }
}
