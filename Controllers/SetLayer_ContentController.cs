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
    public class SetLayer_ContentController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public SetLayer_ContentController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/SetLayer_Content
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SetLayer_Content>>> GetSetLayer_Content()
        {
            return await _context.Config_SetLayer_Content_Test.ToListAsync();
        }

        // GET: api/SetLayer_Content/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SetLayer_Content>> GetSetLayer_Content(int id)
        {
            var setLayer_Content = await _context.Config_SetLayer_Content_Test.FindAsync(id);

            if (setLayer_Content == null)
            {
                return NotFound();
            }

            return setLayer_Content;
        }

        // PUT: api/SetLayer_Content/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSetLayer_Content(int id, SetLayer_Content setLayer_Content)
        {
            if (id != setLayer_Content.Content_ID)
            {
                return BadRequest();
            }

            _context.Entry(setLayer_Content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetLayer_ContentExists(id))
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

        // POST: api/SetLayer_Content
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SetLayer_Content>> PostSetLayer_Content(SetLayer_Content setLayer_Content)
        {
            _context.Config_SetLayer_Content_Test.Add(setLayer_Content);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSetLayer_Content", new { id = setLayer_Content.Content_ID }, setLayer_Content);
        }

        // DELETE: api/SetLayer_Content/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SetLayer_Content>> DeleteSetLayer_Content(int id)
        {
            var setLayer_Content = await _context.Config_SetLayer_Content_Test.FindAsync(id);
            if (setLayer_Content == null)
            {
                return NotFound();
            }

            _context.Config_SetLayer_Content_Test.Remove(setLayer_Content);
            await _context.SaveChangesAsync();

            return setLayer_Content;
        }

        private bool SetLayer_ContentExists(int id)
        {
            return _context.Config_SetLayer_Content_Test.Any(e => e.Content_ID == id);
        }
    }
}
