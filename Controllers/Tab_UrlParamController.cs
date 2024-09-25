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
    public class Tab_UrlParamController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public Tab_UrlParamController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Tab_UrlParam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_UrlParam>>> GetTab_UrlParam()
        {
            return await _context.Config_Tab_UrlParam_Test.ToListAsync();
        }

        // GET: api/Tab_UrlParam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tab_UrlParam>> GetTab_UrlParam(int id)
        {
            var tab_UrlParam = await _context.Config_Tab_UrlParam_Test.FindAsync(id);

            if (tab_UrlParam == null)
            {
                return NotFound();
            }

            return tab_UrlParam;
        }

        // PUT: api/Tab_UrlParam/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTab_UrlParam(int id, Tab_UrlParam tab_UrlParam)
        {
            if (id != tab_UrlParam.UrlParam_ID)
            {
                return BadRequest();
            }

            _context.Entry(tab_UrlParam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tab_UrlParamExists(id))
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

        // POST: api/Tab_UrlParam
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tab_UrlParam>> PostTab_UrlParam(Tab_UrlParam tab_UrlParam)
        {
            _context.Config_Tab_UrlParam_Test.Add(tab_UrlParam);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab_UrlParam", new { id = tab_UrlParam.UrlParam_ID }, tab_UrlParam);
        }

        // DELETE: api/Tab_UrlParam/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tab_UrlParam>> DeleteTab_UrlParam(int id)
        {
            var tab_UrlParam = await _context.Config_Tab_UrlParam_Test.FindAsync(id);
            if (tab_UrlParam == null)
            {
                return NotFound();
            }

            _context.Config_Tab_UrlParam_Test.Remove(tab_UrlParam);
            await _context.SaveChangesAsync();

            return tab_UrlParam;
        }

        private bool Tab_UrlParamExists(int id)
        {
            return _context.Config_Tab_UrlParam_Test.Any(e => e.UrlParam_ID == id);
        }
    }
}
