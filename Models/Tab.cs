using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class Tab
    {
        [Key]
        [JsonIgnore]
        public int Tab_ID { get; set; }
        [ForeignKey("Theme_ID")]
        [JsonIgnore]
        public int Theme_ID { get; set; }
        public string TabTitle { get; set; }
        public string TabPath { get; set; }
        public string ContentType { get; set; }
        public string ExportTitle { get; set; }
        public string ExportSubtitle { get; set; }
        public string ChartType { get; set; }                           // Chart specific
        public bool Selectable { get; set; }                            // Chart specific
        public string Baseline { get; set; }                            // Chart specific
        public string DefaultSelection { get; set; }                    
        public string InfoTitle { get; set; }                           // Chart specific
        public string InfoID { get; set; }                              // Chart specific
        public string InfoSubtitle { get; set; }                        // Chart specific
        public string ContentTitle { get; set; }                        // Map specific
        public string ChartTitle { get; set; }                          // Chart specific
        public string ChartSubtitle { get; set; }                       // Chart specific
        public bool DisplayChartTitle { get; set; }                     // Chart specific
        public bool DisplayChartSubtitle { get; set; }                  // Chart specific
        public bool DisplayYAxisLabel { get; set; }                     // Chart specific
        public string YAxisLabel { get; set; }                          // Chart specific
        public string YAxisLabelLeft { get; set; }                      // Chart specific
        public string YAxisIdLeft { get; set; }                         // Chart specific
        public string YAxisLabelRight { get; set; }                     // Chart specific
        public string YAxisIdRight { get; set; }                        // Chart specific
        public string ChartYAxisField { get; set; }                     // Chart specific
        public bool DisplayChartDiscontinuityGraphic { get; set; }      // Chart specific
        public bool DisplayXAxisLabel { get; set; }                     // Chart specific
        public string ChartXAxisField { get; set; }                     // Chart specific
        public string XAxisLabel { get; set; }                          // Chart specific
        public string DefaultStratification { get; set; }               // Chart specific
        public string Url { get; set; }                                 // Chart specific  
        public bool TimeSlider { get; set; }                            // Chart specific
        public bool HighContrastPalette { get; set; }                   // Chart specific
        public string TableTitle { get; set; }
        public string TableSubtitle { get; set; }
        public bool Stratifiable { get; set; }                          // Chart specific
        public bool DefaultTab { get; set; }                            // NCDM specific
        public string TextHeader { get; set; }                          // NCDM specific
        public string TextSubheading { get; set; }                      // NCDM specific
        public string TextBody { get; set; }                            // NCDM specific
        [NotMapped]
        public List<Tab_ChartConfig> ChartConfigs { get; set; }
        [NotMapped]
        public List<Tab_UrlParam> UrlParams { get; set; }
        [NotMapped]
        public List<Tab_MapSet> MapSets { get; set; }
        [NotMapped]
        public List<string> ChartDataSets { get; set; }
        [NotMapped]
        public List<string> DefaultSetNames { get; set; }
        [NotMapped]
        public List<Tab_Stratification> Stratifications { get; set; }
        [NotMapped]
        public List<Tab_ColumnHeader> ColumnHeaders { get; set; }
    }

    public class MinimalTab
    {
        public string TabTitle { get; set; }
        public string TabPath { get; set; }
    }
}
