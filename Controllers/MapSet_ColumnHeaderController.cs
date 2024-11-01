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
    public class MapSet_ColumnHeaderController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public MapSet_ColumnHeaderController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/MapSet_ColumnHeader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapSet_ColumnHeader>>> GetMapSet_ColumnHeader()
        {
            return await _context.Config_MapSet_ColumnHeader_Test.ToListAsync();
        }

        // GET: api/MapSet_ColumnHeader/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MapSet_ColumnHeader>> GetMapSet_ColumnHeader(int id)
        {
            var mapSet_ColumnHeader = await _context.Config_MapSet_ColumnHeader_Test.FindAsync(id);

            if (mapSet_ColumnHeader == null)
            {
                return NotFound();
            }

            return mapSet_ColumnHeader;
        }

        // PUT: api/MapSet_ColumnHeader/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMapSet_ColumnHeader(int id, MapSet_ColumnHeader mapSet_ColumnHeader)
        {
            if (id != mapSet_ColumnHeader.ColumnHeader_ID)
            {
                return BadRequest();
            }

            _context.Entry(mapSet_ColumnHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapSet_ColumnHeaderExists(id))
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

        // POST: api/MapSet_ColumnHeader
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MapSet_ColumnHeader>> PostMapSet_ColumnHeader(MapSet_ColumnHeader mapSet_ColumnHeader)
        {
            _context.Config_MapSet_ColumnHeader_Test.Add(mapSet_ColumnHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMapSet_ColumnHeader", new { id = mapSet_ColumnHeader.ColumnHeader_ID }, mapSet_ColumnHeader);
        }

        // DELETE: api/MapSet_ColumnHeader/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MapSet_ColumnHeader>> DeleteMapSet_ColumnHeader(int id)
        {
            var mapSet_ColumnHeader = await _context.Config_MapSet_ColumnHeader_Test.FindAsync(id);
            if (mapSet_ColumnHeader == null)
            {
                return NotFound();
            }

            _context.Config_MapSet_ColumnHeader_Test.Remove(mapSet_ColumnHeader);
            await _context.SaveChangesAsync();

            return mapSet_ColumnHeader;
        }

        private bool MapSet_ColumnHeaderExists(int id)
        {
            return _context.Config_MapSet_ColumnHeader_Test.Any(e => e.ColumnHeader_ID == id);
        }
    }
}
