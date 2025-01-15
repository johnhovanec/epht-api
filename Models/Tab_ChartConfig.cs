using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class Tab_ChartConfig
    {
        [Key]
        [JsonIgnore]
        public int ChartConfig_ID { get; set; }
        [ForeignKey("Tab_ID")]
        [JsonIgnore]
        public int Tab_ID { get; set; }
        public string Label { get; set; }
        public string SetName { get; set; }
        public bool Fill { get; set; }
        public byte Order { get; set; }                   
        public string YAxisID { get; set; }
        public string Type { get; set; }                  // The chart.js type of chart -- either 'bar' or 'line' 
        public byte PointRadius { get; set; }
        public byte PointBorderWidth { get; set; }
        public byte PointHoverRadius { get; set; }
        public byte PointHoverBorderWidth { get; set; }
        public byte LineTension { get; set; }             // Controls the tension for lines on a line chart -- set to 0
        public byte BorderWidth { get; set; }             // For line charts sets the line thickness -- use the default of 3; for bar charts sets the border of the bar -- set to 0 for no border
        public string Stratification { get; set; }
        public string Title { get; set; }
        public bool Baseline { get; set; }
        public string DatasetType { get; set; }
        [NotMapped]
        public List<string> Data { get; set; }
    }
}