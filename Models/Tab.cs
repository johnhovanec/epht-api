﻿using System.Collections.Generic;
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
        public string ChartType { get; set; }
        public bool Selectable { get; set; }
        public string Baseline { get; set; }
        public string DefaultSelection { get; set; }
        public string InfoTitle { get; set; }
        public string InfoID { get; set; }
        public string InfoSubtitle { get; set; }
        public string ChartTitle { get; set; }
        public string ChartSubtitle { get; set; }
        public bool DisplayChartTitle { get; set; }
        public string ChartYAxisField { get; set; }
        public bool DisplayChartDiscontinuityGraphic { get; set; }
        public bool DisplayXAxisLabel { get; set; }
        public string XAxisLabel { get; set; }
        public string Url { get; set; }
        public string TableTitle { get; set; }
        public string TableSubtitle { get; set; }
        public bool Stratifiable { get; set; }
        public bool defaultTab { get; set; }            // NCDM specific
        public string textHeader { get; set; }          // NCDM specific
        public string textSubheading { get; set; }      // NCDM specific
        public string textBody { get; set; }            // NCDM specific
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
}
