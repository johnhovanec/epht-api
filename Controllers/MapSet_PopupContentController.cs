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
    public class MapSet_PopupContentController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public MapSet_PopupContentController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/MapSet_PopupContent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapSet_PopupContent>>> GetMapSet_PopupContent()
        {
            return await _context.Config_MapSet_PopupContent_Test.ToListAsync();
        }

        // GET: api/MapSet_PopupContent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MapSet_PopupContent>> GetMapSet_PopupContent(int id)
        {
            var mapSet_PopupContent = await _context.Config_MapSet_PopupContent_Test.FindAsync(id);

            if (mapSet_PopupContent == null)
            {
                return NotFound();
            }

            return mapSet_PopupContent;
        }

        // PUT: api/MapSet_PopupContent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMapSet_PopupContent(int id, MapSet_PopupContent mapSet_PopupContent)
        {
            if (id != mapSet_PopupContent.PopupContent_ID)
            {
                return BadRequest();
            }

            _context.Entry(mapSet_PopupContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapSet_PopupContentExists(id))
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

        // POST: api/MapSet_PopupContent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MapSet_PopupContent>> PostMapSet_PopupContent(MapSet_PopupContent mapSet_PopupContent)
        {
            _context.Config_MapSet_PopupContent_Test.Add(mapSet_PopupContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMapSet_PopupContent", new { id = mapSet_PopupContent.PopupContent_ID }, mapSet_PopupContent);
        }

        // DELETE: api/MapSet_PopupContent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MapSet_PopupContent>> DeleteMapSet_PopupContent(int id)
        {
            var mapSet_PopupContent = await _context.Config_MapSet_PopupContent_Test.FindAsync(id);
            if (mapSet_PopupContent == null)
            {
                return NotFound();
            }

            _context.Config_MapSet_PopupContent_Test.Remove(mapSet_PopupContent);
            await _context.SaveChangesAsync();

            return mapSet_PopupContent;
        }

        private bool MapSet_PopupContentExists(int id)
        {
            return _context.Config_MapSet_PopupContent_Test.Any(e => e.PopupContent_ID == id);
        }
    }
}
