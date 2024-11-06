using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epht_api.Models
{
    public class DrawingInfo_Renderer
    {
        public string RendererType { get; set; }
        public DrawingInfo_Symbol Symbol { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}
