using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace epht_api.Models
{
    public class Topic
    {
        public int topic_ID { get; set; }
        public string topicTitle { get; set; }
        public string topicPath { get; set; }
        public string category { get; set; }
        public string defaultTabPath { get; set; }
        public string overview { get; set; }
        public string aboutData { get; set; }
        public string countySuppressionRuleRange { get; set; }
        public string countySuppressionRulePopMin { get; set; }
        public string subCountySuppressionRuleRange { get; set; }
        public string subCountySuppressionRulePopMin { get; set; }
    }
}
