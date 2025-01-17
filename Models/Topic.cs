using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class Topic
    {
        [Key]
        public int Topic_ID { get; set; }
        public string TopicTitle { get; set; }                          // The title displayed for the topic
        public string TopicUrlPath { get; set; }                        // The URL path name component for a topic, must not include spaces or special characters
        public string Category { get; set; }                            // Designates the type of topic: currently either "health" or "environmental"
        public string DefaultThemePath { get; set; }
        public string Overview { get; set; }                            // Text content displayed on the home page of a topic, ie when no theme has been selected
        public string AboutData { get; set; }                           // Tabular text content displayed on the home page of a topic, ie when no theme has been selected, for topic metadata
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
        [JsonIgnore]
        public int Topic_ID { get; set; }
        public string TopicTitle { get; set; }
        public string TopicUrlPath { get; set; }
        public string Category { get; set; }
        public string ParentTopic { get; set; }
        [NotMapped]
        public List<MinimalTheme> Themes { get; set; }
        [NotMapped]
        public List<MinimalTopic> Subtopics { get; set; }
    }
}
