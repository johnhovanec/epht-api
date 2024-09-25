using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace epht_api.Models
{
    public class Tab_UrlParam
    {
        [Key]
        public int UrlParam_ID { get; set; }
        [ForeignKey("Tab_ID")]
        public int Tab_ID { get; set; }
        public string Param { get; set; }
        public string Value { get; set; }
    }
}