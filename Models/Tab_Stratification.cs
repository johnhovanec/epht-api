using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class Tab_Stratification
    {
        [Key]
        [JsonIgnore]
        public int Stratification_ID { get; set; }
        [ForeignKey("Tab_ID")]
        [JsonIgnore]
        public int Tab_ID { get; set; }
        public string Title { get; set; }
        public string Field { get; set; }
    }
}