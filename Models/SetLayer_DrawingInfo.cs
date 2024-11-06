using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class SetLayer_DrawingInfo
    {   
        [Key]
        public int DrawingInfo_ID { get; set; }
        [ForeignKey("SetLayer_ID")]
        public int SetLayer_ID { get; set; }
        [JsonIgnore]
        public string RendererType { get; set; }
        [JsonIgnore]
        public string RendererLabel { get; set; }
        [JsonIgnore]
        public string RendererDescription { get; set; }
        [JsonIgnore]
        public string SymbolType { get; set; }
        [JsonIgnore]
        public string SymbolUrl { get; set; }
        [JsonIgnore]
        public string SymbolImageData { get; set; }
        [JsonIgnore]
        public string SymbolContentType { get; set; }
        [JsonIgnore]
        public int SymbolWidth { get; set; }
        [JsonIgnore]
        public int SymbolHeight { get; set; }
        [JsonIgnore]
        public int SymbolAngle { get; set; }
        [JsonIgnore]
        public int SymbolXOffset { get; set; }
        [JsonIgnore]
        public int SymbolYOffset { get; set; }
        public DrawingInfoRenderer Renderer { get; set; }

        [NotMapped]
        public class DrawingInfoRenderer
        {
            public string Type { get; set; }
            public DrawingInfoSymbol Symbol { get; set; }
            public string Label { get; set; }
            public string Description { get; set; }
        }

        [NotMapped]
        public class DrawingInfoSymbol
        {
            public string Type { get; set; }
            public string Url { get; set; }
            public string ImageData { get; set; }
            public string ContentType { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Angle { get; set; }
            public int XOffset { get; set; }
            public int YOffset { get; set; }
        }
    }
}