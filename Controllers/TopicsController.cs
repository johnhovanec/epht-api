﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using epht_api.Data;
using epht_api.Models;

namespace epht_api.Controllers
{
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly epht_apiContext _context;

        public TopicsController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/Topics
        [HttpGet("api/[controller]")]
        public async Task<ActionResult<IEnumerable<Topic>>> GetAllTopics()
        {
            return await _context.Config_Topic_Test.ToListAsync();
        }

        // GET: api/Topics/birthDefects
        [HttpGet("api/[controller]/{topicUrlPath}")]
        public async Task<ActionResult<Topic>> GetTopic(string topicUrlPath)
        {
            var topic = await _context.Config_Topic_Test.FirstOrDefaultAsync(topic => topic.TopicUrlPath == topicUrlPath);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }

        // Minimal topic config fetch intended for home page navigation
        // GET: api/Topics/MinimalConfig
        [HttpGet("api/[controller]/MinimalConfig")]
        public async Task<ActionResult<IEnumerable<MinimalTopic>>> GetMinimalConfig()
        {
            var minimalTopics = await (from topics in _context.Config_Topic_Test
                                 where topics.ParentTopic == null
                                 select new MinimalTopic()
                                 {
                                     TopicTitle = topics.TopicTitle,
                                     TopicUrlPath = topics.TopicUrlPath,
                                     Category = topics.Category,
                                     // Query the themes for each topic
                                     Themes = (from theme in _context.Config_Theme_Test
                                               where theme.Topic_ID == topics.Topic_ID
                                               select new MinimalTheme()
                                               {
                                                   ThemeTitle = theme.ThemeTitle,
                                                   ThemePath = theme.ThemePath,
                                                   DefaultTabPath = theme.DefaultTabPath,
                                                   // Query the tabs for each theme
                                                   Tabs = (from tab in _context.Config_Tab_Test
                                                           where tab.Theme_ID == theme.Theme_ID
                                                           select new MinimalTab()
                                                           {
                                                               TabTitle = tab.TabTitle,
                                                               TabPath = tab.TabPath,
                                                               
                                                           }).ToList()
                                               }).ToList(),
                                     ParentTopic = topics.ParentTopic,
                                     // Query the subtopics for each topic
                                     Subtopics = (from subtopic in _context.Config_Topic_Test
                                                  where subtopic.ParentTopic == topics.TopicUrlPath
                                                  select new
                                                  {
                                                      Topic_ID = subtopic.Topic_ID,
                                                  }).Any() // Check if the subquery has any results, if so return them in the ternary below.
                                                  // Ternary will either return subtopic results or null if there are no subtopics for the topic
                                                  ? (from subtopic in _context.Config_Topic_Test
                                                     where subtopic.ParentTopic == topics.TopicUrlPath
                                                     select new MinimalTopic()
                                                     {
                                                         Topic_ID = subtopic.Topic_ID,
                                                         TopicTitle = subtopic.TopicTitle,
                                                         TopicUrlPath = subtopic.TopicUrlPath,
                                                         Category = subtopic.Category,
                                                         // Query the subtopic for each theme
                                                         Themes = (from theme in _context.Config_Theme_Test
                                                                   where theme.Topic_ID == subtopic.Topic_ID
                                                                   select new MinimalTheme()
                                                                   {
                                                                       ThemeTitle = theme.ThemeTitle,
                                                                       ThemePath = theme.ThemePath,
                                                                       DefaultTabPath = theme.DefaultTabPath,
                                                                       // Query the tabs for each subtopic theme
                                                                       Tabs = (from tab in _context.Config_Tab_Test
                                                                               where tab.Theme_ID == theme.Theme_ID
                                                                               select new MinimalTab()
                                                                               {
                                                                                   TabTitle = tab.TabTitle,
                                                                                   TabPath = tab.TabPath,

                                                                               }).ToList()
                                                                   }).ToList(),
                                                         ParentTopic = subtopic.ParentTopic
                                                     }).ToList() // Materialize only if there are results
                                                  : null // Set to null if no results so it is omitted from the JSON result
                                 }).ToListAsync();

            return minimalTopics;
        }

