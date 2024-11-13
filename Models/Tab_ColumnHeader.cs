using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class Tab_ColumnHeader
    {
        [Key]
        [JsonIgnore]
        public int ColumnHeader_ID { get; set; }
        [ForeignKey("Tab_ID")]
        [JsonIgnore]
        public int Tab_ID { get; set; }
        public string Field { get; set; }
        public string HeaderName { get; set; }
        public string ExportHeaderName { get; set; }
        public int Width { get; set; }
        public string Align { get; set; }
        public string HeaderAlign { get; set; }
        public int CustomFormat { get; set; }
        public string Stratification { get; set; }
    }
}
