﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace epht_api.Models
{
    public class MapSet_PopupContent
    {
        [Key]
        [JsonIgnore]
        public int PopupContent_ID { get; set; }
        [ForeignKey("MapSet_ID")]
        [JsonIgnore]
        public int MapSet_ID { get; set; }
        public string PopupType { get; set; }   //One of: title, health, environment, link, additional, secondary. Should be refactored as an enum.
        public string Field { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string Unit { get; set; }
    }
}