using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace epht_api.Models
{
    public class MapSet_Outfield
    {
        [Key]
        public int Outfield_ID { get; set; }
        [ForeignKey("MapSet_ID")]
        public int MapSet_ID { get; set; }
        public string OutFieldName { get; set; }
    }
}