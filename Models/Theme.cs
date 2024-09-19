using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace epht_api.Models
{
    public class Theme
    {
        [Key]
        public int Theme_ID { get; set; }
        [ForeignKey("Topic_ID")]
        public int Topic_ID { get; set; }
        public string DefaultTabPath { get; set; }
        public string ThemeTitle { get; set; }
        public string ThemePath { get; set; }
        public string ThemeOverviewText { get; set; }
        public string About { get; set; }
        public string Resources { get; set; }
    }
}
