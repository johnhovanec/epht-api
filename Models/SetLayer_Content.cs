using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace epht_api.Models
{
    public class SetLayer_Content
    {
        [Key]
        public int Content_ID { get; set; }
        [ForeignKey("SetLayer_ID")]
        public int SetLayer_ID { get; set; }
    }
}