        // Full topic config intended for per topic fetch
        // GET: api/Topics/BirthDefects/GetFullConfig
        [HttpGet("api/[controller]/{topicUrlPath}/FullConfig")]
        public async Task<ActionResult<Topic>> GetFullConfig(string topicUrlPath)
        {
            var topic = await _context.Config_Topic_Test.FirstOrDefaultAsync(topic => topic.TopicUrlPath == topicUrlPath);

            if (topic == null)
            {
                return NotFound();
            }

            // Create a list of themes and inserts them into the topic
            var themeQuery = _context.Config_Theme_Test.AsQueryable();
            topic.Themes = (List<Theme>)themeQuery.Where(x => x.Topic_ID == topic.Topic_ID).ToList();

            // Loop through each theme and insert the related tabs
            for (int i = 0; i < topic.Themes.Count; i++)
            {
                // Create a list of tabs for the given theme 
                var tabQuery =
                    from tab in _context.Config_Tab_Test
                    join theme in _context.Config_Theme_Test on tab.Theme_ID equals theme.Theme_ID
                    where tab.Theme_ID == topic.Themes[i].Theme_ID
                    select tab;
                List<Tab> tabs = tabQuery?.ToList();  

                for (int j = 0; j < tabs.Count; j++)
                {
                    if (topic.Themes[i].Theme_ID == tabs[j].Theme_ID)
                    {
                        // Check if the List<Tab> exists and instantiate it if not
                        if (topic.Themes[i].Tabs == null)
                        {
                            topic.Themes[i].Tabs = new List<Tab>();
                        }
                        topic.Themes[i].Tabs.Add(tabs[j]);

                        #region ChartContent
                        // Chart related content
                        if (topic.Themes[i].Tabs[j].ContentType == "chart")
                        {
                            // Check if the List<ChartConfig> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].ChartConfigs == null)
                            {
                                topic.Themes[i].Tabs[j].ChartConfigs = new List<Tab_ChartConfig>();
                            }
                            topic.Themes[i].Tabs[j].ChartConfigs = _context.Config_Tab_ChartConfig_Test.Where(chartConfig => chartConfig.Tab_ID == tabs[j].Tab_ID)?.ToList();

                            // Check if the List<UrlParams> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].UrlParams == null)
                            {
                                topic.Themes[i].Tabs[j].UrlParams = new List<Tab_UrlParam>();
                            }
                            topic.Themes[i].Tabs[j].UrlParams = _context.Config_Tab_UrlParam_Test.Where(urlParam => urlParam.Tab_ID == tabs[j].Tab_ID)?.ToList();

                            // Check if the List<Tab_ChartDataSet> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].ChartDataSets == null)
                            {
                                topic.Themes[i].Tabs[j].ChartDataSets = new List<string>();
                            }
                            topic.Themes[i].Tabs[j].ChartDataSets = _context.Config_Tab_ChartDataSet_Test.Where(chartDataSet => chartDataSet.Tab_ID == tabs[j].Tab_ID).Select(chartDataSet => chartDataSet.SetName)?.ToList();

                            // Check if the List<Tab_DefaultSetName> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].DefaultSetNames == null)
                            {
                                topic.Themes[i].Tabs[j].DefaultSetNames = new List<string>();
                            }
                            topic.Themes[i].Tabs[j].DefaultSetNames = _context.Config_Tab_DefaultSetName_Test.Where(defaultSetName => defaultSetName.Tab_ID == tabs[j].Tab_ID).Select(defaultSetName => defaultSetName.SetName)?.ToList();

                            // Check if the List<Stratification> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].Stratifications == null)
                            {
                                topic.Themes[i].Tabs[j].Stratifications = new List<Tab_Stratification>();
                            }
                            topic.Themes[i].Tabs[j].Stratifications = _context.Config_Tab_Stratification_Test.Where(stratification => stratification.Tab_ID == tabs[j].Tab_ID)?.ToList();

                            // Check if the List<Tab_ColumnHeader> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].ColumnHeaders == null)
                            {
                                topic.Themes[i].Tabs[j].ColumnHeaders = new List<Tab_ColumnHeader>();
                            }
                            topic.Themes[i].Tabs[j].ColumnHeaders = _context.Config_Tab_ColumnHeader_Test.Where(columnHeader => columnHeader.Tab_ID == tabs[j].Tab_ID)?.ToList();
                        }
                        #endregion

                        #region MapContent
                        // Map related content
                        if (topic.Themes[i].Tabs[j].ContentType == "map")
                        {
                            // Check List<MapSets> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].MapSets == null)
                            {
                                topic.Themes[i].Tabs[j].MapSets = new List<Tab_MapSet>();
                            }
                            topic.Themes[i].Tabs[j].MapSets = _context.Config_Tab_MapSet_Test.Where(mapSet => mapSet.Tab_ID == tabs[j].Tab_ID)?.ToList();

                            // Create a list of mapSets for the given theme 
                            if (topic.Themes[i].Tabs[j].MapSets.Count > 0)
                            {
                                var mapSetQuery =
                                from mapSet in _context.Config_Tab_MapSet_Test.DefaultIfEmpty()
                                join tab in _context.Config_Tab_Test on mapSet.Tab_ID equals tab.Tab_ID
                                where tab.Tab_ID == topic.Themes[i].Tabs[j].Tab_ID
                                select mapSet;
                                List<Tab_MapSet> mapSets = mapSetQuery?.ToList();

                                for (int k = 0; k < mapSets.Count; k++)
                                {
                                    if (topic.Themes[i].Tabs[j].MapSets[k].MapSet_ID == mapSets[k].MapSet_ID)
                                    {
                                        topic.Themes[i].Tabs[j].MapSets[k] = mapSets[k];
                                    }

                                    // Check List<MapSet_Outfield> exists and instantiate it if not
                                    if (topic.Themes[i].Tabs[j].MapSets[k].Outfields == null)
                                    {
                                        topic.Themes[i].Tabs[j].MapSets[k].Outfields = new List<string>();
                                    }
                                    topic.Themes[i].Tabs[j].MapSets[k].Outfields = _context.Config_MapSet_Outfield_Test.Where(outfield => outfield.MapSet_ID == mapSets[k].MapSet_ID).Select(outfield => outfield.OutFieldName)?.ToList();

                                    // Check List<MapSet_ColumnHeaders> exists and instantiate it if not
                                    if (topic.Themes[i].Tabs[j].MapSets[k].ColumnHeaders == null)
                                    {
                                        topic.Themes[i].Tabs[j].MapSets[k].ColumnHeaders = new List<MapSet_ColumnHeader>();
                                    }
                                    topic.Themes[i].Tabs[j].MapSets[k].ColumnHeaders = _context.Config_MapSet_ColumnHeader_Test.Where(columnHeader => columnHeader.MapSet_ID == mapSets[k].MapSet_ID)?.ToList();

                                    // Check List<MapSet_PopupContent> exists and instantiate it if not
                                    if (topic.Themes[i].Tabs[j].MapSets[k].PopupContents == null)
                                    {
                                        topic.Themes[i].Tabs[j].MapSets[k].PopupContents = new List<MapSet_PopupContent>();
                                    }
                                    topic.Themes[i].Tabs[j].MapSets[k].PopupContents = _context.Config_MapSet_PopupContent_Test.Where(popupContent => popupContent.MapSet_ID == mapSets[k].MapSet_ID)?.ToList();

                                    // Create a list of SetLayers for the given MapSet
                                    var setLayerQuery =
                                    from setLayer in _context.Config_MapSet_SetLayer_Test.DefaultIfEmpty()
                                    join mapSet in _context.Config_Tab_MapSet_Test on setLayer.MapSet_ID equals mapSet.MapSet_ID
                                    where setLayer.MapSet_ID == topic.Themes[i].Tabs[j].MapSets[k].MapSet_ID
                                    select setLayer;
                                    List<MapSet_SetLayer> setLayers = setLayerQuery?.ToList();

                                    // Check List<MapSets_SetLayer> exists and instantiate it if not
                                    if (topic.Themes[i].Tabs[j].MapSets[k].SetLayers == null)
                                    {
                                        topic.Themes[i].Tabs[j].MapSets[k].SetLayers = new List<MapSet_SetLayer>();
                                    }
                                    topic.Themes[i].Tabs[j].MapSets[k].SetLayers = setLayers;

                                    // SetLayer_Content
                                    for (int l = 0; l < setLayers.Count; l++)
                                    {
                                        // Check if it is a reference layer: only reference layers will have SetLayer_Content and SetLayer_DrawingInfo
                                        if (topic.Themes[i].Tabs[j].MapSets[k].SetLayers[l].ReferenceLayer)
                                        {
                                            // SetLayer_Content
                                            if (topic.Themes[i].Tabs[j].MapSets[k].SetLayers[l].Content == null)
                                            {
                                                topic.Themes[i].Tabs[j].MapSets[k].SetLayers[l].Content = new SetLayer_Content();
                                            }
                                            topic.Themes[i].Tabs[j].MapSets[k].SetLayers[l].Content = _context.Config_SetLayer_Content_Test.FirstOrDefault(content => content.SetLayer_ID == setLayers[l].SetLayer_ID);

                                            // SetLayer_DrawingInfo
                                            if (topic.Themes[i].Tabs[j].MapSets[k].SetLayers[l].DrawingInfo == null)
                                            {
                                                topic.Themes[i].Tabs[j].MapSets[k].SetLayers[l].DrawingInfo = new SetLayer_DrawingInfo();
                                            }
                                            // Query to populate the nested object structure for DrawingInfo
                                            topic.Themes[i].Tabs[j].MapSets[k].SetLayers[l].DrawingInfo = (
                                                from drawingInfo in _context.Config_SetLayer_DrawingInfo_Test
                                                select new SetLayer_DrawingInfo()
                                                {
                                                    DrawingInfo_ID = drawingInfo.DrawingInfo_ID,
                                                    SetLayer_ID = drawingInfo.SetLayer_ID,
                                                    Renderer = new SetLayer_DrawingInfo.DrawingInfoRenderer()
                                                    {
                                                        Type = drawingInfo.RendererType,
                                                        Symbol = new SetLayer_DrawingInfo.DrawingInfoSymbol()
                                                        {
                                                            Type = drawingInfo.SymbolType,
                                                            Url = drawingInfo.SymbolUrl,
                                                            ImageData = drawingInfo.SymbolImageData,
                                                            ContentType = drawingInfo.SymbolContentType,
                                                            Width = drawingInfo.SymbolWidth,
                                                            Height = drawingInfo.SymbolHeight,
                                                            Angle = drawingInfo.SymbolAngle,
                                                            Xoffset = drawingInfo.SymbolXOffset,
                                                            Yoffset = drawingInfo.SymbolYOffset
                                                        },
                                                        Label = drawingInfo.RendererLabel,
                                                        Description = drawingInfo.RendererDescription
                                                    }
                                                }).FirstOrDefault(drawingInfo => drawingInfo.SetLayer_ID == setLayers[l].SetLayer_ID);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region TableContent
                        if (topic.Themes[i].Tabs[j].ContentType == "table")
                        {
                            // Check if the List<Tab_ColumnHeader> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].ColumnHeaders == null)
                            {
                                topic.Themes[i].Tabs[j].ColumnHeaders = new List<Tab_ColumnHeader>();
                            }
                            topic.Themes[i].Tabs[j].ColumnHeaders = _context.Config_Tab_ColumnHeader_Test.Where(columnHeader => columnHeader.Tab_ID == tabs[j].Tab_ID)?.ToList();

                            // Check if the List<Stratification> exists and instantiate it if not
                            if (topic.Themes[i].Tabs[j].Stratifications == null)
                            {
                                topic.Themes[i].Tabs[j].Stratifications = new List<Tab_Stratification>();
                            }
                            topic.Themes[i].Tabs[j].Stratifications = _context.Config_Tab_Stratification_Test.Where(stratification => stratification.Tab_ID == tabs[j].Tab_ID)?.ToList();
                        }
                        #endregion
                    }
                }
            }
            return topic;
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("api/[controller]/{id}")]
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
        [HttpPost("api/[controller]/{topic}")]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            _context.Config_Topic_Test.Add(topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopic", new { id = topic.Topic_ID }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("api/[controller]/{id}")]
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
