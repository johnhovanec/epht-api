using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace epht_api.Models
{
    public class Tab_MapSet
    {
        [Key]
        public int MapSet_ID { get; set; }
        [ForeignKey("Tab_ID")]
        public int Tab_ID { get; set; }
        public string Set { get; set; }
        public string Geometry { get; set; }
        public string TableTitle { get; set; }

        [NotMapped]
        public List<MapSet_Outfield> Outfields { get; set; }
        [NotMapped]
        public List<Tab_ColumnHeader> ColumnHeaders { get; set; }
        [NotMapped]
        public List<Tab_PopupContent> PopupContent { get; set; }
        [NotMapped]
        public List<Tab_SetLayer> SetLayers { get; set; }
    }
}