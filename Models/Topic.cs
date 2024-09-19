﻿using System.ComponentModel.DataAnnotations;

namespace epht_api.Models
{
    public class Topic
    {
        [Key]
        public int Topic_ID { get; set; }
        public string TopicTitle { get; set; }
        public string topicPath { get; set; }
        public string Category { get; set; }
        public string DefaultTabPath { get; set; }
        public string Overview { get; set; }
        public string AboutData { get; set; }
        public string CountySuppressionRuleRange { get; set; }
        public string CountySuppressionRulePopMin { get; set; }
        public string SubCountySuppressionRuleRange { get; set; }
        public string SubCountySuppressionRulePopMin { get; set; }
    }
}
