using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace epht_api.Models
{
    public class Topic
    {
        [Key]
        public int Topic_ID { get; set; }
        public string TopicTitle { get; set; }
        public string TopicUrlPath { get; set; }
        public string Category { get; set; }
        public string DefaultThemePath { get; set; }
        public string Overview { get; set; }
        public string AboutData { get; set; }
        public string CountySuppressionRuleRange { get; set; }
        public string CountySuppressionRulePopMin { get; set; }
        public string SubCountySuppressionRuleRange { get; set; }
        public string SubCountySuppressionRulePopMin { get; set; }
        public bool OmitNcdmData { get; set; }
        public string ParentTopic { get; set; }
        [NotMapped]
        public List<Theme>Themes { get; set; }
    }

    public class MinimalTopic
    {
        public int Topic_ID { get; set; }
        public string TopicTitle { get; set; }
        public string TopicUrlPath { get; set; }
        public string Category { get; set; }
        public string ParentTopic { get; set; }
        [NotMapped]
        public List<MinimalTopic> Subtopics { get; set; }
    }
}
