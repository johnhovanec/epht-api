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
    public class Tab_ChartDataSetController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public Tab_ChartDataSetController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tab_ChartDataSet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_ChartDataSet>>> GetTab_Chart_DataSet()
        {
            return await _context.Config_Tab_ChartDataSet_Test.ToListAsync();
        }

        // GET: api/Tab_ChartDataSet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab_ChartDataSet>> GetTab_Chart_DataSet(int id)
        {
            var tab_Chart_DataSet = await _context.Config_Tab_ChartDataSet_Test.FindAsync(id);

            if (tab_Chart_DataSet == null)
            {
                return NotFound();
            }

            return tab_Chart_DataSet;
        }

        // PUT: api/Tab_ChartDataSet/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab_Chart_DataSet(int id, Tab_ChartDataSet tab_Chart_DataSet)
        {
            if (id != tab_Chart_DataSet.ChartDataSet_ID)
            {
                return BadRequest();
            }

            _context.Entry(tab_Chart_DataSet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tab_Chart_DataSetExists(id))
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

        // POST: api/Tab_ChartDataSet
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tab_ChartDataSet>> PostTab_Chart_DataSet(Tab_ChartDataSet tab_Chart_DataSet)
        {
            _context.Config_Tab_ChartDataSet_Test.Add(tab_Chart_DataSet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab_Chart_DataSet", new { id = tab_Chart_DataSet.ChartDataSet_ID }, tab_Chart_DataSet);
        }

        // DELETE: api/Tab_ChartDataSet/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab_ChartDataSet>> DeleteTab_Chart_DataSet(int id)
        {
            var tab_Chart_DataSet = await _context.Config_Tab_ChartDataSet_Test.FindAsync(id);
            if (tab_Chart_DataSet == null)
            {
                return NotFound();
            }

            _context.Config_Tab_ChartDataSet_Test.Remove(tab_Chart_DataSet);
            await _context.SaveChangesAsync();

            return tab_Chart_DataSet;
        }

        private bool Tab_Chart_DataSetExists(int id)
        {
            return _context.Config_Tab_ChartDataSet_Test.Any(e => e.ChartDataSet_ID == id);
        }
    }
}
