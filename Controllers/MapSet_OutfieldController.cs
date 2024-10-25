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
    public class MapSet_OutfieldController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public MapSet_OutfieldController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/MapSet_Outfield
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapSet_Outfield>>> GetMapSet_Outfield()
        {
            return await _context.Config_MapSet_Outfield_Test.ToListAsync();
        }

        // GET: api/MapSet_Outfield/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MapSet_Outfield>> GetMapSet_Outfield(int id)
        {
            var mapSet_Outfield = await _context.Config_MapSet_Outfield_Test.FindAsync(id);

            if (mapSet_Outfield == null)
            {
                return NotFound();
            }

            return mapSet_Outfield;
        }

        // PUT: api/MapSet_Outfield/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMapSet_Outfield(int id, MapSet_Outfield mapSet_Outfield)
        {
            if (id != mapSet_Outfield.Outfield_ID)
            {
                return BadRequest();
            }

            _context.Entry(mapSet_Outfield).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapSet_OutfieldExists(id))
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

        // POST: api/MapSet_Outfield
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MapSet_Outfield>> PostMapSet_Outfield(MapSet_Outfield mapSet_Outfield)
        {
            _context.Config_MapSet_Outfield_Test.Add(mapSet_Outfield);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMapSet_Outfield", new { id = mapSet_Outfield.Outfield_ID }, mapSet_Outfield);
        }

        // DELETE: api/MapSet_Outfield/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MapSet_Outfield>> DeleteMapSet_Outfield(int id)
        {
            var mapSet_Outfield = await _context.Config_MapSet_Outfield_Test.FindAsync(id);
            if (mapSet_Outfield == null)
            {
                return NotFound();
            }

            _context.Config_MapSet_Outfield_Test.Remove(mapSet_Outfield);
            await _context.SaveChangesAsync();

            return mapSet_Outfield;
        }

        private bool MapSet_OutfieldExists(int id)
        {
            return _context.Config_MapSet_Outfield_Test.Any(e => e.Outfield_ID == id);
        }
    }
}
