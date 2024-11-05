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
    public class MapSet_SetLayerController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public MapSet_SetLayerController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/MapSet_SetLayer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapSet_SetLayer>>> GetMapSet_SetLayer()
        {
            return await _context.Config_MapSet_SetLayer_Test.ToListAsync();
        }

        // GET: api/MapSet_SetLayer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MapSet_SetLayer>> GetMapSet_SetLayer(int id)
        {
            var mapSet_SetLayer = await _context.Config_MapSet_SetLayer_Test.FindAsync(id);

            if (mapSet_SetLayer == null)
            {
                return NotFound();
            }

            return mapSet_SetLayer;
        }

        // PUT: api/MapSet_SetLayer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMapSet_SetLayer(int id, MapSet_SetLayer mapSet_SetLayer)
        {
            if (id != mapSet_SetLayer.SetLayer_ID)
            {
                return BadRequest();
            }

            _context.Entry(mapSet_SetLayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapSet_SetLayerExists(id))
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

        // POST: api/MapSet_SetLayer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MapSet_SetLayer>> PostMapSet_SetLayer(MapSet_SetLayer mapSet_SetLayer)
        {
            _context.Config_MapSet_SetLayer_Test.Add(mapSet_SetLayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMapSet_SetLayer", new { id = mapSet_SetLayer.SetLayer_ID }, mapSet_SetLayer);
        }

        // DELETE: api/MapSet_SetLayer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MapSet_SetLayer>> DeleteMapSet_SetLayer(int id)
        {
            var mapSet_SetLayer = await _context.Config_MapSet_SetLayer_Test.FindAsync(id);
            if (mapSet_SetLayer == null)
            {
                return NotFound();
            }

            _context.Config_MapSet_SetLayer_Test.Remove(mapSet_SetLayer);
            await _context.SaveChangesAsync();

            return mapSet_SetLayer;
        }

        private bool MapSet_SetLayerExists(int id)
        {
            return _context.Config_MapSet_SetLayer_Test.Any(e => e.SetLayer_ID == id);
        }
    }
}
