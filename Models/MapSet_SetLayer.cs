﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class MapSet_SetLayer
    {
        [Key]
        [JsonIgnore]
        public int SetLayer_ID { get; set; }
        [ForeignKey("MapSet_ID")]
        [JsonIgnore]
        public int MapSet_ID { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ZIndexPosition { get; set; }
        public string YearKey { get; set; }
        public string CustomSortField { get; set; }
        public string SymbolDescription { get; set; }
        public bool ReferenceLayer { get; set; }
        public bool DefaultVisible { get; set; }
        public bool SourceLayer { get; set; }
        public bool Toggleable { get; set; }
        public bool ScaleDependent { get; set; }
        public bool Custom { get; set; }
        public bool IsModern { get; set; }
        public bool OmitCommunityProfile { get; set; }
        public string Type { get; set; }
        public string CustomStyleTitle { get; set; }
        public string Url { get; set; }
        [NotMapped]
        public SetLayer_Content Content { get; set; }
        [NotMapped]
        public SetLayer_DrawingInfo DrawingInfo { get; set; }
    }
}