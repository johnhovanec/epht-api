using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class MapSet_Outfield
    {
        [Key]
        [JsonIgnore]
        public int Outfield_ID { get; set; }
        [ForeignKey("MapSet_ID")]
        [JsonIgnore]
        public int MapSet_ID { get; set; }
        public string OutFieldName { get; set; }
    }
}