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


       
        //public string Label { get; set; }
        //public string SetName { get; set; }
        //public bool Fill { get; set; }
        //public byte Order { get; set; }
        //public string YAxisID { get; set; }
        //public string Type { get; set; }
        //public byte PointRadius { get; set; }
        //public byte PointBorderWidth { get; set; }
        //public byte PointHoverRadius { get; set; }
        //public byte PointHoverBorderWidth { get; set; }
        //public byte LineTension { get; set; }
        //public byte BorderWidth { get; set; }
        //public string Stratification { get; set; }
        //public string Title { get; set; }
        //public bool Baseline { get; set; }
        //public string DatasetType { get; set; }


        [NotMapped]
        public List<string> Outfields { get; set; }
        [NotMapped]
        public List<Tab_ColumnHeader> ColumnHeaders { get; set; }
        [NotMapped]
        public List<Tab_PopupContent> PopupContent { get; set; }
        [NotMapped]
        public List<Tab_SetLayer> SetLayers { get; set; }
    }
}