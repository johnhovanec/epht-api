using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class Tab_UrlParam
    {
        [Key]
        [JsonIgnore]
        public int UrlParam_ID { get; set; }
        [ForeignKey("Tab_ID")]
        [JsonIgnore]
        public int Tab_ID { get; set; }
        public string Param { get; set; }
        public string Value { get; set; }
        public string ValueKey { get; set; }
    }
}