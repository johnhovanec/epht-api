﻿using System.Collections.Generic;
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
    public class TopicsController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public TopicsController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetTopic()
        {
            return await _context.Config_Topic_Test.ToListAsync();
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetTopic(int id)
        {
            var topic = await _context.Config_Topic_Test.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }

        // GET: api/Topics/25/GetFullConfig
        // This endpoint reconstructs the topic.js structure for a given topic ID
        [HttpGet("{id}/GetFullConfig")]
        public async Task<ActionResult<Topic>> GetFullConfig(int id)
        {
            // Find the topic by id
            var topic = await _context.Config_Topic_Test.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            // Create a list of themes and inserts them into the topic
            var themeQuery = _context.Config_Theme_Test.AsQueryable();
            topic.Themes = (List<Theme>)themeQuery.Where(x => x.Topic_ID == id).ToList();

            // Create a list of tabs filtered by themes and inserts them into each theme
            var tabQuery =
                from tab in _context.Config_Tab_Test
                join theme in _context.Config_Theme_Test on tab.Theme_ID equals theme.Theme_ID
                where topic.Themes.Select(x => x.Theme_ID).Contains(tab.Theme_ID)
                select tab;
            List<Tab> tabs = tabQuery.ToList();

            // Loop through each theme and insert the related tabs
            for (int i = 0; i < topic.Themes.Count; i++)
            {
                for (int j = 0; j < tabs.Count - 1; j++)
                {
                    if (topic.Themes[i].Theme_ID == tabs[j].Theme_ID)
                    {
                        // Check if the List<Tab> exists and instantiate it if not
                        if (topic.Themes[i].Tabs == null)
                        {
                            topic.Themes[i].Tabs = new List<Tab>();
                        }
                        topic.Themes[i].Tabs.Add(tabs[j]);

                        // Check if the List<ChartConfig> exists and instantiate it if not
                        if (topic.Themes[i].Tabs[j].ChartConfigs == null)
                        {
                            topic.Themes[i].Tabs[j].ChartConfigs = new List<Tab_ChartConfig>();
                        }
                        topic.Themes[i].Tabs[j].ChartConfigs = _context.Config_Tab_ChartConfig_Test.Where(chartConfig => chartConfig.Tab_ID == tabs[j].Tab_ID).ToList();

                        // Check if the List<UrlParams> exists and instantiate it if not
                        if (topic.Themes[i].Tabs[j].UrlParams == null)
                        {
                            topic.Themes[i].Tabs[j].UrlParams = new List<Tab_UrlParam>();
                        }
                        topic.Themes[i].Tabs[j].UrlParams = _context.Config_Tab_UrlParam_Test.Where(urlParam => urlParam.Tab_ID == tabs[j].Tab_ID).ToList();
                    }
                }
            }

            return topic;
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, Topic topic)
        {
            if (id != topic.Topic_ID)
            {
                return BadRequest();
            }

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/Topics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            _context.Config_Topic_Test.Add(topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopic", new { id = topic.Topic_ID }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Topic>> DeleteTopic(int id)
        {
            var topic = await _context.Config_Topic_Test.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Config_Topic_Test.Remove(topic);
            await _context.SaveChangesAsync();

            return topic;
        }

        private bool TopicExists(int id)
        {
            return _context.Config_Topic_Test.Any(e => e.Topic_ID == id);
        }
    }
}
