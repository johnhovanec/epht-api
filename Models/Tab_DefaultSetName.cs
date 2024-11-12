using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace epht_api.Models
{
    public class Tab_DefaultSetName
    {
        [Key]
        public int DefaultSetName_ID { get; set; }
        [ForeignKey("Tab_ID")]
        public int Tab_ID { get; set; }
        public string SetName { get; set; }
    }
}