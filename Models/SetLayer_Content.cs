using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class SetLayer_Content
    {
        [Key]
        [JsonIgnore]
        public int Content_ID { get; set; }
        [ForeignKey("SetLayer_ID")]
        [JsonIgnore]
        public int SetLayer_ID { get; set; }
        public string Title { get; set; }
        public string Line1 { get; set; }
        public string Line2A { get; set; }
        public string Line2B { get; set; }
        public string Line3 { get; set; }
    }
}