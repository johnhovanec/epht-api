using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using epht_api.Data;
using epht_api.Models;
using Microsoft.EntityFrameworkCore;

namespace epht_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetLayer_DrawingInfoController : ControllerBase
    {
        
        private readonly epht_apiContext _context;

        public SetLayer_DrawingInfoController(epht_apiContext context)
        {
            _context = context;
        }

        // GET: api/SetLayer_DrawingInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SetLayer_DrawingInfo>>> GetSetLayer_DrawingInfo()
        {
            return await (
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
                            XOffset = drawingInfo.SymbolXOffset,
                            YOffset = drawingInfo.SymbolYOffset
                        },
                        Label = drawingInfo.RendererLabel,
                        Description = drawingInfo.RendererDescription
                    }
                })
                .ToListAsync();
        }

        // GET: api/SetLayer_Content/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SetLayer_DrawingInfo>> GetSetLayer_DrawingInfo(int id)
        {
            var setLayer_DrawingInfo = await (
                from drawingInfo in _context.Config_SetLayer_DrawingInfo_Test
                where drawingInfo.DrawingInfo_ID == id
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
                            XOffset = drawingInfo.SymbolXOffset,
                            YOffset = drawingInfo.SymbolYOffset
                        },
                        Label = drawingInfo.RendererLabel,
                        Description = drawingInfo.RendererDescription
                    }
                }).ToListAsync();
                

            if (setLayer_DrawingInfo == null)
            {
                return NotFound();
            }

            return setLayer_DrawingInfo.FirstOrDefault();
        }
    }
}
